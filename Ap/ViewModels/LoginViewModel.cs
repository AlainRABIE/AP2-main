using System.ComponentModel.DataAnnotations;
namespace ASPBookProject.ViewModels
{
    public class LoginViewModel
    {

        
            [Required(ErrorMessage = "L'identifiant est requis")]
            public string? UserName { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string? Password { get; set; }

            [Display(Name = "Se souvenir de moi?")]
            public bool RememberMe { get; set; }
        }
    }

