﻿using EnterpriseSystems.Infrastructure.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace EnterpriseSystems.Infrastructure.DAO
{
    public class SqlServerDAO
    {
        private const string DatabaseConnectionString = "NULL";

        public CustomerRequestVO GetCustomerRequestByIdentity(int customerRequestIdentity)
        {
            const string selectQueryStatement = "SELECT * FROM CUS_REQ WHERE CUS_REQ_I = @CUS_REQ_I";

            using (SqlConnection defaultSqlConnection = new SqlConnection(DatabaseConnectionString))
            {
                defaultSqlConnection.Open();
                DataTable queryResult = new DataTable();

                using (SqlCommand queryCommand = new SqlCommand(selectQueryStatement, defaultSqlConnection))
                {
                    queryCommand.Parameters.AddWithValue("@CUS_REQ_I", customerRequestIdentity);
                    var sqlReader = queryCommand.ExecuteReader();
                    queryResult.Load(sqlReader);
                }

                var customerRequestByIdentity = BuildCustomerRequests(queryResult).FirstOrDefault();

                return customerRequestByIdentity;
            }
        }

        public List<CustomerRequestVO> GetCustomerRequestsByReferenceNumber(string referenceNumber)
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
                    queryCommand.Parameters.AddWithValue("@REF_NBR", referenceNumber);
                    var sqlReader = queryCommand.ExecuteReader();
                    queryResult.Load(sqlReader);
                }

                var customerRequestByReferenceNumber = BuildCustomerRequests(queryResult).FirstOrDefault();

                return customerRequestByReferenceNumber;
            }
        }

        public List<CustomerRequestVO> GetCustomerRequestsByReferenceNumberAndBusinessName(string referenceNumber, string businessName)
        {
            const string selectQueryStatement = "SELECT A.* FROM CUS_REQ A, REQ_ETY_REF_NBR B WHERE "
                        + "A.BUS_UNT_KEY_CH = @BUS_UNT_KEY_CH AND B.ETY_NM = 'CUS_REQ' "
                        + "AND B.ETY_KEY_I = A.CUS_REQ_I AND B.REF_NBR = @REF_NBR";

            throw new NotImplementedException();
        }

        private List<CustomerRequestVO> BuildCustomerRequests(DataTable dataTable)
        {
            var customerRequests = new List<CustomerRequestVO>();

            foreach (DataRow currentRow in dataTable.Rows)
            {
                var customerRequest = new CustomerRequestVO
                {
                    Identity = (int)currentRow["CUS_REQ_I"],
                    Status = currentRow["PRS_STT"].ToString(),
                    BusinessEntityKey = currentRow["BUS_UNT_ETY_NM"].ToString(),
                    TypeCode = currentRow["REQ_TYP_C"].ToString(),
                    ConsumerClassificationType = currentRow["CNSM_CLS"].ToString(),
                    CreatedDate = (DateTime?)currentRow["CRT_S"],
                    CreatedUserId = currentRow["CRT_UID"].ToString(),
                    CreatedProgramCode = currentRow["CRT_PGM_C"].ToString(),
                    LastUpdatedDate = (DateTime?)currentRow["LST_UPD_S"],
                    LastUpdatedUserId = currentRow["LST_UPD_UID"].ToString(),
                    LastUpdatedProgramCode = currentRow["LST_UPD_PGM_C"].ToString()
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

            throw new NotImplementedException();
        }

        private List<AppointmentVO> BuildAppointments(DataTable dataTable)
        {
            var appointments = new List<AppointmentVO>();

            foreach (DataRow currentRow in dataTable.Rows)
            {
                var appointment = new AppointmentVO
                {
                    Identity = (int)currentRow["REQ_ETY_SCH_I"],
                    EntityName = currentRow["ETY_NM"].ToString(),
                    EntityIdentity = (int)currentRow["ETY_KEY_I"],
                    SequenceNumber = (int)currentRow["SEQ_NBR"],
                    FunctionType = currentRow["SCH_FUN_TYP"].ToString(),
                    ApptBegin = (DateTime?)currentRow["BEG_S"],
                    ApptEnd = (DateTime?)currentRow["END_S"],
                    TimeZone = currentRow["TZ_TYP_DSC"].ToString(),
                    Status = currentRow["PRS_STT"].ToString(),
                    CreatedDate = (DateTime?)currentRow["CRT_S"],
                    CreatedUserid = currentRow["CRT_UID"].ToString(),
                    CreatedProgramCode = currentRow["CRT_PGM_C"].ToString(),
                    LastUpdatedDate = (DateTime?)currentRow["LAST_UPD_S"],
                    LastUpdatedUserid = currentRow["LAST_UPD_UID"].ToString(),
                    LastUpdatedProgramCode = currentRow["LST_UPD_PGM_C"].ToString()
                };
                appointments.Add(appointment);
            }
            return appointments;
        }


        private List<CommentVO> GetCommentsByCustomerRequest(CustomerRequestVO customerRequest)
        {
            const string selectQueryStatement = "SELECT * FROM REQ_ETY_CMM WHERE ETY_NM = 'CUS_REQ' AND ETY_KEY_I = @CUS_REQ_I";

            throw new NotImplementedException();
        }

        private List<CommentVO> BuildComments(DataTable dataTable)
        {
            var comments = new List<CommentVO>();

            foreach (DataRow currentRow in dataTable.Rows)
            {
                var comment = new CommentVO
                {
                    Identity = (int)currentRow["REQ_ETY_SCH_I"],
                    EntityName = currentRow["ETY_NM"].ToString(),
                    EntityIdentity = (int)currentRow["ETY_KEY_I"],
                    SequenceNumber = (int)currentRow["SEQ_NBR"],
                    CommentType = currentRow["CMM_TYP"].ToString(),
                    CommentText = currentRow["CMM_TXT"].ToString(),
                    CreatedDate = (DateTime?)currentRow["CRT_S"],
                    CreatedUserid = currentRow["CRT_UID"].ToString(),
                    CreatedProgramCode = currentRow["CRT_PGM_C"].ToString(),
                    LastUpdatedDate = (DateTime?)currentRow["LAST_UPD_S"],
                    LastUpdatedUserid = currentRow["LAST_UPD_UID"].ToString(),
                    LastUpdatedProgramCode = currentRow["LST_UPD_PGM_C"].ToString()
                };
                comments.Add(comment);
            }
            return comments;
        }


        private List<ReferenceNumberVO> GetReferenceNumbersByCustomerRequest(CustomerRequestVO customerRequest)
        {
            const string selectQueryStatement = "SELECT * FROM REQ_ETY_REF_NBR WHERE ETY_NM = 'CUS_REQ' AND ETY_KEY_I = @CUS_REQ_I";

            throw new NotImplementedException();
        }

        private List<ReferenceNumberVO> BuildReferenceNumbers(DataTable dataTable)
        {
            var referenceNumbers = new List<ReferenceNumberVO>();

            foreach (DataRow currentRow in dataTable.Rows)
            {
                var referenceNumber = new ReferenceNumberVO
                {
                    Identity = (int)currentRow["REQ_ETY_SCH_I"],
                    EntityName = currentRow["ETY_NM"].ToString(),
                    EntityIdentity = (int)currentRow["ETY_KEY_I"],
                    SoutheasternReferenceNumberType = currentRow["SLU_REF_NBR_TYP"].ToString(),
                    ReferenceNumber = currentRow["REF_NBR"].ToString(),
                    CreatedDate = (DateTime?)currentRow["CRT_S"],
                    CreatedUserid = currentRow["CRT_UID"].ToString(),
                    CreatedProgramCode = currentRow["CRT_PGM_C"].ToString(),
                    LastUpdatedDate = (DateTime?)currentRow["LAST_UPD_S"],
                    LastUpdatedUserid = currentRow["LAST_UPD_UID"].ToString(),
                    LastUpdatedProgramCode = currentRow["LST_UPD_PGM_C"].ToString()
                };
                referenceNumbers.Add(referenceNumber);
            }
            return referenceNumbers;
        }


        private List<StopVO> GetStopsByCustomerRequest(CustomerRequestVO customerRequest)
        {
            const string selectQueryStatement = "SELECT * FROM REQ_ETY_OGN WHERE ETY_NM = 'CUS_REQ' AND ETY_KEY_I = @CUS_REQ_I";

            throw new NotImplementedException();
        }

        private List<StopVO> BuildStops(DataTable dataTable)
        {
            var stops = new List<StopVO>();

            foreach (DataRow currentRow in dataTable.Rows)
            {
                var stop = new StopVO
                {
                    Identity = (int)currentRow["REQ_ETY_SCH_I"],
                    EntityName = currentRow["ETY_NM"].ToString(),
                    EntityIdentity = (int)currentRow["ETY_KEY_I"],
                    RoleType = currentRow["SLU_PTR_RL_TYP_C"].ToString(),
                    StopNumber = currentRow["STP_NBR"].ToString(),
                    CustomerAlias = currentRow["CUS_SIT_ALS"].ToString(),
                    OrganizationName = currentRow["OGN_NM"].ToString(),
                    AddressLine1 = currentRow["ADR_LNE_1"].ToString(),
                    AddressLine2 = currentRow["ADR_LNE_2"].ToString(),
                    AddressCityName = currentRow["ADR_CTY_NM"].ToString(),
                    AddressStateCode = currentRow["ADR_ST_PROV_C"].ToString(),
                    AddressCountryCode = currentRow["ADR_CRV_C"].ToString(),
                    AddressPostalCode = currentRow["ADR_PST_C_SRG"].ToString(),
                    CreatedDate = (DateTime?)currentRow["CRT_S"],
                    CreatedUserid = currentRow["CRT_UID"].ToString(),
                    CreatedProgramCode = currentRow["CRT_PGM_C"].ToString(),
                    LastUpdatedDate = (DateTime?)currentRow["LST_UPD_S"],
                    LastUpdatedUserid = currentRow["LST_UPD_UID"].ToString(),
                    LastUpdatedProgramCode = currentRow["LST_UPD_PGM_C"].ToString()
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

            throw new NotImplementedException();
        }

        private List<CommentVO> GetCommentsByStop(StopVO stop)
        {
            const string selectQueryStatement = "SELECT * FROM REQ_ETY_CMM WHERE ETY_NM = 'REQ_ETY_OGN' AND ETY_KEY_I = @REQ_ETY_OGN_I";

            throw new NotImplementedException();
        }
    }
}
