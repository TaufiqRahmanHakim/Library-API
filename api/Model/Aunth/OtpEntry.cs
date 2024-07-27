using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Model.Aunth
{
    public class OtpEntry
    {
        public string Otp { get; set; }
        public DateTime ExpiryTime { get; set; }
    }
}