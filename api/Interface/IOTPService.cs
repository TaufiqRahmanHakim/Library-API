using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Interface
{
    public interface IOTPService
    {
        string GenerateOTP(string email);
        bool ValidateOTP(string email, string code);
    }
}