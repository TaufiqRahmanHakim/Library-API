using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace api.Model
{
    public class User : IdentityUser
    {
        public string? Initials { get; set; }
    }
}