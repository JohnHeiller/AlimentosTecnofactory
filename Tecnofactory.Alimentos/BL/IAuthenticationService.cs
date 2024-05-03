using Tecnofactory.Alimentos.DTO;

namespace Tecnofactory.Alimentos.BL
{
    public interface IAuthenticationService
    {
        Task<string> Register(RegisterRequestDto request);
        Task<string> Login(LoginRequestDto request);
    }
}
