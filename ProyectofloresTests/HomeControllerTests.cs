using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProyectofloresTests
{
    [TestClass]
    public class HomeControllerTests
    {
        [TestMethod]
        public void vistaindex()
        {
            string result = Proyectofloresapi.Controllers.HomeController.vistaindex();
            Assert.AreEqual("view", result);

        }
       
       
    }
}
