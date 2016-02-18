﻿using System.Collections.Generic;
using System;

namespace EnterpriseSystems.Infrastructure.Model.Entities
{
    public class AppointmentVO
    {
        public AppointmentVO()
        {
            Stops = new List<StopVO>();
            CustomerRequests = new List<CustomerRequestVO>();
        }

        public int Identity { get; set; }
        public string EntityName { get; set; }
        public int EntityIdentity { get; set; }
        public int SequenceNumber { get; set; }
        public string FunctionType { get; set; }
        public DateTime? AppointmentBegin { get; set; }
        public DateTime? AppointmentEnd { get; set; }
        public string TimeZoneDescription { get; set; }
        public string Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedUserId { get; set; }
        public string CreatedProgramCode { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public string LastUpdatedUserId { get; set; }
        public string LastUpdatedProgramCode { get; set; }

        public List<StopVO> Stops { get; set; }
        public List<CustomerRequestVO> CustomerRequests { get; set; }
    }
}