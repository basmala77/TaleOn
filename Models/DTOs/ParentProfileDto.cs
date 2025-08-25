using Microsoft.AspNetCore.Http;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs
{
    public class ParentProfileDto
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string? ImageUrl { get; set; }
        public ICollection<Child>? Childrens { get; set; }
    }
}
