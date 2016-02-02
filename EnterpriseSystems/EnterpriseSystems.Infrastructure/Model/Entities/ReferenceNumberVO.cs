using System;
using System.Collections.Generic;

namespace EnterpriseSystems.Infrastructure.Model.Entities
{
    public class ReferenceNumberVO
    {
        public ReferenceNumberVO()
        {
            CustomerRequests = new List<CustomerRequestVO>();
        }

        public int Identity { get; set; }
        public string EntityName { get; set; }
        public int EntityIdentity { get; set; }
        public string SoutheasternReferenceNumberType { get; set; }
        public string ReferenceNumber { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedUserId { get; set; }
        public string CreatedProgramCode { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public string LastUpdatedUserId { get; set; }
        public string LastUpdatedProgramCode { get; set; }
        public List<CustomerRequestVO> CustomerRequests { get; set; }

    }
}
