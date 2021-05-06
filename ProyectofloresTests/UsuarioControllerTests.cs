using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProyectofloresTests
{
    [TestClass]
    public class UsuarioControllerTests
    {
        [TestMethod]
        public void vistalistaUsuario()
        {
            string result = Proyectofloresapi.Controllers.UsuarioController.vistalistaUsuario();
            Assert.AreEqual("lst", result);

        }
        [TestMethod]
        public void vistaNuevoUsuario()
        {
            string result = Proyectofloresapi.Controllers.UsuarioController.vistaNuevoUsuario();
            Assert.AreEqual("model", result);

        }
        [TestMethod]
        public void vistaEditarUsuario()
        {
            string result = Proyectofloresapi.Controllers.UsuarioController.vistaEditarUsuario();
            Assert.AreEqual("mod", result);

        }
        [TestMethod]
        public void vistaEliminarUsuario()
        {
            string result = Proyectofloresapi.Controllers.UsuarioController.vistaEliminarUsuario();
            Assert.AreEqual("view", result);

        }
    }
}
