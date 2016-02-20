using EnterpriseSystems.Data.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data;

namespace EnterpriseSystems.Data.Hydraters
{
    public class AppointmentHydrater:IHydrater<AppointmentVO>
    {
        public IEnumerable<AppointmentVO> Hydrate(DataTable dataTable)
        {
            var appointments = new List<AppointmentVO>();

            if (dataTable != null)
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    var appointment = HydrateEntity(dataRow);
                    appointments.Add(appointment);
                }
            }

            return appointments;
        }

        private AppointmentVO HydrateEntity(DataRow dataRow)
        {
            var appointment = new AppointmentVO
            {
                Identity = (int) dataRow["REQ_ETY_SCH_I"],
                EntityName = dataRow["ETY_NM"].ToString(),
                EntityIdentity = (int) dataRow["ETY_KEY_I"],
                SequenceNumber = (short?) dataRow["SEQ_NBR"],
                FunctionType = dataRow["SCH_FUN_TYP"].ToString(),
                AppointmentBegin = (DateTime?) dataRow["BEG_S"],
                AppointmentEnd = (DateTime?) dataRow["END_S"],
                TimezoneDescription = dataRow["TZ_TYP_DSC"].ToString(),
                Status = dataRow["PRS_STT"].ToString(),
                CreatedDate = (DateTime?) dataRow["CRT_S"],
                CreatedUserId = dataRow["CRT_UID"].ToString(),
                CreatedProgramCode = dataRow["CRT_PGM_C"].ToString(),
                LastUpdatedDate = (DateTime?) dataRow["LST_UPD_S"],
                LastUpdatedUserId = dataRow["LST_UPD_UID"].ToString(),
                LastUpdatedProgramCode = dataRow["LST_UPD_PGM_C"].ToString()
            };

            return appointment;
        }
    }
}
