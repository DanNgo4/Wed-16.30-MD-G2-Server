using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Wed_16._30_MD_G2_Server.Controllers;

namespace ApiTests
{
    [TestClass]
    public class MathControllerTests
    {
        [TestMethod]
        public void Sum_ReturnsCorrectResult()
        {
            var mockLogger = new Mock<ILogger<MathController>>();
            var controller = new MathController(mockLogger.Object);

            var result = controller.Get(5, 11);

            var okResult = result.Result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(16, okResult.Value);
        }

        [TestMethod]
        public void Health_ReturnsHealthyMessage()
        {
            var mockLogger = new Mock<ILogger<MathController>>();
            var controller = new MathController(mockLogger.Object);

            var result = controller.Health();

            var okResult = result.Result as OkObjectResult ?? new OkObjectResult(result.Value);
            Assert.AreEqual("Service is healthy", okResult.Value);
        }
    }
}
