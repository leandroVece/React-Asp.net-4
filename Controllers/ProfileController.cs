using AutoMapper;
using Cadeteria.Authorization;
using Cadeteria.DTOs;
using Cadeteria.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cadeteria;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ProfileController : ControllerBase
{
    private readonly IProfileRepository _dbProfile;
    private readonly DataContext _db;
    private readonly IMapper _mapper;
    private readonly ILogger<ProfileController> _logger;


    public ProfileController(ILogger<ProfileController> logger, IMapper mapper,
     DataContext db, IProfileRepository Profile)
    {
        _dbProfile = Profile;
        _db = db;
        _logger = logger;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_dbProfile.Get());

    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetById(Guid id)
    {

        var response = _dbProfile.GetById(id);

        if (response.Profile?.archivo != null)
        {
            if (System.IO.File.Exists(response.Profile?.archivo.Foto))
            {

                var path = response.Profile.archivo.Foto;
                using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    using (var ms = new MemoryStream())
                    {
                        await fs.CopyToAsync(ms);
                        response.Profile.archivo.img = ms.ToArray();
                    }
                }
            }
        }
        return Ok(response);
    }

    [HttpPost]
    public IActionResult Post([FromBody] ProfileDTO Profile)
    {
        var response = _mapper.Map<Models.Profile>(Profile);
        _dbProfile.Save(response);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody] ProfileDTO Profile)
    {
        var response = _mapper.Map<Models.Profile>(Profile);
        _dbProfile.Update(id, response);
        //_dbProfile.Save(Profile);
        return Ok();
    }

}
