using ConfiguringCors.Application.Contracts.Infrastructure;
using ConfiguringCors.Domain;

namespace ConfiguringCors.Infrastructure
{
    public class UsersService : IUsersService
    {
        private readonly IUserGenerator _userGenerator;

        public UsersService(IUserGenerator userGenerator)
        {
            this._userGenerator = userGenerator;
        }

        public IEnumerable<User> GetAll()
        {
            while (true)
            {
                yield return _userGenerator.Generate();
            }
        }
    }
}