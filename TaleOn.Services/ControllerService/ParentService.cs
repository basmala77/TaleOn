using AccessData.Repos;
using AccessData.Repos.IRepo;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Models.DTOs;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaleOn.Services.ControllerService.IControllerService;

namespace TaleOn.Services.ControllerService
{
    public class ParentService : IParentService
    {
        private IUserRepos _userRepo;
        public readonly UserManager<ApplicationUser> _usermanger;
        public ParentService(IUserRepos userRepos , UserManager<ApplicationUser>userManager)
        {
            _userRepo = userRepos;
            _usermanger = userManager;
        }

        

        public async Task<ParentProfileDto> GetParentProfileAsync(string parentId)
        {
             var parent = await _usermanger.Users
            .Include(u => u.Image)           
            .Include(u => u.Children)
            .ThenInclude(c => c.Image)    
            .FirstOrDefaultAsync(u => u.Id == parentId);



            if (parent == null)
            {
                throw new InvalidOperationException("Parent not found.");
            }
            var childrenCount = await _userRepo.GetChildrenCountAsync(parentId);
            var parentProfileDto = new ParentProfileDto
            {
                Id = parent.Id,
                UserName = parent.UserName,
                Email = parent.Email,
                FullName = parent.Name,
                ParentImagUrl = parent.Image != null ? parent.Image.FilePath : null,
                Childrens = parent.Children // Assuming Child is a defined class
            };
            return parentProfileDto;
        }









    }
}
