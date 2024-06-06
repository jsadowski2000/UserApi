

using UserApi.DTOs;

namespace UserApi.Services
{
    public class UserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public object CreateUser(UserCreateDto userCreateDto)
        {
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(userCreateDto.Password);
            var user = new User
            {
                Id = Guid.NewGuid(),
                UserName = userCreateDto.Username,
                Password = hashedPassword,
                Email = userCreateDto.Email
            };

            _context.Users.Add(user); // Dodaj użytkownika do zbioru użytkowników w kontekście bazy danych
            _context.SaveChanges(); // Zapisz zmiany w bazie danych

            return new { UserId = user.Id }; 
        }

        public async Task<object> UpdatePassword(string userId, UpdatePasswordDto updatePasswordDto)
{
    var user = await _context.Users.FindAsync(userId);
    if (user == null)
    {
        throw new ();
    }

    bool passwordMatch = BCrypt.Net.BCrypt.Verify(updatePasswordDto.oldPassword, user.Password);
    if (!passwordMatch)
    {
        throw new ();
    }

    user.Password = BCrypt.Net.BCrypt.HashPassword(updatePasswordDto.newPassword, 10);
    await _context.SaveChangesAsync();

    return new { Id = userId };
}

        
    }
}
