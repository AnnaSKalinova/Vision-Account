namespace AccountingProgram.Test.Controller
{
    using AccountingProgram.Controllers;
    using Microsoft.AspNetCore.Mvc;
    using Xunit;
    public class HomeControllerTest
    {
        [Fact]
        public void ErrorShouldReturnView()
        {
            //Arrange
            var homeController = new HomeController(null, null);

            //Act
            var result = homeController.Error();

            //Assert
            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
        }
    }
}
