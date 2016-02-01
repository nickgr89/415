using System;

namespace EnterpriseSystems.Infrastructure.Model.Entities
{
    public class AppointmentVO
    {
        public int Identity { get; set; }
        public String EntityName { get; set; }
        public int EntityIdentity { get; set; }
        public int SequenceNumber { get; set; }
        public String FunctionType { get; set; }
        public DateTime? ApptBegin { get; set; }
        public DateTime? ApptEnd { get; set; }
        public String TimeZone { get; set; }
        public String Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public String CreatedUserid { get; set; }
        public String CreatedProgramCode { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public String LastUpdatedUserid { get; set; }
        public String LastUpdatedProgramCode { get; set; }
    }
}
