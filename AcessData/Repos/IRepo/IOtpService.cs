using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessData.Repos.IRepo
{
    public interface IOtpService
    {
      
            Task<string> GenerateOtpAsync(string userId);
            Task<bool> VerifyOtpAsync(string userid, string otpCode);
       
    }
}
