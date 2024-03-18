using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NutriaryWebApp.BLL.DTOs
{
    public class CreateUserDTO
    {
        [Required]
        public string username { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }
        [NotMapped]
        [Required]
        [DataType(DataType.Password)]
        [CompareAttribute("password", ErrorMessage = "Password doesn't match.")]
        public string confirmpassword { get; set; }
        [Required]
        public string firstname { get; set; }
        [Required]
        public string lastname { get; set; }
    }
}
