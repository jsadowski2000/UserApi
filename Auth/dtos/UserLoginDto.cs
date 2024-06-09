using Swashbuckle.AspNetCore.Annotations;

using Swashbuckle.AspNetCore.Filters;


namespace UserApi.Dtos
{
    public class UserLoginDto
    {

        [SwaggerSchema(Description = "The email of the user")]
        public string Email { get; set; }

        [SwaggerSchema(Description = "The password of the user")]
        
        public string Password { get; set; }
    }
}