

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

        public User CreateUser(UserCreateDto userCreateDto)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                UserName = userCreateDto.Username,
                Password = userCreateDto.Password,
                Email = userCreateDto.Email
            };

            _context.Users.Add(user); // Dodaj użytkownika do zbioru użytkowników w kontekście bazy danych
            _context.SaveChanges(); // Zapisz zmiany w bazie danych

            return user;
        }
    }
}
