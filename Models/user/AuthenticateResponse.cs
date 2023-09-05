namespace Cadeteria.Models;

public class AuthenticateResponse
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string Rol { get; set; }
    public Guid? id_profile { get; set; }
    public string Token { get; set; }
}


