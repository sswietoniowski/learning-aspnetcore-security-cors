using ConfiguringCors.Application.Contracts.Infrastructure;
using ConfiguringCors.Domain;

namespace ConfiguringCors.Infrastructure
{
    public class FakerUserGenerator : IUserGenerator
    {
        private const int _BIO_SENTENCES_COUNT = 3;
        private const int _MIN_SCORING = 0;
        private const int _MAX_SCORING = 1000;

        public User Generate()
        {
            var user = new User
            {
                Id = Guid.NewGuid().ToString()
            };

            user.FirstName = Faker.Name.First();
            user.LastName = Faker.Name.Last();
            user.Website = Faker.Internet.DomainName();
            user.Email = Faker.Internet.Email(user.Name);
            user.PhoneNumber = Faker.Phone.Number();
            user.Biography = String.Join(" ", Faker.Lorem.Sentence(_BIO_SENTENCES_COUNT));
            user.UserType = Faker.Enum.Random<UserType>();
            user.Scoring = Faker.RandomNumber.Next(_MIN_SCORING, _MAX_SCORING);

            return user;
        }
    }
}
