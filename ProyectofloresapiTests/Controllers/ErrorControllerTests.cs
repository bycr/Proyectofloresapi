using Microsoft.VisualStudio.TestTools.UnitTesting;
using Proyectofloresapi.Controllers;

namespace ProyectofloresapiTests
{
    [TestClass()]
    public class ErrorControllerTests
    {
        [TestMethod]
        public void errorview()
        {
            string result = ErrorController.errorview();
            Assert.AreEqual("view", result);

        }
    }
}