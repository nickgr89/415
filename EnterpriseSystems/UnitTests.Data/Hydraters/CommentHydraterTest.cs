using EnterpriseSystems.Data.Hydraters;
using EnterpriseSystems.Data.Model.Constants;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data;
using System.Linq;

namespace UnitTests.Data.Hydraters
{
    [TestClass]
    public class CommentHydraterTest
    {
        private CommentHydrater Target { get; set; }
        private DataTable TestDataTable { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            InitializeTarget();
            InitializeTestDataTable();
        }
        private void InitializeTarget()
        {
            Target = new CommentHydrater();
        }

        private void InitializeTestDataTable()
        {
            TestDataTable = new DataTable();
            TestDataTable.Columns.Add(CommentColumnNames.Identity, typeof(int));
            TestDataTable.Columns.Add(CommentColumnNames.EntityName, typeof(string));
            TestDataTable.Columns.Add(CommentColumnNames.EntityIdentity, typeof(int));
            TestDataTable.Columns.Add(CommentColumnNames.SequenceNumber, typeof(int));
            TestDataTable.Columns.Add(CommentColumnNames.CommentType, typeof(string));
            TestDataTable.Columns.Add(CommentColumnNames.CommentText, typeof(string));
            TestDataTable.Columns.Add(CommentColumnNames.CreatedDate, typeof(DateTime));
            TestDataTable.Columns.Add(CommentColumnNames.CreatedUserId, typeof(string));
            TestDataTable.Columns.Add(CommentColumnNames.CreatedProgramCode, typeof(string));
            TestDataTable.Columns.Add(CommentColumnNames.LastUpdatedDate, typeof(DateTime));
            TestDataTable.Columns.Add(CommentColumnNames.LastUpdatedUserId, typeof(string));
            TestDataTable.Columns.Add(CommentColumnNames.LastUpdatedProgramCode, typeof(string));
        }

        [TestCleanup]
        public void TestCleanup()
        {
            Target = null;
            TestDataTable = null;
        }

        [TestMethod]
        public void Hydrate_ReturnsEmptyWhenDataTableEmpty()
        {
            var actual = Target.Hydrate(TestDataTable);

            Assert.AreEqual(0, actual.Count());
        }
    }
}
