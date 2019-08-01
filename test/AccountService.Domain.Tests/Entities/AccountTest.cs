
using AccountServices.Domain.Entities;
using System;
using Xunit;

namespace AccountService.Domain.Tests.Entities
{
    public class AccountTest
    {
        [Fact]
        public void IsValid_ReturnsTrue()
        {
            var account = new Account
            {
                HolderAccountName = Guid.NewGuid().ToString()
            };

            var result = account.IsValid();

            Assert.True(result);
        }

        [Fact]
        public void IsValid_ReturnsFalse()
        {
            var account = new Account
            {
                HolderAccountName = null
            };

            var result = account.IsValid();

            Assert.False(result);
        }
    }
}
