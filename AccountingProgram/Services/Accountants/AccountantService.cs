namespace AccountingProgram.Services.Accountants
{
    using System.Linq;

    using AccountingProgram.Data;
    using AccountingProgram.Data.Models;

    public class AccountantService : IAccountantService
    {
        private readonly AccountingDbContext data;

        public AccountantService(AccountingDbContext data)
        {
            this.data = data;
        }

        public int Create(string accountantName, string phoneNumber, string userId)
        {
            var accountantData = new Accountant
            {
                Name = accountantName,
                PhoneNumber = phoneNumber,
                UserId = userId
            };

            this.data.Accountants.Add(accountantData);

            this.data.SaveChanges();

            return accountantData.Id;
        }

        public int GetIdByUser(string userId)
        {
            return this.data
                .Accountants
                .Where(a => a.UserId == userId)
                .Select(a => a.Id)
                .FirstOrDefault();
        }

        public bool UserIsAlreadyAccountant(string userId)
        {
            return this.data
                .Accountants
                .Any(a => a.UserId == userId);
        }
    }
}
