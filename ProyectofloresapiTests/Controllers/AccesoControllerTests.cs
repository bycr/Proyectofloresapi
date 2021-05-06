using Microsoft.VisualStudio.TestTools.UnitTesting;
using Proyectofloresapi.Controllers;

namespace ProyectofloresapiTests
{
    [TestClass()]
    public class AccesoControllerTests
    {
        [TestMethod]
        public void login()
        {
            string result = AccesoController.login();
            Assert.AreEqual("index", result);

        }
    }
}