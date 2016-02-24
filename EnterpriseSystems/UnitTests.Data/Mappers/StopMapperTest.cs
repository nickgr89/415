using Microsoft.VisualStudio.TestTools.UnitTesting;
using EnterpriseSystems.Data.Mappers;
using EnterpriseSystems.Data.DAO;
using EnterpriseSystems.Data.Hydraters;
using EnterpriseSystems.Data.Model.Entities;
using Moq;

namespace UnitTests.Data.Mappers
{
    public class StopMapperTest
    {
        private StopMapper Target { get; set; }
        private Mock<IDatabase> MockDatabase { get; set; }
        private Mock<IQuery> MockQuery { get; set; }
        private Mock<IHydrater<StopVO>> MockStopHydrater { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            MockDatabase = new Mock<IDatabase>();
            MockQuery = new Mock<IQuery>();
            MockStopHydrater = new Mock<IHydrater<StopVO>>();

            Target = new StopMapper(MockDatabase.Object, MockStopHydrater.Object);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            Target = null;
            MockDatabase = null;
            MockQuery = null;
            MockStopHydrater = null;
        }

        [TestMethod]
        public void GetStopsByCustomerRequest_SetsQueryParameter()
        {
            var actual = Target.GetStopsByCustomerRequest(new CustomerRequestVO());

            Assert.Fail();
        }

        [TestMethod]
        public void GetStopsByCustomerRequest_ReturnsHydratedEntities()
        {
            var actual = Target.GetStopsByCustomerRequest(new CustomerRequestVO());

            Assert.Fail();
        }
    }
}