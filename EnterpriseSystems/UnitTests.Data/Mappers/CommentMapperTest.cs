using Microsoft.VisualStudio.TestTools.UnitTesting;
using EnterpriseSystems.Data.Mappers;
using EnterpriseSystems.Data.DAO;
using EnterpriseSystems.Data.Hydraters;
using EnterpriseSystems.Data.Model.Entities;
using Moq;

namespace UnitTests.Data.Mappers
{
    public class CommentMapperTest
    {
        private CommentMapper Target { get; set; }
        private Mock<IDatabase> MockDatabase { get; set; }
        private Mock<IQuery> MockQuery { get; set; }
        Mock<IHydrater<CommentVO>> MockCommentHydrater { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            MockDatabase = new Mock<IDatabase>();
            MockQuery = new Mock<IQuery>();
            MockCommentHydrater = new Mock<IHydrater<CommentVO>>();
            Target = new CommentMapper(MockDatabase.Object, MockCommentHydrater.Object);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            Target = null;
            MockDatabase = null;
            MockQuery = null;
            MockCommentHydrater = null;
        }

        [TestMethod]
        public void GetCommentsByCustomerRequest_SetsQueryParameter()
        {
            var actual = Target.GetCommentsByCustomerRequest(new CustomerRequestVO());

            Assert.Fail();
        }

        public void GetCommentsByCustomerRequest_ReturnsHydratedEntity()
        {
            var actual = Target.GetCommentsByCustomerRequest(new CustomerRequestVO());

            Assert.Fail();
        }
    }
}