using MultinationalTourAndTravels.Application.RRModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultinationalTourAndTravels.Application.Abstractions.IServices
{
    public interface IUserService
    {
        Task<APIResponse<UserResponse>> Signup(UserRequest model);
        Task<APIResponse<LoginResponse>> Login(LoginRequest model);
        Task<APIResponse<int>> ChangePassword(ChangePasswordRequest model);
    }
}
