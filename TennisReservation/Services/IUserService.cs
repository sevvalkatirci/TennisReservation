using TennisReservation.Models;

namespace TennisReservation.Services
{
    public interface IUserService
    {
        Task<bool> RegisterUserAsync(RegisterRequest request);
        Task<User> LoginUserAsync(LoginRequest request);
    }
}
