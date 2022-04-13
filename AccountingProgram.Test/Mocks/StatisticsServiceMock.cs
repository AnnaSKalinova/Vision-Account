namespace AccountingProgram.Test.Mocks
{
    using AccountingProgram.Services.Statistics;
    using Moq;

    public static class StatisticsServiceMock
    {
        public static IStatisticsService Instance
        {
            get
            {
                var statisticsServiceMock = new Mock<IStatisticsService>();

                statisticsServiceMock
                    .Setup(s => s.Total())
                    .Returns(new StatisticsServiceModel
                    {
                        TotalCustomers = 5,
                        TotalDrivers = 4,
                        TotalItems = 7,
                        TotalSalesInvoices = 10
                    });

                return statisticsServiceMock.Object;
            }
        }
    }
}
