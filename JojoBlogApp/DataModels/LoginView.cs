using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MiniProjectApp.DataModels
{
    public class LoginView
    {

        [Required(ErrorMessage = "UserName is required to login")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password must be typed")]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}
