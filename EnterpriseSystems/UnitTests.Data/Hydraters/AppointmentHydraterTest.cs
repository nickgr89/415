using EnterpriseSystems.Data.Hydraters;
using EnterpriseSystems.Data.Model.Constants;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data;
using System.Linq;

namespace UnitTests.Data.Hydraters
{
    [TestClass]
    public class AppointmentHydraterTest
    {
        private AppointmentHydrater Target { get; set; }
        private DataTable TestDataTable { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            InitializeTarget();
            InitializeTestDataTable();

        }

        private void InitializeTarget()
        {
            Target = new AppointmentHydrater();
        }
            
        private void InitializeTestDataTable()
        {
            TestDataTable = new DataTable();
            TestDataTable.Columns.Add(AppointmentColumnNames.Identity, typeof(int));
            TestDataTable.Columns.Add(AppointmentColumnNames.EntityName, typeof(string));
            TestDataTable.Columns.Add(AppointmentColumnNames.EntityIdentity, typeof(int));
            TestDataTable.Columns.Add(AppointmentColumnNames.SequenceNumber, typeof(int));
            TestDataTable.Columns.Add(AppointmentColumnNames.FunctionType, typeof(string));
            TestDataTable.Columns.Add(AppointmentColumnNames.AppointmentBegin, typeof(DateTime));
            TestDataTable.Columns.Add(AppointmentColumnNames.AppointmentEnd, typeof(DateTime));
            TestDataTable.Columns.Add(AppointmentColumnNames.TimezoneDescription, typeof(string));
            TestDataTable.Columns.Add(AppointmentColumnNames.Status, typeof(string));
            TestDataTable.Columns.Add(AppointmentColumnNames.CreatedDate, typeof(DateTime));
            TestDataTable.Columns.Add(AppointmentColumnNames.CreatedUserId, typeof(string));
            TestDataTable.Columns.Add(AppointmentColumnNames.CreatedProgramCode, typeof(string));
            TestDataTable.Columns.Add(AppointmentColumnNames.LastUpdatedDate, typeof(DateTime));
            TestDataTable.Columns.Add(AppointmentColumnNames.LastUpdatedUserId, typeof(string));
            TestDataTable.Columns.Add(AppointmentColumnNames.LastUpdatedProgramCode, typeof(string));
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
