using Microsoft.AspNetCore.Identity;
using OnSchoolLine.Data;
using OnSchoolLine.Models;
using System.Threading.Tasks;

namespace OnSchoolLine.Services
{
    public interface IUserService
    {
        public Task<AuthenticationResponse> RegisterUser(AuthenticationRequest authenticationRequest);

        public Task<AuthenticationResponse> LoginAction(AuthenticationRequest authenticationRequest);
    }

    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;

        public UserService(
            UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<AuthenticationResponse> LoginAction(AuthenticationRequest authenticationRequest)
        {
            var user = await _userManager.FindByNameAsync(authenticationRequest.UserName);
            var response = new AuthenticationResponse()
            {
                Success = true
            };
            if (user == null)
            {
                response.Success = false;
                response.AddError("Username not found");

                return response;
            }

            var isValidPassword = await _userManager.CheckPasswordAsync(user, authenticationRequest.Password);
            if (!isValidPassword)
            {
                response.Success = false;
                response.AddError("Password not match");

                return response;
            }

            return response;
        }

        public async Task<AuthenticationResponse> RegisterUser(AuthenticationRequest authenticationRequest)
        {
            var userEntity = new AppUser
            {
                UserName = authenticationRequest.UserName,
                Email = authenticationRequest.Email
            };

            var result = await _userManager.CreateAsync(userEntity, authenticationRequest.Password);

            var response = new AuthenticationResponse() { Success = true };

            if (!result.Succeeded)
            {
                response.Success = false;

                foreach (var error in result.Errors)
                {
                    response.AddError(error.Description);
                }
            }

            return response;
        }
    }
}