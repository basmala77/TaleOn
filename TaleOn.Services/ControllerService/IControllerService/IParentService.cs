using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaleOn.Services.ControllerService.IControllerService
{
     public interface IParentService
     {

        public Task<ParentProfileDto> EditParentProfileAsync(ParentProfileUpdateDto parentProfileDto);
        public Task<ParentProfileDto> GetParentProfileAsync(string parentId);
     }
}
