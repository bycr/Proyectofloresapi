using Microsoft.VisualStudio.TestTools.UnitTesting;
using Proyectofloresapi.Controllers;

namespace ProyectofloresapiTests
{
    [TestClass()]
    public class FincaControllerTests
    {
        [TestMethod]
        public void vistalista()
        {
            string result = FincaController.vistalista();
            Assert.AreEqual("lst", result);

        }
        [TestMethod]
        public void vistaNuevafinca()
        {
            string result = FincaController.vistaNuevafinca();
            Assert.AreEqual("model", result);

        }
        [TestMethod]
        public void vistaEditarfinca()
        {
            string result = FincaController.vistaEditarfinca();
            Assert.AreEqual("model", result);

        }
        [TestMethod]
        public void vistaEliminarFinca()
        {
            string result = FincaController.vistaEliminarFinca();
            Assert.AreEqual("model", result);

        }
    }
}