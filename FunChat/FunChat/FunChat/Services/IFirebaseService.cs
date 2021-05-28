using FunChat.Services;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FunChat.Services
{
    public interface IFirebaseService
    {
        Task<bool> LoginWithPhone(string phoneNo);
        Task<bool> VerifyOTPCode(string code);
    }
}
