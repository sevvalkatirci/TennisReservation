using TennisReservation.Models;

namespace TennisReservation.Services.Authentication
{
    public interface ITokenService
    {
        string GenerateJwtToken(User user);
    }
}
