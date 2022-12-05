using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MiniProjectApp.DataModels
{
    public class UserDetailsVN
    {
        public int UserId { get; set; }
        [Required(ErrorMessage = "Name is mandatory")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Username is mandatory")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Address is mandatory")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Email is mandatory")]
        [EmailAddress(ErrorMessage = "Email is not in a proper format")]
        public string email { get; set; }
        [Required(ErrorMessage = "password is mandatory")]
        [RegularExpression(@"(?=^.{9,}$)((?=.*\d)|(?=.*\W+))(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$", ErrorMessage = "Password should be minimum of 7 characters with atleast 1 special characters,1 number and one atleast UpperCase")]
        [MinLength(9, ErrorMessage = "Should contain atleast 9 characters")]
        [MaxLength(50, ErrorMessage = "Should contain max 0f 50 characters")]
        [DataType(DataType.Password)]
        public string password { get; set; }
        [Required(ErrorMessage = "Retype the password")]
        [DataType(DataType.Password)]
        public string RetypePassword { get; set; }
        [Required(ErrorMessage = "Mobile no is mandatory")]
        public long mobileNo { get; set; }
    }
}