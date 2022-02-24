using ConfiguringCors.Application.Contracts.Infrastructure;
using ConfiguringCors.Domain;
using Bogus;

namespace ConfiguringCors.Infrastructure
{
    public class BogusUserGenerator : IUserGenerator
    {
        private const int _MIN_SCORING = 0;
        private const int _MAX_SCORING = 1000;
        private const string _LOCALE = "pl";

        private Faker<User> _userFaker;

        public BogusUserGenerator()
        {
            _userFaker = new Faker<User>(locale: _LOCALE)
                .RuleFor(u => u.Id, f => Guid.NewGuid().ToString())
                .RuleFor(u => u.FirstName, f => f.Person.FirstName)
                .RuleFor(u => u.LastName, f => f.Person.LastName)
                .RuleFor(u => u.Email, f => f.Person.Email)
                .RuleFor(u => u.PhoneNumber, f => f.Person.Phone)
                .RuleFor(u => u.Biography, f => f.Lorem.Sentence())
                .RuleFor(u => u.Website, f => f.Internet.DomainName())
                .RuleFor(u => u.UserType, f => f.PickRandom<UserType>())
                .RuleFor(u => u.Scoring, f => f.Random.Int(_MIN_SCORING, _MAX_SCORING));
        }

        public User Generate()
        {
            return _userFaker.Generate();
        }
    }
}
