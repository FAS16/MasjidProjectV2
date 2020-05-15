using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MasjidProjectV2.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Husk mig")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Email skal udfyldes")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password skal udfyldes")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Gentag password skal udfyldes")]
        [DataType(DataType.Password)]
        [Display(Name = "Gentag password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Fornavn skal udfyldes")]
        [StringLength(55, ErrorMessage = "Udfyld fornavn", MinimumLength = 2)]
        [Display(Name = "Fornavn")]
        public string FirstName { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Efternavn skal udfyldes")]
        [StringLength(55, ErrorMessage = "Udfyld efternavn", MinimumLength = 2)]
        [Display(Name = "Efternavn")]
        public string LastName { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Telefonnr. skal udfyldes")]
        [StringLength(20, ErrorMessage = "Udfyld telefonnr.", MinimumLength = 6)]
        [Display(Name = "Telefonnr.")]
        public string PhoneNumber { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "By skal udfyldes")]
        [StringLength(55, ErrorMessage = "Udfyld by", MinimumLength = 1)]
        [Display(Name = "By")]
        public string City { get; set; }

        [DataType(DataType.Text )]
        [Required(ErrorMessage = "Postnummer skal udfyldes")]
        [StringLength(4, ErrorMessage = "Postnummer skal bestå af fire tal", MinimumLength = 4)]
        [Display(Name = "Postnummer")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Postnr. kan kun bestå af tal.")]
        public string ZipCode { get; set; }

        [DataType(DataType.DateTime)]
        [Required]
        [Display(Name = "Fødselsdag")]
        public DateTime DateOfBirth { get; set; }

        public RegisterViewModel()
        {
            DateOfBirth = new DateTime(200, 1, 1);
        }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Gentag password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
