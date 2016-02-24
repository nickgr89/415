using Microsoft.VisualStudio.TestTools.UnitTesting;
using EnterpriseSystems.Data.Mappers;
using EnterpriseSystems.Data.DAO;
using EnterpriseSystems.Data.Hydraters;
using EnterpriseSystems.Data.Model.Entities;
using Moq;

namespace UnitTests.Data.Mappers
{
    [TestClass]
    public class AppointmentMapperTest
    {
        private AppointmentMapper Target { get; set; }
        private Mock<IDatabase> MockDatabase { get; set; }
        private Mock<IQuery> MockQuery { get; set; }
        Mock<IHydrater<AppointmentVO>> MockAppointmentHydrater { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            MockDatabase = new Mock<IDatabase>();
            MockQuery = new Mock<IQuery>();
            MockAppointmentHydrater = new Mock<IHydrater<AppointmentVO>>();
            Target = new AppointmentMapper(MockDatabase.Object, MockAppointmentHydrater.Object);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            Target = null;
            MockDatabase = null;
            MockQuery = null;
            MockAppointmentHydrater = null;
        }

        [TestMethod]
        public void GetAppointmentByCustomerRequest_SetsQueryParameter()
        {
            var actual = Target.GetAppointmentByCustomerRequest(new CustomerRequestVO());

            Assert.Fail();
        }

        [TestMethod]
        public void GetAppointmentByCustomerRequest_ReturnsHydratedEntity()
        {
            var actual = Target.GetAppointmentByCustomerRequest(new CustomerRequestVO());

            Assert.Fail();
        }

        [TestMethod]
        public void GetAppointmentsByStop_SetsQueryParameter()
        {
            var actual = Target.GetAppointmentsByStop(new AppointmentVO());

            Assert.Fail();
        }

        [TestMethod]
        public void GetAppointmentsByStop_ReturnsHydratedEntity()
        {
            var actual = Target.GetAppointmentsByStop(new AppointmentVO());

            Assert.Fail();
        }
    }
}
