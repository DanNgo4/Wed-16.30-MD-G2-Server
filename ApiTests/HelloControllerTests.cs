using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Wed_16._30_MD_G2_Server.Controllers;

namespace ApiTests;

[TestClass]
public sealed class HelloControllerTests
{

    [TestMethod]
    [DataRow("Development")]
    [DataRow("Staging")]
    [DataRow("Production")]
    public void TestSayHello(string envName)
    {
        var env = new Mock<IWebHostEnvironment>();
        env.SetupGet(e => e.EnvironmentName)
           .Returns(envName);

        var controller = new HelloController(env.Object);

        var result = controller.Get();
        var obj = result.Result as ObjectResult;

        var message = obj?.Value;
        Assert.AreEqual($"Hello from {envName} environment!", message);
    }
}
