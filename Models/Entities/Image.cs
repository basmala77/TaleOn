using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    [Table("Images")]
    public class Image
    {
        public int Id { get; set; }
        [NotMapped]
        public IFormFile? File { get; set; }
        public string? FileName { get; set; }
        public string? FileExtension { get; set; }
        public long? FileSize { get; set; }
        public required string FilePath { get; set; }

    }
}
