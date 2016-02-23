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

        [TestMethod]
        public void Hydrate_HydratesCommentsSuccessfully()
        {
            DataRow testDataRow = GetTestDataRow();
            TestDataTable.Rows.Add(testDataRow);

            testDataRow = GetTestDataRow(1);
            TestDataTable.Rows.Add(testDataRow);

            var actual = Target.Hydrate(TestDataTable);

        }

        private DataRow GetTestDataRow(int? increment = null)
        {
            DataRow testDataRow = TestDataTable.NewRow();

            testDataRow[CommentColumnNames.Identity] = 1 + (increment ?? 0);
            testDataRow[CommentColumnNames.EntityName] = "EntityName " + (increment.HasValue ? increment.Value.ToString() : String.Empty);
            testDataRow[CommentColumnNames.EntityIdentity] = 2 + (increment ?? 0);
            testDataRow[CommentColumnNames.SequenceNumber] = 3 + (increment ?? 0);
            testDataRow[CommentColumnNames.CommentType] = "CommentType" + (increment.HasValue ? increment.Value.ToString() : String.Empty);
            testDataRow[CommentColumnNames.CommentText] = "CommentText" + (increment.HasValue ? increment.Value.ToString() : String.Empty);
            testDataRow[CommentColumnNames.CreatedDate] = new DateTime(1 + (increment ?? 0));
            testDataRow[CommentColumnNames.CreatedUserId] = "CreatedUserId" + (increment.HasValue ? increment.Value.ToString() : String.Empty);
            testDataRow[CommentColumnNames.CreatedProgramCode] = "CreatedProgramCode" + (increment.HasValue ? increment.Value.ToString() : String.Empty);
            testDataRow[CommentColumnNames.LastUpdatedDate] = new DateTime(2 + (increment ?? 0));
            testDataRow[CommentColumnNames.LastUpdatedUserId] = "LastUpdatedUserId" + (increment.HasValue ? increment.Value.ToString() : String.Empty);
            testDataRow[CommentColumnNames.LastUpdatedProgramCode] = "LastUpdatedProgramCode" + (increment.HasValue ? increment.Value.ToString() : String.Empty);

            return testDataRow;
        }
    }
}
