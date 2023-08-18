using Microsoft.EntityFrameworkCore;
using NSubstitute;
using Patas.Em.Harmonia.Domain.Models;
using Patas.Em.Harmonia.Infrastructure.Data;
using Patas.Em.Harmonia.Infrastructure.Data.Context;
using Patas.Em.Harmonia.Infrastructure.Data.Interfaces;
using Patas.Em.Harmonia.Infrastructure.Data.Models;
using Xunit;

namespace Patas.Em.Harmonia.Tests.Repositories
{
    public class UserRepositoryTests
    {
        private readonly DbContextOptions<PatasDBContext> _dbContextOptions;
        private readonly IRepositoryBase _repositoryBase;
        private const string EMAIL_SUCCESS_MOCK = "email@email.com";

        public UserRepositoryTests()
        {
            var databaseName = $"partnerDb_${DateTime.Now.ToFileTimeUtc()}";
            _dbContextOptions = new DbContextOptionsBuilder<PatasDBContext>().UseInMemoryDatabase(databaseName).Options; ;
            _repositoryBase = Substitute.For<IRepositoryBase>();
        }

        //Get User

        [Theory]
        [InlineData(EMAIL_SUCCESS_MOCK)]
        public async Task GetUserSuccess(string email)
        {
            var repository = await CreateUserRepository();
            var response = await repository.GetUserByMail(email);

            Assert.NotNull(response);
            Assert.NotEmpty(response.Email);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("batata")]
        public async Task GetUserFailure(string email)
        {
            var repository = await CreateUserRepository();
            var response = await repository.GetUserByMail(email);

            Assert.Null(response);
        }

        //Create User

        [Fact]
        public async Task CreateUserSuccess()
        {
            var user = new User()
            {
                Id = 0,
                Name = "teste",
                Created = DateTime.Now,
                Email = "emailnovo@email.com",
                HasPets = true,
                Phone = "71987878787",
                Passwrd = "2023",
                Status = "Active"
            };

            var repository = await CreateUserRepository();
            var response = await repository.CreateUser(user);

            Assert.True(response);
        }

        [Fact]
        public async Task CreateUserFailure()
        {
            var user = new User()
            {
                Id = 0,
                Name = "teste",
                Created = DateTime.Now,
                Email = EMAIL_SUCCESS_MOCK,
                HasPets = true,
                Phone = "71987878787",
                Passwrd = "2023",
                Status = "Active"
            };

            var repository = await CreateUserRepository();
            var response = await repository.CreateUser(user);

            Assert.False(response);
        }

        //Change User
        [Fact]
        public async Task ChangeUserSuccess()
        {
            var user = new UserBaseData()
            {
                Name = "teste2",
                Email = EMAIL_SUCCESS_MOCK,
                HasPets = true,
                Phone = "71987878787",
                Status = "Active"
            };

            var repository = await CreateUserRepository();
            var response = await repository.ChangeUserData(user);

            Assert.NotNull(response);
            Assert.Same(user.Email, response.Email);
            Assert.Same(user.Name, response.Name);
        }

        [Fact]
        public async Task ChangeUserFailure()
        {
            var user = new UserBaseData()
            {
                Name = "teste",
                Email = "emailnovo@email.com",
                HasPets = true,
                Phone = "71987878787",
                Status = "Active"
            };

            var repository = await CreateUserRepository();
            var response = await repository.ChangeUserData(user);

            Assert.NotNull(response);
            Assert.Null(response.Email);
        }

        //Delete User

        [Theory]
        [InlineData(EMAIL_SUCCESS_MOCK)]
        public async Task DeleteUserSuccess(string email)
        {
            var repository = await CreateUserRepository();
            var response = await repository.DeleteUserByEmail(email);

            Assert.True(response);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("batata")]
        [InlineData("rod@test.com")]
        public async Task DeleteUserFailure(string email)
        {
            var repository = await CreateUserRepository();
            var response = await repository.DeleteUserByEmail(email);

            Assert.False(response);
        }


        private async Task<UserRepository> CreateUserRepository()
        {
            var context = new PatasDBContext(_dbContextOptions);
            await PopulateDataAsync(context);

            return new  UserRepository(_repositoryBase, context);
        }

        private async Task PopulateDataAsync(PatasDBContext context)
        {
            var users = new User()
            {
                Id = 0,
                Name = "teste",
                Created = DateTime.Now,
                Email = EMAIL_SUCCESS_MOCK,
                HasPets = true,
                Phone = "71987878787",
                Passwrd = "2023",
                Status = "Active"
            };

            await context.Users.AddAsync(users);
            await context.SaveChangesAsync();
        }
    }
}
