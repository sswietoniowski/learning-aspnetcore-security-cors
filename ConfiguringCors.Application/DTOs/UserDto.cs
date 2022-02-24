using ConfiguringCors.Application.DTOs.Common;

namespace ConfiguringCors.Application.DTOs
{
    public class UserDto : BaseDto
    {
        public string Name { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public string Biography { get; set; } = default!;
        public string DomainName { get; set; } = default!;
        public string UserType { get; set; } = default!;
        public int Scoring { get; set; } = default!;
    }
}
