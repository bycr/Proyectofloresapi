using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProyectofloresTests
{
    [TestClass]
    public class AccesoControllerTests
    {
        [TestMethod]
        public void login()
        {
            string result = Proyectofloresapi.Controllers.AccesoController.login();
            Assert.AreEqual("index", result);

        }
       
    }
}
