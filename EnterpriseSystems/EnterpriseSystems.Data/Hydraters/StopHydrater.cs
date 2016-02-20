using EnterpriseSystems.Data.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data;

namespace EnterpriseSystems.Data.Hydraters
{
    public class StopHydrater : IHydrater<StopVO>
    {
        public IEnumerable<StopVO> Hydrate(DataTable dataTable)
        {
            var stops = new List<StopVO>();

            if (dataTable != null)
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    var stop = HydrateEntity(dataRow);
                    stops.Add(stop);
                }
            }

            return stops;
        }

        private StopVO HydrateEntity(DataRow dataRow)
        {
            var stop = new StopVO
            {
                Identity = (int) dataRow["REQ_ETY_OGN_I"],
                EntityName = dataRow["ETY_NM"].ToString(),
                EntityIdentity = (int) dataRow["ETY_KEY_I"],
                RoleType = dataRow["SLU_PTR_RL_TYP_C"].ToString(),
                StopNumber = (short) dataRow["STP_NBR"],
                CustomerAlias = dataRow["CUS_SIT_ALS"].ToString(),
                OrganizationName = dataRow["OGN_NM"].ToString(),
                AddressLine1 = dataRow["ADR_LNE_1"].ToString(),
                AddressLine2 = dataRow["ADR_LNE_2"].ToString(),
                AddressCityName = dataRow["ADR_CTY_NM"].ToString(),
                AddressStateCode = dataRow["ADR_ST_PROV_C"].ToString(),
                AddressCountryCode = dataRow["ADR_CRY_C"].ToString(),
                AddressPostalCode = dataRow["ADR_PST_C_SRG"].ToString(),
                CreatedDate = (DateTime?) dataRow["CRT_S"],
                CreatedUserId = dataRow["CRT_UID"].ToString(),
                CreatedProgramCode = dataRow["CRT_PGM_C"].ToString(),
                LastUpdatedDate = (DateTime?) dataRow["LST_UPD_S"],
                LastUpdatedUserId = dataRow["LST_UPD_UID"].ToString(),
                LastUpdatedProgramCode = dataRow["LST_UPD_PGM_C"].ToString()
            };
            return stop;
        }
    }
}
