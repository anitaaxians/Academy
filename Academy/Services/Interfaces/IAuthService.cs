using Academy.DTOs;

namespace Academy.Services.Interfaces
{
    public interface IAuthService
    {
        Task<string> RegisterAsync(RegisterRequestDto dto);
        Task<string> LoginAsync(LoginRequestDto dto);
    }
}
