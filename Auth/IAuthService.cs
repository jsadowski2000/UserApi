using UserApi.Dtos;

namespace UserApi.Interface{

public interface IAuthService
{
    Task<string> Authenticate(UserLoginDto userLoginDto);
}
}
