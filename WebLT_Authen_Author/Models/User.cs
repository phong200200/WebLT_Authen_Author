using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebLT_Authen_Author.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }


        [Display(Name ="First Name: ")]
        [Required(ErrorMessage ="No để trống tên")]
        public String FirstName { get; set; }

        [Display(Name = "Last Name: ")]
        [Required(ErrorMessage = "No để trống tên")]
        public String LastName { get; set; }

        [DataType(DataType.EmailAddress,ErrorMessage ="That's not an email")]
        [EmailAddress(ErrorMessage = "That's not an email")]
        [Required(ErrorMessage = "No để trống mail")]
        public String Email { get; set; }

        [Required(ErrorMessage ="No để trống")]
        public String UserName { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage ="No Để trống password")]
        public String Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Nhập cho đúng vào")]
        public String ConfirmPassword { get; set; }
        public String Fullname() { return this.FirstName + " " + this.LastName; }
    }
}