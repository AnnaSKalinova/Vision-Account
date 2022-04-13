namespace AccountingProgram.Test.Services
{
    using AccountingProgram.Data;
    using AccountingProgram.Data.Models;
    using AccountingProgram.Services.Accountants;
    using AccountingProgram.Test.Mocks;
    using Xunit;

    public class AccountantServiceTest
    {
        private const string userId = "TestUserId";

        [Fact]
        public void IsAlreadyAccountantShouldReturnTrueIfUserIsAccountant()
        {
            //Arrange
            using var data = GetAccountantData();
            var accountantService = new AccountantService(data);

            //Act
            var result = accountantService.UserIsAlreadyAccountant(userId);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void IsAlreadyAccountantShouldReturnTrueIfUserIsNotAccountant()
        {
            //Arrange
            using var data = GetAccountantData();

            var accountantService = new AccountantService(data);

            //Act
            var result = accountantService.UserIsAlreadyAccountant("AnotherUserId");

            //Assert
            Assert.False(result);
        }

        private static AccountingDbContext GetAccountantData()
        {
            var data = DatabaseMock.Instance;
            
            data.Accountants.Add(new Accountant { UserId = userId });
            data.SaveChanges();

            return data;
        }
    }
}
