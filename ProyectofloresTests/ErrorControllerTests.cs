using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProyectofloresTests
{
    [TestClass]
    public class ErrorControllerTests
    {
        [TestMethod]
        public void errorview()
        {
            string result = Proyectofloresapi.Controllers.ErrorController.errorview();
            Assert.AreEqual("view", result);

        }
      
    }
}
