using ConfiguringCors.Domain.Common;

namespace ConfiguringCors.Domain
{
    public class User : BaseDomainEntity
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Name => $"{FirstName} {LastName}";
        public string Email { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public string Biography { get; set; } = default!;
        public string DomainName { get; set; } = default!;
        public UserType UserType { get; set; } = default!;
        public int Scoring { get; set; } = default!;
    }
}