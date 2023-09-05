namespace Cadeteria.Services;

using AutoMapper;
using BCrypt.Net;
using Cadeteria.Models;
using Cadeteria.Authorization;
using Microsoft.EntityFrameworkCore.Internal;
using Cadeteria.DTOs;
using AutoMapper.QueryableExtensions;

public class UserRepository : IUserRepository
{
    private DataContext _context;
    private IJwtUtils _jwtUtils;
    private readonly IMapper _mapper;

    public UserRepository(
        DataContext context,
        IJwtUtils jwtUtils,
        IMapper mapper)
    {
        _context = context;
        _jwtUtils = jwtUtils;
        _mapper = mapper;
    }

    public AuthenticateResponse Authenticate(AuthenticateRequest model)
    {
        var user = _context.Users.SingleOrDefault(x => x.userName == model.UserName);
        // validate
        if (user == null || !BCrypt.Verify(model.Password, user.password))
            throw new AppException("Username or password is incorrect");

        var prof = _context.Profile.SingleOrDefault(x => x.userForeiKey == user.Id);
        var Rol = _context.Rols.SingleOrDefault(x => x.Id == user.rolForeikey);

        // authentication successful
        var response = _mapper.Map<AuthenticateResponse>(user);
        response.Token = _jwtUtils.GenerateToken(user);
        response.Rol = Rol.rolName;

        response.id_profile = (prof != null) ? prof.id : null;
        return response;
    }
    //### En este caso no es necesario llamar a tantas tablas solo para la autenticacion
    // public UserDTO AuthenticateDTO(AuthenticateRequest model)
    // {
    //     var user = _context.Users.SingleOrDefault(x => x.userName == model.UserName);
    //     // validate
    //     if (user == null || !BCrypt.Verify(model.Password, user.password))
    //         throw new AppException("Username or password is incorrect");

    //     var response = _context.Users.ProjectTo<UserDTO>(_mapper.ConfigurationProvider)
    //     .Where(x => x.Profile.userForeiKey == user.Id)
    //     .SingleOrDefault();
    //     //response.Token = _jwtUtils.GenerateToken(user);

    //     return response;
    // }

    public IEnumerable<User> GetAll()
    {
        return _context.Users;
    }
    public IEnumerable<Rol> GetAllRol()
    {
        return _context.Rols;
    }

    public User GetById(Guid id)
    {
        return getUser(id);
    }

    public void Register(RegisterRequest model)
    {
        // validate
        if (_context.Users.Any(x => x.userName == model.UserName))
            throw new AppException("Username '" + model.UserName + "' is already taken");

        // map model to new user object
        var user = _mapper.Map<User>(model);

        // hash password
        user.password = BCrypt.HashPassword(model.Password);
        user.rolForeikey = Guid.Parse("f0601b48-a878-4fb5-a767-3f1340b8c0d8");

        // save user
        _context.Users.Add(user);
        _context.SaveChanges();
    }

    public void Update(Guid id, UpdateRequest model)
    {
        var user = getUser(id);

        // validate campo cuando el userName no puede ser cambiado, sugerencia para usar Email
        // if (model.UserName != user.userName && _context.Users.Any(x => x.userName == model.UserName))
        //     throw new AppException("Username '" + model.UserName + "' is already taken");

        // hash password if it was entered
        if (!string.IsNullOrEmpty(model.Password))
            user.password = BCrypt.HashPassword(model.Password);

        // copy model to user and save
        _mapper.Map(model, user);
        _context.Users.Update(user);
        _context.SaveChanges();
    }

    public void Delete(Guid id)
    {
        var user = getUser(id);
        _context.Users.Remove(user);
        _context.SaveChanges();
    }

    // helper methods

    private User getUser(Guid id)
    {
        var user = _context.Users.Find(id);
        if (user == null) throw new KeyNotFoundException("User not found");
        return user;
    }

    public List<JoinResponse> GetUserJoin(int page)
    {
        List<JoinResponse> data = new List<JoinResponse>();

        var pagedData = _context.Users.Join(_context.Rols, us => us.rolForeikey, r => r.Id,
            (us, r) => new { us.Id, us.userName, us.rolForeikey, r.rolName })
            .Join(_context.Profile, us => us.Id, pr => pr.userForeiKey, (us, p) => new
            { us.rolName, p.id, p.userForeiKey, p.Direccion, p.Telefono, p.Nombre, p.Referencia })
            .Skip((page - 1) * 1)
            .Take(1);

        foreach (var item in pagedData)
        {
            data.Add(new JoinResponse()
            {
                Id = item.id,
                userForeiKey = item.userForeiKey,
                Direccion = item.Direccion,
                Nombre = item.Nombre,
                Referencia = item.Referencia,
                Telefono = item.Telefono,
                rolName = item.rolName
            });
        }

        return data;
    }

    public List<JoinResponse> GetUserJoinAndWhere(int page, string condicion)
    {

        List<JoinResponse> data = new List<JoinResponse>();

        var pagedData = _context.Users.Join(_context.Rols, us => us.rolForeikey, r => r.Id,
        (us, r) => new { us.Id, us.userName, us.rolForeikey, r.rolName })
        .Join(_context.Profile, us => us.Id, pr => pr.userForeiKey, (us, p) => new
        { us.rolName, p.id, p.userForeiKey, p.Direccion, p.Telefono, p.Nombre, p.Referencia })
        .Where(x => x.rolName == condicion)
        .Skip((page - 1) * 1)
        .Take(1);

        foreach (var item in pagedData)
        {
            data.Add(new JoinResponse()
            {
                Id = item.id,
                userForeiKey = item.userForeiKey,
                Direccion = item.Direccion,
                Nombre = item.Nombre,
                Referencia = item.Referencia,
                Telefono = item.Telefono,
                rolName = item.rolName
            });
        }

        return data;
    }

    public List<UserDTO> GetUserJoinDTO(int page)
    {
        var response = _context.Users.ProjectTo<UserDTO>(_mapper.ConfigurationProvider)
        .Skip((page - 1) * 1)
        .Take(1).ToList();

        return response;
    }
    public List<UserDTO> GetUserJoinAndWhereDTO(int page, string condicion)
    {

        var response = _context.Users.ProjectTo<UserDTO>(_mapper.ConfigurationProvider)
        .Where(x => x.rol.rolName == condicion)
        .Skip((page - 1) * 1)
        .Take(1).ToList();

        return response;
    }


}