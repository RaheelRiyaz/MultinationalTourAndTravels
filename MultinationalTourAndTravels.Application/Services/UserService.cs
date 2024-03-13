using AutoMapper;
using MultinationalTourAndTravels.Application.Abstractions.IContextService;
using MultinationalTourAndTravels.Application.Abstractions.IRepository;
using MultinationalTourAndTravels.Application.Abstractions.IServices;
using MultinationalTourAndTravels.Application.Abstractions.ITokenService;
using MultinationalTourAndTravels.Application.RRModels;
using MultinationalTourAndTravels.Application.Utlis;
using MultinationalTourAndTravels.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultinationalTourAndTravels.Application.Services
{
    public class UserService : IUserService 
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;
        private readonly ITokenService tokenService;
        private readonly IContextService contextService;

        public UserService(IUserRepository userRepository, IMapper mapper, ITokenService tokenService, IContextService contextService)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
            this.tokenService = tokenService;
            this.contextService = contextService;
        }



        public async Task<APIResponse<int>> ChangePassword(ChangePasswordRequest model)
        {
            var user = await userRepository.FirstOrDefaultAsync(_ => _.Id == contextService.GetUserId());
            if (user is null) 
                return APIResponse<int>.ErrorResponse("You are not authorized");

            if (!AppEncryption.ComparePassword(user.Password, user.Salt, model.OldPassword)) return APIResponse<int>.ErrorResponse("Invalid credentials");

            user.Password = AppEncryption.GenerateHashedPassword(user.Salt, model.NewPassword);
            var updatedRes = await userRepository.UpdateAsync(user);

            if (updatedRes > 0) 
                return APIResponse<int>.SuccessResponse("Password changed successfully");

            return APIResponse<int>.ErrorResponse(); 
        }



        public async Task<APIResponse<LoginResponse>> Login(LoginRequest model)
        {
            var user = await userRepository.FirstOrDefaultAsync(_ => _.Email == model.Email);

            if (user is null) 
                return APIResponse<LoginResponse>.ErrorResponse("Invalid credentials");

            var isPasswordValid = AppEncryption.ComparePassword(user.Password, user.Salt, model.Password);

            if(!isPasswordValid) 
                return APIResponse<LoginResponse>.ErrorResponse("Invalid credentials");

            var loginResponse = new LoginResponse(tokenService.GenerateToken(user) );

            return APIResponse<LoginResponse>.SuccessResponse(result:loginResponse);
        }



        public async Task<APIResponse<UserResponse>> Signup(UserRequest model)
        {
            var emailExists = await userRepository.IsExistAsync(_ => _.Email == model.Email);

            if (emailExists)
                return APIResponse<UserResponse>.ErrorResponse("Email is alredy taken");

            var user = mapper.Map<User>(model);
            user.Salt = AppEncryption.GenerateSalt();
            user.Password = AppEncryption.GenerateHashedPassword(user.Salt, model.Password);

            var dbResponse = await userRepository.AddAsync(user);

            if (dbResponse > 0)
                return APIResponse<UserResponse>.SuccessResponse(message:"Signed up successfully", result:mapper.Map<UserResponse>(user));

            return APIResponse<UserResponse>.ErrorResponse();
        }
    }
}
