using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace Models.Entities
{
    public class Child
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        [ForeignKey("Parent")]
        public string ParentId { get; set; }
        [JsonIgnore]
        public  ApplicationUser Parent { get; set; }

        public int? ImageId { get; set; }

        // Navigation property
        [ForeignKey("ImageId")]
        public Image Image { get; set; }
    }

    
}
