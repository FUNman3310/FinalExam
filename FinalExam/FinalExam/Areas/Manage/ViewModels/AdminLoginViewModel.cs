using System.ComponentModel.DataAnnotations;

namespace FinalExam.Areas.Manage.ViewModels
{
    public class AdminLoginViewModel
    {
        [Required]
        [StringLength(maximumLength:20)]
        public string UserName { get; set;}
        [Required]
        [StringLength(maximumLength:30,MinimumLength =8), DataType(DataType.Password)]
        public string Password { get; set;}
        [Required]
        [StringLength(maximumLength:30,MinimumLength =8), DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set;}

        [Required]
        [StringLength(maximumLength:20)]
        public string Fullname { get; set;}

        [Required]
        [StringLength(maximumLength:30)]
        public string Email { get; set;}

       
    }
}
