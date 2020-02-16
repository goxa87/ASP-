using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MySite1.ViewModels
{
    public class AdminAddWork
    {
        [Required]
        public string Title { get; set; }

        public string Description { get; set; }
        [Required]
        public IFormFile Archive { get; set; }

        public List<IFormFile> pictures { get; set; }

    }
}
