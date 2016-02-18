using EnterpriseSystems.Data.Mappers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Data.Mappers
{
    public class CommentMapperTest
    {
        private CommentMapper Target { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            Target = new CommentMapper();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            Target = null;
        }
    }
}