using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;
using SWCLMS.Models.Tables;
using SWCLMS.UI.Utilities;

namespace SWCLMS.UI.Models
{
    public class LoginRegistrationVM
    {
        public LoginViewModel LoginViewModel { get; set; }
        public RegisterViewModel RegisterViewModel { get; set; }
        //public List<SelectListItem> GradeLevels { get; set; }

        public LoginRegistrationVM()
        {
            LoginViewModel = new LoginViewModel();
            RegisterViewModel = new RegisterViewModel();
        }

        //public void CreateGradeLevel(List<GradeLevel> gradeLevels)
        //{
        //    GradeLevels = new List<SelectListItem>();

        //    foreach (var g in gradeLevels)
        //    {
        //        GradeLevels.Add(
        //            new SelectListItem() { Text = g.GradeLevelName, Value = g.GradeLevelID.ToString() }
        //            );
        //    }
        //}
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

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "FirstName")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "LastName")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "I am a ...")]
        public string SuggestedRole { get; set; }

        [Display(Name = "Grade Level")]
        public byte? GradeLevelID { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [System.ComponentModel.DataAnnotations.Compare("Password",
            ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public List<SelectListItem> GradeLevels { get; set; }
        public List<SelectListItem> SuggestedRoles { get; set; }
        public LmsUser LoginScreenDetailsToEdit { get; set; }


        public void PopulateSelectListItems(List<GradeLevel> gradeLevels)
        {
            GradeLevels = SelectListItemCreator.CreateFrom(gradeLevels);  //original but why is this here?
            // 6/29 why is this here??
            SuggestedRoles = new List<SelectListItem> 
            {
                new SelectListItem() { Text = "Student", Value = "Student" }, //this isn't being accessed
                new SelectListItem() { Text = "Parent", Value = "Parent" },
                new SelectListItem() { Text = "Teacher", Value = "Teacher" }
            };
       }
        
        public void CreateGradeLevel(List<GradeLevel> gradeLevels)  //similar method for CreateSuggestedRole doesn't work--SuggestedRole isn't recognized
        {
            GradeLevels = new List<SelectListItem>();

            foreach (var g in gradeLevels)
            {
                GradeLevels.Add(
                    new SelectListItem() {Text = g.GradeLevelName, Value = g.GradeLevelID.ToString()}
                    );
            }
        }
    }
}


//    public class ExternalLoginConfirmationViewModel
//    {
//        [Required]
//        [Display(Name = "Email")]
//        public string Email { get; set; }
//    }

//    public class ExternalLoginListViewModel
//    {
//        public string ReturnUrl { get; set; }
//    }

//    public class SendCodeViewModel
//    {
//        public string SelectedProvider { get; set; }
//        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
//        public string ReturnUrl { get; set; }
//        public bool RememberMe { get; set; }
//    }

//    public class VerifyCodeViewModel
//    {
//        [Required]
//        public string Provider { get; set; }

//        [Required]
//        [Display(Name = "Code")]
//        public string Code { get; set; }
//        public string ReturnUrl { get; set; }

//        [Display(Name = "Remember this browser?")]
//        public bool RememberBrowser { get; set; }

//        public bool RememberMe { get; set; }
//    }

//    public class ForgotViewModel
//    {
//        [Required]
//        [Display(Name = "Email")]
//        public string Email { get; set; }
//    }

//    
//    public class ResetPasswordViewModel
//    {
//        [Required]
//        [EmailAddress]
//        [Display(Name = "Email")]
//        public string Email { get; set; }

//        [Required]
//        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
//        [DataType(DataType.Password)]
//        [Display(Name = "Password")]
//        public string Password { get; set; }

//        [DataType(DataType.Password)]
//        [Display(Name = "Confirm password")]
//        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
//        public string ConfirmPassword { get; set; }

//        public string Code { get; set; }
//    }

//    public class ForgotPasswordViewModel
//    {
//        [Required]
//        [EmailAddress]
//        [Display(Name = "Email")]
//        public string Email { get; set; }
//    }
//}

