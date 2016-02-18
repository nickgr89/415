using EnterpriseSystems.Data.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data;

namespace EnterpriseSystems.Data.Hydraters
{
    public class CustomerRequestHydrater : IHydrater<CustomerRequestVO>
    {
        public IEnumerable<CustomerRequestVO> Hydrate(DataTable dataTable)
        {
            var customerRequests = new List<CustomerRequestVO>();

            if (dataTable != null)
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    var customerRequest = HydrateEntity(dataRow);
                    customerRequests.Add(customerRequest);
                }
            }

            return customerRequests;
        }

        private CustomerRequestVO HydrateEntity(DataRow dataRow)
        {
            var customerRequest = new CustomerRequestVO
            {
                Identity = (int)dataRow["CUS_REQ_I"],
                Status = dataRow["PRS_STT"].ToString(),
                BusinessEntityKey = dataRow["BUS_UNT_ETY_NM"].ToString(),
                TypeCode = dataRow["REQ_TYP_C"].ToString(),
                ConsumerClassificationType = dataRow["CNSM_CLS"].ToString(),
                CreatedDate = (DateTime?)dataRow["CRT_S"],
                CreatedUserId = dataRow["CRT_UID"].ToString(),
                CreatedProgramCode = dataRow["CRT_PGM_C"].ToString(),
                LastUpdatedDate = (DateTime?)dataRow["LST_UPD_S"],
                LastUpdatedUserId = dataRow["LST_UPD_UID"].ToString(),
                LastUpdatedProgramCode = dataRow["LST_UPD_PGM_C"].ToString()
            };

            //customerRequest.Appointments = GetAppointmentsByCustomerRequest(customerRequest);
            //customerRequest.Comments = GetCommentsByCustomerRequest(customerRequest);
            //customerRequest.ReferenceNumbers = GetReferenceNumbersByCustomerRequest(customerRequest);
            //customerRequest.Stops = GetStopsByCustomerRequest(customerRequest);

            return customerRequest;
        }
    }
}
