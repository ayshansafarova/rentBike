using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace Bikely.Models
{
    public class IndexViewModel
    {
        public IList<UserLoginInfo> Logins { get; set; }
        public string PhoneNumber { get; set; }
        public bool TwoFactor { get; set; }
        public bool rememberedBrowser { get; set; }
        public bool HasPassword { get; set; }

    }

    public class ManageLoginsViewModel
    {
        public IList<UserLoginInfo> CurrentLogins { get; set; }
        public IList<AuthenticationDescription> OtherLogins { get; set; }
    }

    public class FactorViewModel
    {
        public string Purpose { get; set; }
    }

    public class SetPasswordViewModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "{0} uzunlugu ən az {2} olmalıdır.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Yeni parol")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Təsdiqlənən yeni parol")]
        [Compare("NewPassword", ErrorMessage = "Əvvəl yazılan parolla təsdiqlədiyiniz parol uyğun gəlmir.")]
        public string ConfirmPassword { get; set; }
    }

    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "İndiki parol")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} uzunlugu ən az {2} olmalıdır.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Yeni parol")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Təsdiqlənən yeni parol")]
        [Compare("NewPassword", ErrorMessage = "Əvvəl yazılan parolla təsdiqlədiyiniz parol uyğun gəlmir.")]
        public string ConfirmPassword { get; set; }
    }

    public class AddPhoneNumberViewModel
    {
        [Required]
        [Phone]
        [Display(Name = "Mobil telefon nömrəsi")]
        public string Number { get; set; }
    }

    public class VerifyPhoneNumberViewModel
    {
        [Required]
        [Display(Name = "Kod")]
        public string Code { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Mobil telefon nömrəsi")]
        public string PhoneNumber { get; set; }
    }

    public class ConfigureTwoFactorViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
    }
}