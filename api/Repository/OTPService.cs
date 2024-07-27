using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Interface;
using api.Model.Aunth;

namespace api.Repository
{
    public class OTPService : IOTPService
    {
        private readonly Dictionary<string, OtpEntry> _otpStore = new Dictionary<string, OtpEntry>();
        private readonly TimeSpan _otpLifespan = TimeSpan.FromMinutes(5); // OTP valid for 5 minutes

    public string GenerateOTP(string email)
    {
        var otp = new Random().Next(100000, 999999).ToString(); // Generate 6-digit OTP
        var otpEntry = new OtpEntry
        {
            Otp = otp,
            ExpiryTime = DateTime.UtcNow.Add(_otpLifespan)
        };
        _otpStore[email] = otpEntry;
        // Send OTP to user's email (omitted for brevity)
        return otpEntry.Otp;
    }

    public bool ValidateOTP(string email, string inputOtp)
    {
        if (_otpStore.TryGetValue(email, out OtpEntry storedOtp))
        {
            if (storedOtp.Otp == inputOtp && storedOtp.ExpiryTime > DateTime.UtcNow)
            {
                _otpStore.Remove(email); // Hapus OTP setelah validasi
                return true;
            }
        }

        return false;
    }
    }
}