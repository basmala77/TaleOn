using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Models.Entities
{
    public class Child
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public string ParentId { get; set; }
        public  ApplicationUser Parent { get; set; }

        public int ImageId { get; set; }

        // Navigation property
        [ForeignKey("ImageId")]
        public Image Image { get; set; }
    }
    [Table("Images")]
    public class Image
    {
        public int Id { get; set; }
        [NotMapped]
        public IFormFile File { get; set; }
        public string FileName { get; set; }
        public string FileExtension { get; set; }
        public long FileSize { get; set; }
        public string FilePath { get; set; }

    }
}
