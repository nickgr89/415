using Microsoft.VisualStudio.TestTools.UnitTesting;
using EnterpriseSystems.Data.Mappers;
using EnterpriseSystems.Data.DAO;
using EnterpriseSystems.Data.Hydraters;
using EnterpriseSystems.Data.Model.Entities;
using Moq;

namespace UnitTests.Data.Mappers
{
    [TestClass]
    public class CustomerRequestMapperTest
    {
        private CustomerRequestMapper Target { get; set; }
        private Mock<IDatabase> MockDatabase { get; set; }
        private Mock<IQuery> MockQuery { get; set; }
        private Mock<IHydrater<CustomerRequestVO>> MockCustomerRequestHydrater { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            MockDatabase = new Mock<IDatabase>();
            MockQuery = new Mock<IQuery>();
            MockCustomerRequestHydrater = new Mock<IHydrater<CustomerRequestVO>>();

            Target = new CustomerRequestMapper(MockDatabase.Object, MockCustomerRequestHydrater.Object);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            Target = null;
            MockDatabase = null;
            MockQuery = null;
            MockCustomerRequestHydrater = null;
        }

        [TestMethod]
        public void GetCustomerRequestByIdentity_ReturnsNullWhenNoQueryMatches()
        {
            var actual = Target.GetCustomerRequestByIdentity(new CustomerRequestVO());

            Assert.IsNull(actual);
        }

        [TestMethod]
        public void GetCustomerRequestByIdentity_SetsQueryParameter()
        {
            var actual = Target.GetCustomerRequestByIdentity(null);

            Assert.Fail();
        }

        [TestMethod]
        public void GetCustomerRequestByIdentity_ReturnsHydratedEntity()
        {
            var actual = Target.GetCustomerRequestByIdentity(new CustomerRequestVO());

            Assert.Fail();
        }

        [TestMethod]
        public void GetCustomerRequestsByReferenceNumber_SetsQueryParameter()
        {
            var actual = Target.GetCustomerRequestsByReferenceNumber(new CustomerRequestVO());

            Assert.Fail();
        }

        [TestMethod]
        public void GetCustomerRequestsByReferenceNumber_ReturnsHydratedEntities()
        {
            var actual = Target.GetCustomerRequestsByReferenceNumber(new CustomerRequestVO());

            Assert.Fail();
        }


        [TestMethod]
        public void GetCustomerRequestsByReferenceNumberAndBusinessName_SetsQueryParameters()
        {
            var actual = Target.GetCustomerRequestsByReferenceNumberAndBusinessName(new CustomerRequestVO());

            Assert.Fail();
        }

        [TestMethod]
        public void GetCustomerRequestsByReferenceNumberAndBusinessName_ReturnsHydratedEntities()
        {
            var actual = Target.GetCustomerRequestsByReferenceNumberAndBusinessName(new CustomerRequestVO());

            Assert.Fail();
        }
    }
}
