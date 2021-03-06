namespace AccountingProgram.Services.Statistics
{
    using System.Linq;

    using AccountingProgram.Data;

    public class StatisticsService : IStatisticsService
    {
        private readonly AccountingDbContext data;

        public StatisticsService(AccountingDbContext data)
        {
            this.data = data;
        }

        public StatisticsServiceModel Total()
        {
            var totalDrivers = this.data.Drivers.Count();
            var totalSalesInvoices = this.data.SalesInvoices.Count(si => si.isPosted);
            var totalItems = this.data.Items.Count();
            var totaCustomers = this.data.Customers.Count();
            var totalProfit = this.data
                .SalesInvoices
                .Sum(si => si.Profit);

            return new StatisticsServiceModel
            {
                TotalDrivers = totalDrivers,
                TotalSalesInvoices = totalSalesInvoices,
                TotalItems = totalItems,
                TotalCustomers = totaCustomers,
                TotalProfit = totalProfit
            };
        }
    }
}
