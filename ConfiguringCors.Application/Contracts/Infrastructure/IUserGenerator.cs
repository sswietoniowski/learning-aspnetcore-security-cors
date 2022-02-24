using ConfiguringCors.Domain;

namespace ConfiguringCors.Application.Contracts.Infrastructure
{
    public interface IUserGenerator
    {
        User Generate();
    }
}
