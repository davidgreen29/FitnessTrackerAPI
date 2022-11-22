using Microsoft.AspNetCore.Identity;
using trackerApi.Models.Users;

namespace trackerApi.Contracts
{
    public interface IAuthManager
    {

        Task<IEnumerable<IdentityError>> Register(ApiUserDto userDto);
        
        Task<AuthResponseDto> Login(LoginDto loginDto);
        Task<string> CreateRefreshToken();
        Task<AuthResponseDto> VerifyRefreshToken(AuthResponseDto request);


    }
}
