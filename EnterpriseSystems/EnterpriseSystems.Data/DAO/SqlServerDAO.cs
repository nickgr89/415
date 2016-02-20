using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using EnterpriseSystems.Data.Model.Constants;
using EnterpriseSystems.Data.Model.Entities;

namespace EnterpriseSystems.Data.DAO
{
    public class SqlServerDao
    {
        private const string DatabaseConnectionString = DatabaseConnectionStrings.Default;

        public CustomerRequestVO GetCustomerRequestByIdentity(int customerRequestIdentity)
        {
            const string selectQueryStatement = "SELECT * FROM CUS_REQ WHERE CUS_REQ_I = @CUS_REQ_I";

            using (SqlConnection defaultSqlConnection = new SqlConnection(DatabaseConnectionString))
            {
                defaultSqlConnection.Open();
                DataTable queryResult = new DataTable();

                using (SqlCommand queryCommand = new SqlCommand(selectQueryStatement, defaultSqlConnection))
                {
                    queryCommand.Parameters.AddWithValue(CustomerRequestQueryParameters.Identity, customerRequestIdentity);
                    var sqlReader = queryCommand.ExecuteReader();
                    queryResult.Load(sqlReader);
                }

                var customerRequestByIdentity = BuildCustomerRequests(queryResult).FirstOrDefault();

                return customerRequestByIdentity;
            }
        }

        public IEnumerable<CustomerRequestVO> GetCustomerRequestsByReferenceNumber(string referenceNumber)
        {
            const string selectQueryStatement = "SELECT A.* FROM CUS_REQ A, REQ_ETY_REF_NBR B WHERE "
                                    + "B.ETY_NM = 'CUS_REQ' AND B.ETY_KEY_I = A.CUS_REQ_I AND "
                                    + "B.REF_NBR = @REF_NBR";

            using (SqlConnection defaultSqlConnection = new SqlConnection(DatabaseConnectionString))
            {
                defaultSqlConnection.Open();
                DataTable queryResult = new DataTable();

                using (SqlCommand queryCommand = new SqlCommand(selectQueryStatement, defaultSqlConnection))
                {
                    queryCommand.Parameters.AddWithValue(CustomerRequestQueryParameters.ReferenceNumber, referenceNumber);
                    var sqlReader = queryCommand.ExecuteReader();
                    queryResult.Load(sqlReader);
                }

                var customerRequestsByReferenceNumber = BuildCustomerRequests(queryResult);

                return customerRequestsByReferenceNumber;
            }
        }

        public IEnumerable<CustomerRequestVO> GetCustomerRequestsByReferenceNumberAndBusinessName(string referenceNumber, string businessName)
        {
            const string selectQueryStatement = "SELECT A.* FROM CUS_REQ A, REQ_ETY_REF_NBR B WHERE "
                        + "A.BUS_UNT_KEY_CH = @BUS_UNT_KEY_CH AND B.ETY_NM = 'CUS_REQ' "
                        + "AND B.ETY_KEY_I = A.CUS_REQ_I AND B.REF_NBR = @REF_NBR";

            using (SqlConnection defaultSqlConnection = new SqlConnection(DatabaseConnectionString))
            {
                defaultSqlConnection.Open();
                DataTable queryResult = new DataTable();

                using (SqlCommand queryCommand = new SqlCommand(selectQueryStatement, defaultSqlConnection))
                {
                    queryCommand.Parameters.AddWithValue(CustomerRequestQueryParameters.BusinessName, businessName);
                    queryCommand.Parameters.AddWithValue(CustomerRequestQueryParameters.ReferenceNumber, referenceNumber);
                    var sqlReader = queryCommand.ExecuteReader();
                    queryResult.Load(sqlReader);
                }

                var customerRequestsByReferenceNumberAndBusinessName = BuildCustomerRequests(queryResult);

                return customerRequestsByReferenceNumberAndBusinessName;
            }
        }

        private List<CustomerRequestVO> BuildCustomerRequests(DataTable dataTable)
        {
            var customerRequests = new List<CustomerRequestVO>();

            foreach (DataRow currentRow in dataTable.Rows)
            {
                var customerRequest = new CustomerRequestVO
                {
                    Identity = (int)currentRow[CustomerRequestColumnNames.Identity],
                    Status = currentRow[CustomerRequestColumnNames.Status].ToString(),
                    BusinessEntityKey = currentRow[CustomerRequestColumnNames.BusinessEntityKey].ToString(),
                    TypeCode = currentRow[CustomerRequestColumnNames.TypeCode].ToString(),
                    ConsumerClassificationType = currentRow[CustomerRequestColumnNames.ConsumerClassificationType].ToString(),
                    CreatedDate = (DateTime?)currentRow[CustomerRequestColumnNames.CreatedDate],
                    CreatedUserId = currentRow[CustomerRequestColumnNames.CreatedUserId].ToString(),
                    CreatedProgramCode = currentRow[CustomerRequestColumnNames.CreatedProgramCode].ToString(),
                    LastUpdatedDate = (DateTime?)currentRow[CustomerRequestColumnNames.LastUpdatedDate],
                    LastUpdatedUserId = currentRow[CustomerRequestColumnNames.LastUpdatedUserId].ToString(),
                    LastUpdatedProgramCode = currentRow[CustomerRequestColumnNames.LastUpdatedProgramCode].ToString()
                };

                customerRequest.Appointments = GetAppointmentsByCustomerRequest(customerRequest);
                customerRequest.Comments = GetCommentsByCustomerRequest(customerRequest);
                customerRequest.ReferenceNumbers = GetReferenceNumbersByCustomerRequest(customerRequest);
                customerRequest.Stops = GetStopsByCustomerRequest(customerRequest);

                customerRequests.Add(customerRequest);
            }

            return customerRequests;
        }


        private List<AppointmentVO> GetAppointmentsByCustomerRequest(CustomerRequestVO customerRequest)
        {
            const string selectQueryStatement = "SELECT * FROM REQ_ETY_SCH WHERE ETY_NM = 'CUS_REQ' AND ETY_KEY_I = @CUS_REQ_I";

            using (SqlConnection defaultSqlConnection = new SqlConnection(DatabaseConnectionString))
            {
                defaultSqlConnection.Open();
                DataTable queryResult = new DataTable();

                using (SqlCommand queryCommand = new SqlCommand(selectQueryStatement, defaultSqlConnection))
                {
                    queryCommand.Parameters.AddWithValue(AppointmentQueryParameters.Identity, customerRequest.Identity);
                    var sqlReader = queryCommand.ExecuteReader();
                    queryResult.Load(sqlReader);
                }

                var appointmentsByCustomerRequest = BuildAppointments(queryResult);

                return appointmentsByCustomerRequest;
            }
        }

        private List<AppointmentVO> BuildAppointments(DataTable dataTable)
        {
            var appointments = new List<AppointmentVO>();

            foreach (DataRow currentRow in dataTable.Rows)
            {
                var appointment = new AppointmentVO
                {
                    Identity = (int)currentRow[AppointmentColumnNames.Identity],
                    EntityName = currentRow[AppointmentColumnNames.EntityName].ToString(),
                    EntityIdentity = (int)currentRow[AppointmentColumnNames.EntityIdentity],
                    SequenceNumber = (short?)currentRow[AppointmentColumnNames.SequenceNumber],
                    FunctionType = currentRow[AppointmentColumnNames.FunctionType].ToString(),
                    AppointmentBegin = (DateTime?)currentRow[AppointmentColumnNames.AppointmentBegin],
                    AppointmentEnd = (DateTime?)currentRow[AppointmentColumnNames.AppointmentEnd],
                    TimezoneDescription = currentRow[AppointmentColumnNames.TimezoneDescription].ToString(),
                    Status = currentRow[AppointmentColumnNames.Status].ToString(),
                    CreatedDate = (DateTime?)currentRow[AppointmentColumnNames.CreatedDate],
                    CreatedUserId = currentRow[AppointmentColumnNames.CreatedDate].ToString(),
                    CreatedProgramCode = currentRow[AppointmentColumnNames.CreatedProgramCode].ToString(),
                    LastUpdatedDate = (DateTime?)currentRow[AppointmentColumnNames.LastUpdatedDate],
                    LastUpdatedUserId = currentRow[AppointmentColumnNames.LastUpdatedUserId].ToString(),
                    LastUpdatedProgramCode = currentRow[AppointmentColumnNames.LastUpdatedProgramCode].ToString()
                };

                appointments.Add(appointment);
            }

            return appointments;
        }


        private List<CommentVO> GetCommentsByCustomerRequest(CustomerRequestVO customerRequest)
        {
            const string selectQueryStatement = "SELECT * FROM REQ_ETY_CMM WHERE ETY_NM = 'CUS_REQ' AND ETY_KEY_I = @CUS_REQ_I";

            using (SqlConnection defaultSqlConnection = new SqlConnection(DatabaseConnectionString))
            {
                defaultSqlConnection.Open();
                DataTable queryResult = new DataTable();

                using (SqlCommand queryCommand = new SqlCommand(selectQueryStatement, defaultSqlConnection))
                {
                    queryCommand.Parameters.AddWithValue(CommentQueryParameters.Identity, customerRequest.Identity);
                    var sqlReader = queryCommand.ExecuteReader();
                    queryResult.Load(sqlReader);
                }

                var commentsByCustomerRequest = BuildComments(queryResult);

                return commentsByCustomerRequest;
            }
        }

        private List<CommentVO> BuildComments(DataTable dataTable)
        {
            var comments = new List<CommentVO>();

            foreach (DataRow currentRow in dataTable.Rows)
            {
                var comment = new CommentVO
                {
                    Identity = (int)currentRow[CommentColumnNames.Identity],
                    EntityName = currentRow[CommentColumnNames.EntityName].ToString(),
                    EntityIdentity = (int)currentRow[CommentColumnNames.EntityIdentity],
                    SequenceNumber = (short)currentRow[CommentColumnNames.SequenceNumber],
                    CommentType = currentRow[CommentColumnNames.CommentType].ToString(),
                    CommentText = currentRow[CommentColumnNames.CommentText].ToString(),
                    CreatedDate = (DateTime?)currentRow[CommentColumnNames.CreatedDate],
                    CreatedUserId = currentRow[CommentColumnNames.CreatedUserId].ToString(),
                    CreatedProgramCode = currentRow[CommentColumnNames.CreatedProgramCode].ToString(),
                    LastUpdatedDate = (DateTime?)currentRow[CommentColumnNames.LastUpdatedDate],
                    LastUpdatedUserId = currentRow[CommentColumnNames.LastUpdatedUserId].ToString(),
                    LastUpdatedProgramCode = currentRow[CommentColumnNames.LastUpdatedProgramCode].ToString()
                };

                comments.Add(comment);
            }

            return comments;
        }


        private List<ReferenceNumberVO> GetReferenceNumbersByCustomerRequest(CustomerRequestVO customerRequest)
        {
            const string selectQueryStatement = "SELECT * FROM REQ_ETY_REF_NBR WHERE ETY_NM = 'CUS_REQ' AND ETY_KEY_I = @CUS_REQ_I";

            using (SqlConnection defaultSqlConnection = new SqlConnection(DatabaseConnectionString))
            {
                defaultSqlConnection.Open();
                DataTable queryResult = new DataTable();

                using (SqlCommand queryCommand = new SqlCommand(selectQueryStatement, defaultSqlConnection))
                {
                    queryCommand.Parameters.AddWithValue(ReferenceNumberQueryParameters.Identity, customerRequest.Identity);
                    var sqlReader = queryCommand.ExecuteReader();
                    queryResult.Load(sqlReader);
                }

                var referenceNumbersByCustomerRequest = BuildReferenceNumbers(queryResult);

                return referenceNumbersByCustomerRequest;
            }
        }

        private List<ReferenceNumberVO> BuildReferenceNumbers(DataTable dataTable)
        {
            var referenceNumbers = new List<ReferenceNumberVO>();

            foreach (DataRow currentRow in dataTable.Rows)
            {
                var referenceNumber = new ReferenceNumberVO
                {
                    Identity = (int)currentRow[ReferenceNumberColumnNames.Identity],
                    EntityName = currentRow[ReferenceNumberColumnNames.EntityName].ToString(),
                    EntityIdentity = (int)currentRow[ReferenceNumberColumnNames.EntityIdentity],
                    ReferenceNumberType = currentRow[ReferenceNumberColumnNames.ReferenceNumberType].ToString(),
                    ReferenceNumberDescription = currentRow[ReferenceNumberColumnNames.ReferenceNumberDescription].ToString(),
                    ReferenceNumber = currentRow[ReferenceNumberColumnNames.ReferenceNumber].ToString(),
                    CreatedDate = (DateTime?)currentRow[ReferenceNumberColumnNames.CreatedDate],
                    CreatedUserId = currentRow[ReferenceNumberColumnNames.CreatedUserId].ToString(),
                    CreatedProgramCode = currentRow[ReferenceNumberColumnNames.CreatedProgramCode].ToString(),
                    LastUpdatedDate = (DateTime?)currentRow[ReferenceNumberColumnNames.LastUpdatedDate],
                    LastUpdatedUserId = currentRow[ReferenceNumberColumnNames.LastUpdatedUserId].ToString(),
                    LastUpdatedProgramCode = currentRow[ReferenceNumberColumnNames.LastUpdatedProgramCode].ToString()
                };

                referenceNumbers.Add(referenceNumber);
            }

            return referenceNumbers;
        }


        private List<StopVO> GetStopsByCustomerRequest(CustomerRequestVO customerRequest)
        {
            const string selectQueryStatement = "SELECT * FROM REQ_ETY_OGN WHERE ETY_NM = 'CUS_REQ' AND ETY_KEY_I = @CUS_REQ_I";

            using (SqlConnection defaultSqlConnection = new SqlConnection(DatabaseConnectionString))
            {
                defaultSqlConnection.Open();
                DataTable queryResult = new DataTable();

                using (SqlCommand queryCommand = new SqlCommand(selectQueryStatement, defaultSqlConnection))
                {
                    queryCommand.Parameters.AddWithValue(StopQueryParameters.Identity, customerRequest.Identity);
                    var sqlReader = queryCommand.ExecuteReader();
                    queryResult.Load(sqlReader);
                }

                var stopsByCustomerRequest = BuildStops(queryResult);

                return stopsByCustomerRequest;
            }
        }

        private List<StopVO> BuildStops(DataTable dataTable)
        {
            var stops = new List<StopVO>();

            foreach (DataRow currentRow in dataTable.Rows)
            {
                var stop = new StopVO
                {
                    Identity = (int)currentRow[StopColumnNames.Identity],
                    EntityName = currentRow[StopColumnNames.EntityName].ToString(),
                    EntityIdentity = (int)currentRow[StopColumnNames.EntityIdentity],
                    RoleType = currentRow[StopColumnNames.RoleType].ToString(),
                    StopNumber = (short)currentRow[StopColumnNames.StopNumber],
                    CustomerAlias = currentRow[StopColumnNames.CustomerAlias].ToString(),
                    OrganizationName = currentRow[StopColumnNames.OrganizationName].ToString(),
                    AddressLine1 = currentRow[StopColumnNames.AddressLine1].ToString(),
                    AddressLine2 = currentRow[StopColumnNames.AddressLine2].ToString(),
                    AddressCityName = currentRow[StopColumnNames.AddressCityName].ToString(),
                    AddressStateCode = currentRow[StopColumnNames.AddressStateCode].ToString(),
                    AddressCountryCode = currentRow[StopColumnNames.AddressCountryCode].ToString(),
                    AddressPostalCode = currentRow[StopColumnNames.AddressPostalCode].ToString(),
                    CreatedDate = (DateTime?)currentRow[StopColumnNames.CreatedDate],
                    CreatedUserId = currentRow[StopColumnNames.CreatedUserId].ToString(),
                    CreatedProgramCode = currentRow[StopColumnNames.CreatedProgramCode].ToString(),
                    LastUpdatedDate = (DateTime?)currentRow[StopColumnNames.LastUpdatedDate],
                    LastUpdatedUserId = currentRow[StopColumnNames.LastUpdatedUserId].ToString(),
                    LastUpdatedProgramCode = currentRow[StopColumnNames.LastUpdatedProgramCode].ToString()
                };

                stop.Appointments = GetAppointmentsByStop(stop);
                stop.Comments = GetCommentsByStop(stop);

                stops.Add(stop);
            }

            return stops;
        }


        private List<AppointmentVO> GetAppointmentsByStop(StopVO stop)
        {
            const string selectQueryStatement = "SELECT * FROM REQ_ETY_SCH WHERE ETY_NM = 'REQ_ETY_OGN' AND ETY_KEY_I = @REQ_ETY_OGN_I";

            using (SqlConnection defaultSqlConnection = new SqlConnection(DatabaseConnectionString))
            {
                defaultSqlConnection.Open();
                DataTable queryResult = new DataTable();

                using (SqlCommand queryCommand = new SqlCommand(selectQueryStatement, defaultSqlConnection))
                {
                    queryCommand.Parameters.AddWithValue(AppointmentQueryParameters.Stop, stop.Identity);
                    var sqlReader = queryCommand.ExecuteReader();
                    queryResult.Load(sqlReader);
                }

                var appointmentsByStop = BuildAppointments(queryResult);

                return appointmentsByStop;
            }
        }

        private List<CommentVO> GetCommentsByStop(StopVO stop)
        {
            const string selectQueryStatement = "SELECT * FROM REQ_ETY_CMM WHERE ETY_NM = 'REQ_ETY_OGN' AND ETY_KEY_I = @REQ_ETY_OGN_I";

            using (SqlConnection defaultSqlConnection = new SqlConnection(DatabaseConnectionString))
            {
                defaultSqlConnection.Open();
                DataTable queryResult = new DataTable();

                using (SqlCommand queryCommand = new SqlCommand(selectQueryStatement, defaultSqlConnection))
                {
                    queryCommand.Parameters.AddWithValue(CommentQueryParameters.Stop, stop.Identity);
                    var sqlReader = queryCommand.ExecuteReader();
                    queryResult.Load(sqlReader);
                }

                var commentsByStop = BuildComments(queryResult);

                return commentsByStop;
            }
        }
    }
}
