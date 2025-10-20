using Microsoft.AspNetCore.Mvc;
using Wed_16._30_MD_G2_Server.Controllers;
using Moq;
using Microsoft.Extensions.Logging;

namespace ApiTests;

[TestClass]
public sealed class MathControllerTests
{
    [TestMethod]
    [DataRow(1, 1, 2)]
    [DataRow(5, 7, 12)]
    [DataRow(10, 20, 30)]
    public void TestSumCalculation(int num1, int num2, int expectedResult)
    {
        var mockLogger = new Mock<ILogger<MathController>>();
        var controller = new MathController(mockLogger.Object);

        var result = controller.Get(num1, num2);
        var obj = result.Result as ObjectResult;

        Assert.AreEqual(200, obj?.StatusCode ?? 500);
        Assert.IsNotNull(obj?.Value);
        Assert.AreEqual(expectedResult, obj?.Value);
    }
}
