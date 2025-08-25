using AccessData.Repos;
using AccessData.Repos.IRepo;
using AutoMapper;
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
        public readonly IMapper _mapper;
        public ParentService(IUserRepos userRepos, UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _mapper = mapper;
            _userRepo = userRepos;
            _usermanger = userManager;
        }



        public async Task<ParentProfileDto> GetParentProfileAsync(string parentId)
        {
            var parent = await _usermanger.Users
           .Include(u => u.Children)
           //.ThenInclude(c => c.Image)
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
                ImageUrl = parent.ImageUrl,
                //ParentImagUrl = parent.Image != null ? parent.Image.FilePath : null,
                Childrens = parent.Children // Assuming Child is a defined class
            };
            return parentProfileDto;
        }
        public async Task<ParentProfileDto> EditParentProfileAsync(ParentProfileUpdateDto parentProfileDto)
        {
            // جلب المستخدم مع الأطفال والعلاقة بالصورة
            var parent = await _usermanger.Users
                .Include(u => u.Children)
                //.Include(u => u.Image)
                .FirstOrDefaultAsync(u => u.Id == parentProfileDto.Id);

            if (parent == null)
                throw new InvalidOperationException("Parent not found.");

            try
            {
                // نسخ القيم من DTO → Entity (ماعدا الصورة والأطفال)
                _mapper.Map(parentProfileDto, parent);

                // معالجة رفع الصورة
                if (parentProfileDto.ProfileImage != null && parentProfileDto.ProfileImage.Length > 0)
                {
                    var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
                    if (!Directory.Exists(uploadsFolder))
                        Directory.CreateDirectory(uploadsFolder);

                    var fileName = $"{Guid.NewGuid()}_{Path.GetFileName(parentProfileDto.ProfileImage.FileName)}";
                    var filePath = Path.Combine(uploadsFolder, fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await parentProfileDto.ProfileImage.CopyToAsync(stream);
                    }

                    if (parent.ImageUrl != null)
                    {
                        parent.ImageUrl = $"/uploads/{fileName}";


                        // تحديث بيانات الصورة
                        //parent.Image.FilePath = $"/uploads/{fileName}";
                        //parent.Image.FileName = fileName;
                        //    parent.Image.FileExtension = Path.GetExtension(fileName);
                        //    parent.Image.FileSize = parentProfileDto.ProfileImage.Length;
                    }
                    else
                    {
                        // إذا ما فيش Image، استخدم الحقل المستقل imageUrl
                        parent.ImageUrl = $"/uploads/{fileName}";
                    }
                }

                // تحديث البيانات في قاعدة البيانات
                var result = await _usermanger.UpdateAsync(parent);
                if (!result.Succeeded)
                {
                    var errors = string.Join("; ", result.Errors.Select(e => e.Description));
                    throw new Exception($"Failed to update parent: {errors}");
                }

                // رجع نسخة DTO بعد التعديل
                var updatedDto = _mapper.Map<ParentProfileDto>(parent);
                return updatedDto;
            }
            catch (Exception ex)
            {
                // هنا هيتأكد إن أي خطأ يترجع مفصل
                throw new Exception($"An error occurred while updating the profile: {ex.Message}", ex);
            }
        }
 

    }
}
