using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProyectofloresTests
{
    [TestClass]
    public class InvernaderoControllerTests
    {
        [TestMethod]
        public void vistalistaInvernadero()
        {
            string result = Proyectofloresapi.Controllers.InvernaderoController.vistalistaInvernadero();
            Assert.AreEqual("lst", result);

        }
        [TestMethod]
        public void vistaNuevoInvernadero()
        {
            string result = Proyectofloresapi.Controllers.InvernaderoController.vistaNuevoInvernadero();
            Assert.AreEqual("model", result);

        }
        [TestMethod]
        public void vistaEditarInvernadero()
        {
            string result = Proyectofloresapi.Controllers.InvernaderoController.vistaEditarInvernadero();
            Assert.AreEqual("mod", result);

        }
        [TestMethod]
        public void vistaEliminarInvernadero()
        {
            string result = Proyectofloresapi.Controllers.InvernaderoController.vistaEliminarInvernadero();
            Assert.AreEqual("view", result);

        }
    }
}
