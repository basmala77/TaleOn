using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs
{
    public class ParentProfileUpdateDto
    {
        [BindNever]
        public string? Id { get; set; }
    
        public string FullName { get; set; }
        public string Email { get; set; }
        public IFormFile? ProfileImage { get; set; }  
    }

}
