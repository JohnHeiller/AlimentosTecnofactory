using Tecnofactory.Alimentos.DTO;

namespace Tecnofactory.Alimentos.BL.Interface
{
    public interface IAuthenticationService
    {
        Task<string> Register(RegisterRequestDto request);
        Task<string> Login(LoginRequestDto request);
    }
}
