namespace AccountingProgram.Test.Controllers.Api
{
    using AccountingProgram.Controllers.Api;
    using AccountingProgram.Test.Mocks;
    using Xunit;

    public class StatisticsApiControllerTest
    {
        [Fact]
        public void GetStatisticsShouldReturnTotalStatistics()
        {
            //Arrange
            var statisticsController = new StatisticsApiController(StatisticsServiceMock.Instance);

            //Act
            var result = statisticsController.GetStatistics();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(5, result.TotalCustomers);
            Assert.Equal(4, result.TotalDrivers);
            Assert.Equal(7, result.TotalItems);
            Assert.Equal(10, result.TotalSalesInvoices);

        }
    }
}
