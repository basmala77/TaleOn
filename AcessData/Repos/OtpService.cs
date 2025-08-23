using AccessData.Repos.IRepo;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessData.Repos
{
    public class OtpService : IOtpService
    {
        private readonly IDistributedCache _cache;
        private readonly Random _random = new();
        public OtpService(IDistributedCache cache)
        {
            _cache = cache;
        }
        public async Task<string> GenerateOtpAsync(string userId)
        {
            var otp = _random.Next(100000, 999999).ToString();
            var key = $"TaleOnApp:EmailVerification:{userId}";
            await _cache.SetStringAsync(key, otp, new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
            });
            return otp;
        }

        public async Task<bool> VerifyOtpAsync(string userId, string otpCode)
        {
            var key = $"TaleOnApp:EmailVerification:{userId}";
            var storedOtp = await _cache.GetStringAsync(key);
            return storedOtp == otpCode;
        }
    }
}

