using System.ComponentModel.DataAnnotations;

namespace Demo.Presentation.ViewModels.AccountView
{
    public class ForgetPasswordViewModel
    {
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Email IS Required")]
        public string Email { get; set; } = null!;
    }
}
