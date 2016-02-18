using EnterpriseSystems.Data.Hydraters;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Data.Hydraters
{
    [TestClass]
    public class CommentHydraterTest
    {
        private CommentHydrater Target { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            Target = new CommentHydrater();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            Target = null;
        }
    }
}
