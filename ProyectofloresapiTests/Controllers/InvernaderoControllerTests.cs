using Microsoft.VisualStudio.TestTools.UnitTesting;
using Proyectofloresapi.Controllers;

namespace ProyectofloresapiTests
{
    [TestClass()]
    public class InvernaderoControllerTests
    {
        [TestMethod]
        public void vistalistaInvernadero()
        {
            string result = InvernaderoController.vistalistaInvernadero();
            Assert.AreEqual("lst", result);

        }
        [TestMethod]
        public void vistaNuevoInvernadero()
        {
            string result = InvernaderoController.vistaNuevoInvernadero();
            Assert.AreEqual("model", result);

        }
        [TestMethod]
        public void vistaEditarInvernadero()
        {
            string result = InvernaderoController.vistaEditarInvernadero();
            Assert.AreEqual("mod", result);

        }
        [TestMethod]
        public void vistaEliminarInvernadero()
        {
            string result = InvernaderoController.vistaEliminarInvernadero();
            Assert.AreEqual("view", result);

        }
    }
}