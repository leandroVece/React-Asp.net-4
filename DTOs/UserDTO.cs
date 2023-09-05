namespace Cadeteria.DTOs;

public class UserDTO
{
    public Guid Id { get; set; }
    public string userName { get; set; }
    public virtual ProfileDTO? Profile { get; set; }
    public virtual RolDTO rol { get; set; }

}
