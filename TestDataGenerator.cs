using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public static class TestDataGenerator
    {
        public static List<User> GenerateUsers(int count)
        {
            var faker = new Faker<User>()
                .RuleFor(u => u.Id, f => f.IndexFaker + 1)
                .RuleFor(u => u.Name, f => f.Name.FullName())
                .RuleFor(u => u.Email, f => f.Internet.Email());

            return faker.Generate(count);
        }
    }
}
