using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asp.MVCCoreWeb.Models
{
    public class LoginModel
    {
        [DisplayName("User Name")]
        [Required]
        [Phone]
       
        public string UserName { get; set; }
        [DisplayName("Password")]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("Stay Login")]
        public bool RemeberMe { get; set; }

    }
}
