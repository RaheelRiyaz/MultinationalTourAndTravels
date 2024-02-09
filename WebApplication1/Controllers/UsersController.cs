using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultinationalTourAndTravels.Application;
using MultinationalTourAndTravels.Application.Abstractions.IServices;
using MultinationalTourAndTravels.Application.RRModels;

namespace MultinationalTourAndTravels.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost("signup")]
        public async Task<APIResponse<UserResponse>> Signup(UserRequest model) => await userService.Signup(model);



        [HttpPost("login")]
        public async Task<APIResponse<LoginResponse>> Login(LoginRequest model) => await userService.Login(model);


        [Authorize]
        [HttpPut("change-password")]
        public async Task<APIResponse<int>> ChangePassword(ChangePasswordRequest model) =>
            await userService.ChangePassword(model);



        [HttpPost("forgot-password")]
        public async Task<APIResponse<int>> ForgotPassword(ForgotPasswordRequest model) =>
            await userService.ForgotPassword(model);


        [HttpPost("reset-password")]
        public async Task<APIResponse<int>> ResetPassword(ResetPasswordRequest model) =>
            await userService.ResetPassword(model);
    }
}
