using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TaleOn.Services.ControllerService.ParentService;

namespace TaleOn.Services.ControllerService.IControllerService
{
     public interface IParentService
    {
        public Task<ParentProfileDto> GetParentProfileAsync(string parentId);
    }
}
