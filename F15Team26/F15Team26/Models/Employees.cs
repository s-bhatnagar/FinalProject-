using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace F15Team26.Models
{
    public class Employees
    {
        public int EmployeesID { get; set; }
        public String EmpNumber { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public String FName { get; set; }

        [StringLength(1)]
        [Display(Name = "Middle Initial")]
        public String MI { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public String LName { get; set; }

        [Required]
        [EmailAddress]
        public String Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public String Password { get; set; }

        [Required]
        public String Address { get; set; }

        [Required]
        [DataType(DataType.PostalCode)]
        public String Zipcode { get; set; }

        [Required]
        [Phone]
        public String Phone { get; set; }

       
        public enum EmployeeType
        {
            Employee,
            Manager
        };

        [Required]
        public EmployeeType EmployeeTypes { get; set; }

    }
}