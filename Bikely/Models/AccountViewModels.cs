using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bikely.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email adres")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string calledUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string calledUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Kod")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Bu browseri xatırla")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email adres")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
		[Required]
		[Display(Name = "İstifadəçi adı")]

		public string UserName { get; set; }

		[Required]
        [DataType(DataType.Password)]
        [Display(Name = "Parol")]
        public string Password { get; set; }

        [Display(Name = "Məni yadda saxla")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
		[Required]
		[Display(Name = "Rol")]
		public string UserRoles { get; set; }

		[Required]
		[EmailAddress]
		[Display(Name = "Email adres")]
		public string Email { get; set; }

		[Required]
		[Display(Name = "İstifadəçi adı")]
		public string UserName { get; set; }

		[Required]
        [StringLength(100, ErrorMessage = "{0} uzunlugu ən az {2} olmalıdır.", MinimumLength = 6)]
        [Display(Name = "Parol")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Əvvəl yazılan parolla təsdiqlədiyiniz parol uyğun gəlmir.")]
        [Display(Name = "Təsdiqlənən parol")]
        public string ConfirmPassword { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email adres")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} uzunlugu ən az {2} olmalıdır.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Parol")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Təsdiqlənən parol")]
        [Compare("Password", ErrorMessage = "Əvvəl yazılan parolla təsdiqlədiyiniz parol uyğun gəlmir.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email adres")]
        public string Email { get; set; }
    }
}
