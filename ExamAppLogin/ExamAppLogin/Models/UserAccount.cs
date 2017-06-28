using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ExamAppLogin.Models
{
    public class UserAccount
    {
        [Key]
        public int UserID { get; set; }
        
        [Required(ErrorMessage ="Harap isi")]
        public string FirstName { get; set; }

        [Required(ErrorMessage ="Harap isi")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Harap isi")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter a valid e-mail adress")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Harap isi")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Harap isi")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Harap isi")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

    }
}