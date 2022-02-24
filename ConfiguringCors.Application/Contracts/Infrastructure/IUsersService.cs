using ConfiguringCors.Domain;

namespace ConfiguringCors.Application.Contracts.Infrastructure
{
    public interface IUsersService
    {
        IEnumerable<User> GetAll();
    }
}