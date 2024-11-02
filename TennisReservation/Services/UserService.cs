using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TennisReservation.Data;
using TennisReservation.Helpers;
using TennisReservation.Models;

namespace TennisReservation.Services
{
    public class UserService : IUserService
    {
        private readonly TennisReservationContext _context;
        private readonly IConfiguration _configuration;
        public UserService(TennisReservationContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public async Task<User> LoginUserAsync(LoginRequest request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == request.Username);
            if (user == null || !PasswordHelper.VerifyPassword(request.Password, user.PasswordHash))
                return null;
            return user;
        }

        public async Task<bool> RegisterUserAsync(RegisterRequest request)
        {
            var user = new User { UserName = request.UserName, Email = request.Email, PasswordHash = PasswordHelper.HashPassword(request.Password), FirstName = request.FirstName, LastName = request.LastName };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
