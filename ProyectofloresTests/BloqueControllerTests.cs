using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProyectofloresTests
{
    [TestClass]
    public class BloqueControllerTests
    {
        [TestMethod]
        public void listaBloque()
        {
            string result = Proyectofloresapi.Controllers.BloqueController.listaBloque();
            Assert.AreEqual("lst", result);

        }
        [TestMethod]
        public void nuevoBloque()
        {
            string result = Proyectofloresapi.Controllers.BloqueController.nuevoBloque();
            Assert.AreEqual("lst", result);

        }
        [TestMethod]
        public void editarBloque()
        {
            string result = Proyectofloresapi.Controllers.BloqueController.editarBloque();
            Assert.AreEqual("model", result);

        }
        [TestMethod]
        public void eliminarBloque()
        {
            string result = Proyectofloresapi.Controllers.BloqueController.eliminarBloque();
            Assert.AreEqual("bloque", result);

        }
    }
}
