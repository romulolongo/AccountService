using AccountServices.Domain.Interfaces.Repositories;
using Moq;
using System;
using Xunit;
using AccountServices.Domain.Entities;
using System.Threading.Tasks;

namespace AccountService.Domain.Tests.Services
{
    public class AccountServiceTest
    {
        private readonly AccountServices.Domain.Services.AccountServices _accountServices;

        readonly Mock<IAccountRepository> _accountRepositoryMock;

        public AccountServiceTest()
        {
            _accountRepositoryMock = new Mock<IAccountRepository>();

            _accountServices = new AccountServices.Domain.Services.AccountServices(_accountRepositoryMock.Object);
        }


        [Fact]
        public void InsertAsync_NullableEntity_ThrowsArgumentException()
        {
            var exception = Assert.ThrowsAsync<ArgumentException>(() =>
                _accountServices.InsertAsync(null)).Result;

            Assert.NotNull(exception);
            Assert.Equal("Account not Valid", exception.Message);

            _accountRepositoryMock.Verify(x => x.InsertAsync(It.IsAny<Account>()), Times.Never);

        }

        [Fact]
        public void InsertAsync_HolderAccountNameEmpty_ThrowsArgumentException()
        {
            var account = new Account();

            var exception = Assert.ThrowsAsync<ArgumentException>(() =>
                _accountServices.InsertAsync(account)).Result;

            Assert.NotNull(exception);
            Assert.Equal("Account not Valid", exception.Message);

            _accountRepositoryMock.Verify(x => x.InsertAsync(It.IsAny<Account>()), Times.Never);

        }

        [Fact]
        public void InsertAsync_Sucess()
        {
            var account = new Account()
            {
                Guid = new Guid(),
                HolderAccountName = "Wow",
                ValueBalance = 150,
                ValueLimit = 200,
                Blocked = true
            };

            _accountRepositoryMock.Setup(x => x.InsertAsync(account))
                .Returns(Task.CompletedTask);

            _accountServices.InsertAsync(account).Wait();

            _accountRepositoryMock.Verify(x => x.InsertAsync(account), Times.Once);
        }

    }
}
