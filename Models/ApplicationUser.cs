using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Asp.MVCCoreWeb.Models
{
    public class ApplicationUser :IdentityUser
    {
        public string PubG_UserName { get; set; }
    }
}
