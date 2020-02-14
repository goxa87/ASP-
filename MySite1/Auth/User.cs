using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity;

namespace MySite1.Auth
{
    public class User : IdentityUser
    {        
        public string Pseudonym { get; set; }

        public string Organization { get; set; }
    }
}
