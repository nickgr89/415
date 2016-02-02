using System;
using System.Collections.Generic;

namespace EnterpriseSystems.Infrastructure.Model.Entities
{
    public class StopVO
    {
        public StopVO()
        {

            CustomerRequests = new List<CustomerRequestVO>();
            Appointments = new List<AppointmentVO>();

        }

        public int Identity { get; set; }
        public string EntityName { get; set; }
        public int EntityIdentity { get; set; }
        public string RoleType { get; set; }
        public string StopNumber { get; set; }
        public string CustomerAlias { get; set; }
        public string OrganizationName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressCityName { get; set; }
        public string AddressStateCode { get; set; }
        public string AddressCountryCode { get; set; }
        public string AddressPostalCode { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedUserId { get; set; }
        public string CreatedProgramCode { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public string LastUpdatedUserId { get; set; }
        public string LastUpdatedProgramCode { get; set; }
        public List<CustomerRequestVO> CustomerRequests { get; set; }
        public List<AppointmentVO> Appointments { get; set; }

    }
}
