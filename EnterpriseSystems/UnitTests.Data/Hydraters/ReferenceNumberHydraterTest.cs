using EnterpriseSystems.Data.Hydraters;
using EnterpriseSystems.Data.Model.Constants;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data;
using System.Linq;

namespace UnitTests.Data.Hydraters
{
    [TestClass]
    public class ReferenceNumberHydraterTest
    {
        private ReferenceNumberHydrater Target { get; set; }
        private DataTable TestDataTable { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            InitializeTarget();
            InitializeTestDataTable();
        }

        private void InitializeTarget()
        {
            Target = new ReferenceNumberHydrater();
        }

        private void InitializeTestDataTable()
        {
            TestDataTable = new DataTable();
            TestDataTable.Columns.Add(ReferenceNumberColumnNames.Identity, typeof(int));
            TestDataTable.Columns.Add(ReferenceNumberColumnNames.EntityName, typeof(string));
            TestDataTable.Columns.Add(ReferenceNumberColumnNames.EntityIdentity, typeof(int));
            TestDataTable.Columns.Add(ReferenceNumberColumnNames.ReferenceNumberType, typeof(string));
            TestDataTable.Columns.Add(ReferenceNumberColumnNames.ReferenceNumberDescription, typeof(string));
            TestDataTable.Columns.Add(ReferenceNumberColumnNames.ReferenceNumber, typeof(string));
            TestDataTable.Columns.Add(ReferenceNumberColumnNames.CreatedDate, typeof(DateTime));
            TestDataTable.Columns.Add(ReferenceNumberColumnNames.CreatedUserId, typeof(string));
            TestDataTable.Columns.Add(ReferenceNumberColumnNames.CreatedProgramCode, typeof(string));
            TestDataTable.Columns.Add(ReferenceNumberColumnNames.LastUpdatedDate, typeof(DateTime));
            TestDataTable.Columns.Add(ReferenceNumberColumnNames.LastUpdatedUserId, typeof(string));
            TestDataTable.Columns.Add(ReferenceNumberColumnNames.LastUpdatedProgramCode, typeof(string));
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

            testDataRow[ReferenceNumberColumnNames.Identity] = 1 + (increment ?? 0);
            testDataRow[ReferenceNumberColumnNames.EntityName] = "EntityName" + (increment.HasValue ? increment.Value.ToString() : String.Empty);
            testDataRow[ReferenceNumberColumnNames.EntityIdentity] = 2 + (increment ?? 0);
            testDataRow[ReferenceNumberColumnNames.ReferenceNumberType] = "ReferenceNumberType" + (increment.HasValue ? increment.Value.ToString() : String.Empty);
            testDataRow[ReferenceNumberColumnNames.ReferenceNumberDescription] = "ReferenceNumberDescription" + (increment.HasValue ? increment.Value.ToString() : String.Empty);
            testDataRow[ReferenceNumberColumnNames.ReferenceNumber] = "ReferenceNumber" + (increment.HasValue ? increment.Value.ToString() : String.Empty);            testDataRow[CustomerRequestColumnNames.CreatedDate] = new DateTime(1 + (increment ?? 0));
            testDataRow[ReferenceNumberColumnNames.CreatedUserId] = "CreatedUserId" + (increment.HasValue ? increment.Value.ToString() : String.Empty);
            testDataRow[ReferenceNumberColumnNames.CreatedProgramCode] = "CreatedProgramCode" + (increment.HasValue ? increment.Value.ToString() : String.Empty);
            testDataRow[ReferenceNumberColumnNames.LastUpdatedDate] = new DateTime(2 + (increment ?? 0));
            testDataRow[ReferenceNumberColumnNames.LastUpdatedUserId] = "LastUpdatedUserId" + (increment.HasValue ? increment.Value.ToString() : String.Empty);
            testDataRow[ReferenceNumberColumnNames.LastUpdatedProgramCode] = "LastUpdatedProgramCode" + (increment.HasValue ? increment.Value.ToString() : String.Empty);

            return testDataRow;
        }
    }
}
