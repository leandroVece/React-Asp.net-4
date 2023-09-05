using System.ComponentModel.DataAnnotations;

namespace Cadeteria.Models;

public class RegisterRequest
{

    [Required]
    public string UserName { get; set; }

    [Required]
    public string Password { get; set; }


}