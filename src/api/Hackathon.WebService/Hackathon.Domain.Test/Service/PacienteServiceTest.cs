using Hackathon.Domain.Enums;
using Hackathon.Domain.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hackathon.Domain.Test.Service
{
    [TestClass]
    public class PacienteServiceTest
    {
        PacienteService pacienteService = new PacienteService();

        [TestMethod, TestCategory("[Paciente] 2. Service Paciente")]
        public void Paciente_Get_Login()
        {
            var paciente = pacienteService.Get("10408910631", "eduardo");

            Assert.AreEqual(ResponseTypeEnum.Success, pacienteService.ResponseService.Type);
        }
    }
}
