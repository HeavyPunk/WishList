using System.ComponentModel.DataAnnotations;

namespace Wishlist.Models;

public class RegisterModel
{
    [Required]
    [Display(Name = "Логин")]
    public string Login { get; set; }
    
    [Required]
    [DataType(DataType.Password)]
    [Display(Name = "Пароль")]
    public string Password { get; set; }
    
    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }
}