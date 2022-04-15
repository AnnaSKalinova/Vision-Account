namespace AccountingProgram.Services.Accountants
{
    using System.Collections.Generic;
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

        public int GetIdByUser(string userId)
        {
            return this.data
                .Accountants
                .Where(a => a.UserId == userId)
                .Select(a => a.Id)
                .FirstOrDefault();
        }

        public void AddAccountant(User user)
        {
            var accountantData = new Accountant
            {
                Name = user.FullName,
                Email = user.Email,
                UserId = user.Id,
                SalesInvoices = new HashSet<SalesInvoice>()
            };

            this.data
                .Accountants
                .Add(accountantData);

            this.data.SaveChanges();
        }

        public bool IsUserAccountant(string userId)
        {
            return this.data
                .Users
                .Any(u => u.Id == userId && u.IsAccountant);
        }
    }
}
