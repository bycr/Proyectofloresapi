using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProyectofloresTests
{
    [TestClass]
    public class FincaControllerTests
    {
        [TestMethod]
        public void vistalista()
        {
            string result = Proyectofloresapi.Controllers.FincaController.vistalista();
            Assert.AreEqual("lst", result);

        }
        [TestMethod]
        public void vistaNuevafinca()
        {
            string result = Proyectofloresapi.Controllers.FincaController.vistaNuevafinca();
            Assert.AreEqual("model", result);

        }
        [TestMethod]
        public void vistaEditarfinca()
        {
            string result = Proyectofloresapi.Controllers.FincaController.vistaEditarfinca();
            Assert.AreEqual("model", result);

        }
        [TestMethod]
        public void vistaEliminarFinca()
        {
            string result = Proyectofloresapi.Controllers.FincaController.vistaEliminarFinca();
            Assert.AreEqual("model", result);

        }
    }
}
