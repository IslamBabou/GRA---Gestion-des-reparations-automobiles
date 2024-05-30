using GRA.Models.Dtos;

namespace GRA.App.Services.Contracts
{
    public interface IAuthService
    {
        event Action<string?>? LoginChange;

        ValueTask<string> GetJwtAsync();

        Task LogoutAsync();

        Task RegisterUser(UserForRegistrationDto userForRegistration);

        Task<DateTime> LoginAsync(UserForLoginDto userForLogin);
        Task<IEnumerable<UserDto>?> GetAllUsers();
    }
}