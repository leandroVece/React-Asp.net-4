namespace Cadeteria.Models;
public class UpdateRequest
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public Guid rolForeikey { get; set; }
}