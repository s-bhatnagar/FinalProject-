using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace F15Team26.Models
{
   
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
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        //DONE
        [Required]
        [Display(Name = "First Name")]
        public string FName { get; set; }

        [Display(Name = "Middle Initial")]
        public string MI { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        public string LName { get; set; }

        [Display(Name = "Address")]
        [Required]
        public string Address { get; set; }

        [Required]
        [Display(Name = "City")]
        public string City { get; set; }

         //Register states
        public enum State
        {
            Alabama, Alaska, Arizona, Arkansas, 
            California, Colorado, Connecticut, Delaware, 
            Florida, Georgia, Hawaii, Idaho, Illinois, Indiana, Iowa, 
            Kansas, Kentucky, Louisiana, 
            Maine, Maryland, Massachusetts, Michigan, Minnesota, Mississippi, Missouri, Montana, 
            Nebraska, Nevada, 
          [Display(Name="New Hampshire")]
            NewHampshire,
          [Display(Name="New Jersey")]
            NewJersey,
          [Display(Name="New Mexico")]
            NewMexico,
          [Display(Name="New York")]
            NewYork,
           [Display(Name="North Carolina")]
            NorthCarolina,
[Display(Name="North Dakota")]
            NorthDakota,
Ohio, Oklahoma, Oregon, Pennsylvania ,
[Display(Name="Rhode Island")]
            RhodeIsland,
[Display(Name="South Carolina")]
            SouthCarolina,
 [Display(Name="South Dakota")]
            SouthDakota,
Tennessee, Texas, Utah, Vermont, Virginia, Washington ,
[Display(Name="West Virginia")]
WestVirginia,
Wisconsin, Wyoming
        }
        [Required]
        public State? States { get; set; }

        [Display(Name = "Zipcode")]
        [Required]
        [DataType(DataType.PostalCode)]
        public string Zipcode { get; set; }

        [Display(Name = "Phone Number")]
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Display(Name = "Credit Card")]
        [Required]
        [CreditCard]
        public string CreditCard1 { get; set; }

        public enum CreditCard_Type
        {
            [Display(Name = "Amercian Express")]
            AmericanExpress,
            Discover,
            MasterCard,
            Visa
        };
        [Display(Name = "Credit Card Type")]
        [Required]
        public CreditCard_Type CreditCard1Type { get; set; }

        [Display(Name = "Additional Credit Card")]
        [CreditCard]
        public string CreditCard2 { get; set; }

        public CreditCard_Type CreditCard2Type { get; set; }

        [Display(Name = "Additional Credit Card")]
        [CreditCard]
        public string CreditCard3 { get; set; }

        public CreditCard_Type CreditCard3Type { get; set; }

        
       
       
        
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
        [Display(Name = "Confirm password")]
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
