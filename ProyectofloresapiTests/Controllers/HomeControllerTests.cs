using Microsoft.VisualStudio.TestTools.UnitTesting;
using Proyectofloresapi.Controllers;

namespace ProyectofloresapiTests
{
    [TestClass()]
    public class HomeControllerTests
    {
        [TestMethod]
        public void vistaindex()
        {
            string result = HomeController.vistaindex();
            Assert.AreEqual("view", result);

        }
        
    }
}