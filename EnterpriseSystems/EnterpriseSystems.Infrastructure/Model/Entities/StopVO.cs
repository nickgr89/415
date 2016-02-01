using System;
using System.Collections.Generic;

namespace EnterpriseSystems.Infrastructure.Model.Entities
{
    public class StopVO
    {             
        public StopVO()
        {
            Appointments = new List<AppointmentVO>();
            Comments = new List<CommentVO>();
        }    

        public int Identity { get; set; }
        public String EntityName { get; set; }
        public int EntityIdentity { get; set; }
        public String RoleType { get; set; }
        public String StopNumber { get; set; }
        public String CustomerAlias { get; set; }
        public String OrganizationName { get; set; }
        public String AddressLine1 { get; set; }
        public String AddressLine2 { get; set; }
        public String AddressCityName { get; set; }
        public String AddressStateCode { get; set; }
        public String AddressCountryCode { get; set; }
        public String AddressPostalCode { get; set; }
        public DateTime? CreatedDate { get; set; }
        public String CreatedUserid { get; set; }
        public String CreatedProgramCode { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public String LastUpdatedUserid { get; set; }
        public String LastUpdatedProgramCode { get; set; }

        public List<AppointmentVO> Appointments { get; set; }
        public List<CommentVO> Comments { get; set; }
    }
}
