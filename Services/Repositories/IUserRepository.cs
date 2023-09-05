using Cadeteria.DTOs;
using Cadeteria.Models;

namespace Cadeteria.Services;

public interface IUserRepository
{
    AuthenticateResponse Authenticate(AuthenticateRequest model);
    IEnumerable<User> GetAll();
    IEnumerable<Rol> GetAllRol();
    User GetById(Guid id);
    void Register(RegisterRequest model);
    void Update(Guid id, UpdateRequest model);
    void Delete(Guid id);
    List<JoinResponse> GetUserJoin(int page);
    List<JoinResponse> GetUserJoinAndWhere(int page, string condicion);
    // UserDTO AuthenticateDTO(AuthenticateRequest model);
    List<UserDTO> GetUserJoinAndWhereDTO(int page, string condicion);
    List<UserDTO> GetUserJoinDTO(int page);


}