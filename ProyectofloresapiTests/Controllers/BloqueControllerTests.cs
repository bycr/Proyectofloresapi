using Microsoft.VisualStudio.TestTools.UnitTesting;
using Proyectofloresapi.Controllers;

namespace ProyectofloresapiTests
{
    [TestClass()]
    public class BloqueControllerTests
    {
        [TestMethod]
        public void listaBloque()
        {
            string result = BloqueController.listaBloque();
            Assert.AreEqual("lst", result);

        }
        [TestMethod]
        public void nuevoBloque()
        {
            string result = BloqueController.nuevoBloque();
            Assert.AreEqual("lst", result);

        }
        [TestMethod]
        public void editarBloque()
        {
            string result = BloqueController.editarBloque();
            Assert.AreEqual("model", result);

        }
        [TestMethod]
        public void eliminarBloque()
        {
            string result = BloqueController.eliminarBloque();
            Assert.AreEqual("bloque", result);

        }
    }
}