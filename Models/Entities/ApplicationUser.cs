using Microsoft.AspNetCore.Identity;

namespace Models.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public required string Name { get; set; }
        public int ChildrenCount { get; set; }

        public virtual ICollection<Child> Children { get; set; }
    }
}