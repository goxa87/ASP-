using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySite1.ViewModels
{
    public class AdminIndex
    {
        public string Email { get; set; }
        public string Pseudonim { get; set; }
        public string Organization { get; set; }
        public List<string> Roles { get; set; }
    }
}
