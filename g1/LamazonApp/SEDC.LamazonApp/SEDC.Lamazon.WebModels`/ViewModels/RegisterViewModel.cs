using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SEDC.Lamazon.WebModels_.ViewModels
{
    public class RegisterViewModel
    {
        [Display(Name = "First name")]
        [Required(ErrorMessage = "Please enter first name!")]
        public string FirstName { get; set; }

        [Display(Name = "Last name")]
        [Required(ErrorMessage = "Please enter last name!")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter email!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter address name!")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please enter username!")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please enter password!")]
        public string Password { get; set; }

        [Display(Name = "Confirm password")]
        [Required(ErrorMessage = "Please confirm your password!")]
        public string ConfirmPassword { get; set; }
    }
}
