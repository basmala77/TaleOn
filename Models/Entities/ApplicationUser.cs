using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public required string Name { get; set; }
        [NotMapped]
        public int ChildrenCount { get; set; }
        public string? ImageUrl { get; set; } = "/images/defult.jpg";

        // one user can have one image (one to one)
        //public int? ImageId { get; set; }
        //[ForeignKey("ImageId")]
        //public Image? Image { get; set; }

        public virtual ICollection<Child>? Children { get; set; }= new List<Child>();
    }
}