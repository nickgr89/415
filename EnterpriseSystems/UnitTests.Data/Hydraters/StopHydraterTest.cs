using EnterpriseSystems.Data.Hydraters;
using EnterpriseSystems.Data.Model.Constants;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data;
using System.Linq;

namespace UnitTests.Data.Hydraters
{
    [TestClass]
    public class StopHydraterTest
    {
        private StopHydrater Target { get; set; }
        private DataTable TestDataTable { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            InitializeTarget();
            InitializeTestDataTable();
        }

        private void InitializeTarget()
        {
            Target = new StopHydrater();
        }

        private void InitializeTestDataTable()
        {
            TestDataTable = new DataTable();
            TestDataTable.Columns.Add(StopColumnNames.Identity, typeof(int));
            TestDataTable.Columns.Add(StopColumnNames.EntityName, typeof(string));
            TestDataTable.Columns.Add(StopColumnNames.EntityIdentity, typeof(int));
            TestDataTable.Columns.Add(StopColumnNames.RoleType, typeof(string));
            TestDataTable.Columns.Add(StopColumnNames.StopNumber, typeof(string));
            TestDataTable.Columns.Add(StopColumnNames.CustomerAlias, typeof(string));
            TestDataTable.Columns.Add(StopColumnNames.OrganizationName, typeof(string));
            TestDataTable.Columns.Add(StopColumnNames.AddressLine1, typeof(string));
            TestDataTable.Columns.Add(StopColumnNames.AddressLine2, typeof(string));
            TestDataTable.Columns.Add(StopColumnNames.AddressCityName, typeof(string));
            TestDataTable.Columns.Add(StopColumnNames.AddressStateCode, typeof(string));
            TestDataTable.Columns.Add(StopColumnNames.AddressCountryCode, typeof(string));
            TestDataTable.Columns.Add(StopColumnNames.AddressPostalCode, typeof(string));
            TestDataTable.Columns.Add(StopColumnNames.CreatedDate, typeof(DateTime));
            TestDataTable.Columns.Add(StopColumnNames.CreatedUserId, typeof(string));
            TestDataTable.Columns.Add(StopColumnNames.CreatedProgramCode, typeof(string));
            TestDataTable.Columns.Add(StopColumnNames.LastUpdatedDate, typeof(DateTime));
            TestDataTable.Columns.Add(StopColumnNames.LastUpdatedUserId, typeof(string));
            TestDataTable.Columns.Add(StopColumnNames.LastUpdatedProgramCode, typeof(string));
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
