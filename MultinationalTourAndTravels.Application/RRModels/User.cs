using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultinationalTourAndTravels.Application.RRModels
{
    public record UserRequest(string Email,string Password);
    public record UserResponse(string Email,Guid Id);
    public record LoginRequest(string Email,string Password);
    public record LoginResponse(string Token);
    public record ChangePasswordRequest(string OldPassword,string NewPassword);
    public record ForgotPasswordRequest(string Email);
    public record ResetPasswordRequest(string Email, string ResetCode, string NewPassword);
}
