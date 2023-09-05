//using System.Data.SQLite;
//using AutoMapper;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Cadeteria.DTOs;
using Cadeteria.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Cadeteria;

public class ProfileRepository : IProfileRepository
{

    DataContext context;
    private readonly IMapper _mapper;
    public ProfileRepository(DataContext dbContext, IMapper mapper)
    {
        context = dbContext;
        _mapper = mapper;
    }

    public IEnumerable<Models.Profile> Get()
    {
        return context.Profile;
    }

    public UserDTO GetById(Guid id)
    {
        var response = context.Users.ProjectTo<UserDTO>(_mapper.ConfigurationProvider)
        .Where(x => x.Id == id)
        .SingleOrDefault();
        return response;
    }

    public async Task Save(Models.Profile profile)
    {
        context.Profile.Add(profile);
        await context.SaveChangesAsync();
    }


    public async Task Update(Guid id, Models.Profile profile)
    {
        var profileAux = context.Profile.Find(id);

        if (profileAux != null)
        {
            profileAux.Nombre = profile.Nombre;
            profileAux.Direccion = profile.Direccion;
            profileAux.Telefono = profile.Telefono;

            await context.SaveChangesAsync();
        }

    }

    public async Task Delete(Guid id)
    {
        var profileAux = context.Profile.Find(id);

        if (profileAux != null)
        {
            context.Remove(profileAux);
            await context.SaveChangesAsync();
        }

    }

}