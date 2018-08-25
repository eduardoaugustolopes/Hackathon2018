using Hackathon.Domain.Enums;
using Hackathon.Domain.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hackathon.Domain.Test.Service
{
    [TestClass]
    public class ClinicaServiceTest
    {
        ClinicaService clinicaService = new ClinicaService();

        [TestMethod, TestCategory("[Clinica] 2. Service Clinica")]
        public void Clinica_Get_Login()
        {
            var clinica = clinicaService.Get("prosaude", "prosaude");

            Assert.AreEqual(ResponseTypeEnum.Success, clinicaService.ResponseService.Type);
        }
    }
}
