using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OITReporting.Manager
{
    class userReg
    {
        [Required]
        [Display(Name = "Name")]
        public string  firstname{ get; set; }
        [Required]
        [Display(Name = "Name")]
        public string lastname{ get; set; }
        [Required]
        [Display(Name = "Email id")]
        [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z",
        ErrorMessage = "Please enter correct email address")]
        public string emailid{ get; set; }
        [Display(Name = "Password")]

        [DataType(DataType.Password)]

        [Required(ErrorMessage = "Password required")]
        public string Userpassword { set; get; }
        [Display(Name = "Confirm new password")]
        [Required(ErrorMessage = "Enter Confirm Password")]
        [Compare("Userpassword", ErrorMessage = "The password and confirmation password do not match.")]
        [DataType(DataType.Password)]
        public string c_pwd { get; set; }
    }
}
