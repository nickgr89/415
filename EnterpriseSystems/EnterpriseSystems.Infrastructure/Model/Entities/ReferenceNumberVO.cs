using System;

namespace EnterpriseSystems.Infrastructure.Model.Entities
{
    public class ReferenceNumberVO
    {
        public int Identity { get; set; }
        public String EntityName { get; set; }
        public int EntityIdentity { get; set; }
        public String SoutheasternReferenceNumberType { get; set; }
        public String ReferenceNumber { get; set; }
        public DateTime? CreatedDate { get; set; }
        public String CreatedUserid { get; set; }
        public String CreatedProgramCode { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public String LastUpdatedUserid { get; set; }
        public String LastUpdatedProgramCode { get; set; }
    }
}
