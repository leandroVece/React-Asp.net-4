namespace Cadeteria.Controllers;

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Cadeteria.Authorization;
using Cadeteria.Models;
using Cadeteria.Services;
using Cadeteria.DTOs;

[Authorize]
[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private IUserRepository _userRepository;
    DataContext _db;
    private IMapper _mapper;
    private readonly AppSettings _appSettings;

    public UserController(
        IUserRepository userService,
        DataContext db,
        IMapper mapper,
        IOptions<AppSettings> appSettings)
    {
        _userRepository = userService;
        _db = db;
        _mapper = mapper;
        _appSettings = appSettings.Value;
    }

    [AllowAnonymous]
    [HttpPost("authenticate")]
    public IActionResult Authenticate(AuthenticateRequest model)
    {
        var response = _userRepository.Authenticate(model);
        //SetSesion(response);
        return Ok(response);
    }
    //[AllowAnonymous]
    // [HttpPost("authenticateDTO")]
    // public IActionResult Authenticate2(AuthenticateRequest model)
    // {
    //     var response = _userRepository.AuthenticateDTO(model);
    //     return Ok(response);
    // }

    [AllowAnonymous]
    [HttpPost("register")]
    public IActionResult Register(RegisterRequest model)
    {
        _userRepository.Register(model);
        return Ok(new { message = "Registration successful" });
    }

    [HttpGet("{id}")]
    public IActionResult Getbyid(Guid id)
    {
        var response = _userRepository.GetById(id);

        return Ok(response);
    }


    [HttpGet]
    [Route("page/{page:int?}")]
    public IActionResult GetPageUser(int? page = 1)
    {
        List<JoinResponse> pagedData = _userRepository.GetUserJoin((int)page);

        var totalRecords = _db.Users.Join(_db.Rols, us => us.rolForeikey, r => r.Id,
        (us, r) => new { us.Id, r.rolName }).Count();
        return Ok(new PagedResponse<IEnumerable<JoinResponse>>(
            pagedData, totalRecords / 1, (int)page));
    }


    [HttpGet]
    [Route("cadete/page/{page:int?}")]
    public IActionResult GetCadetepage(int? page = 1)
    {
        var pagedData = _userRepository.GetUserJoinAndWhere((int)page, "cadete");

        var totalRecords = _db.Users.Join(_db.Rols, us => us.rolForeikey, r => r.Id,
        (us, r) => new { us.Id, r.rolName }).Where(x => x.rolName == "cadete").Count();
        return Ok(new PagedResponse<IEnumerable<JoinResponse>>(
            pagedData, totalRecords / 1, (int)page));
    }


    [HttpGet]
    [Route("cliente/page/{page:int?}")]
    public IActionResult GetClientePage(int? page = 1)
    {
        var pagedData = _userRepository.GetUserJoinAndWhere((int)page, "cliente");

        var totalRecords = _db.Users.Join(_db.Rols, us => us.rolForeikey, r => r.Id,
        (us, r) => new { us.Id, r.rolName }).Where(x => x.rolName == "cliente").Count();
        return Ok(new PagedResponse<IEnumerable<JoinResponse>>(
            pagedData, totalRecords / 1, (int)page));
    }
    [HttpGet]
    [Route("dto/{page:int?}")]
    public IActionResult GetPageUserDTO(int? page = 1)
    {
        List<JoinResponse> pagedData = _userRepository.GetUserJoin((int)page);

        var totalRecords = _db.Users.Join(_db.Rols, us => us.rolForeikey, r => r.Id,
        (us, r) => new { us.Id, r.rolName }).Count();
        return Ok(new PagedResponse<IEnumerable<JoinResponse>>(
            pagedData, totalRecords / 1, (int)page));
    }


    [HttpGet]
    [Route("cadete/dto/{page:int?}")]
    public IActionResult GetCadetepageDTO(int? page = 1)
    {
        var pagedData = _userRepository.GetUserJoinAndWhereDTO((int)page, "cadete");

        var totalRecords = _db.Users.Join(_db.Rols, us => us.rolForeikey, r => r.Id,
        (us, r) => new { us.Id, r.rolName }).Where(x => x.rolName == "cadete").Count();
        return Ok(new PagedResponse<List<UserDTO>>(
            pagedData, totalRecords / 1, (int)page));
    }


    [HttpGet]
    [Route("cliente/dto/{page:int?}")]
    public IActionResult GetClientePageDTO(int? page = 1)
    {
        var pagedData = _userRepository.GetUserJoinAndWhereDTO((int)page, "cliente");

        var totalRecords = _db.Users.Join(_db.Rols, us => us.rolForeikey, r => r.Id,
        (us, r) => new { r.rolName })
        .Where(x => x.rolName == "cliente")
        .Count();
        return Ok(new PagedResponse<IEnumerable<UserDTO>>(
            pagedData, totalRecords / 1, (int)page));
    }

    [HttpGet("rol")]
    public IActionResult GetAllRol()
    {
        var rol = _userRepository.GetAllRol();
        return Ok(rol);
    }

    [HttpPut("{id}")]
    public IActionResult Update(Guid id, UpdateRequest model)
    {
        _userRepository.Update(id, model);
        return Ok(new { message = "User updated successfully" });
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        _userRepository.Delete(id);
        return Ok(new { message = "User deleted successfully" });
    }
}