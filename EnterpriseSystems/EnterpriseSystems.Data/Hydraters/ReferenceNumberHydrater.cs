using EnterpriseSystems.Data.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using EnterpriseSystems.Data.Model.Constants;

namespace EnterpriseSystems.Data.Hydraters
{
    public class ReferenceNumberHydrater:IHydrater<ReferenceNumberVO>
    {
        public IEnumerable<ReferenceNumberVO> Hydrate(DataTable dataTable)
        {
            var referenceNumbers = new List<ReferenceNumberVO>();

            if (dataTable != null)
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    var referenceNumber = HydrateEntity(dataRow);
                    referenceNumbers.Add(referenceNumber);
                }
            }

            return referenceNumbers;
        }

        private ReferenceNumberVO HydrateEntity(DataRow dataRow)
        {
            var referenceNumber = new ReferenceNumberVO
            {
                Identity = (int) dataRow[ReferenceNumberColumnNames.Identity],
                EntityName = dataRow[ReferenceNumberColumnNames.EntityName].ToString(),
                EntityIdentity = (int) dataRow[ReferenceNumberColumnNames.EntityIdentity],
                ReferenceNumberType = dataRow[ReferenceNumberColumnNames.ReferenceNumberType].ToString(),
                ReferenceNumberDescription = dataRow[ReferenceNumberColumnNames.ReferenceNumberDescription].ToString(),
                ReferenceNumber = dataRow[ReferenceNumberColumnNames.ReferenceNumber].ToString(),
                CreatedDate = (DateTime?) dataRow[ReferenceNumberColumnNames.CreatedDate],
                CreatedUserId = dataRow[ReferenceNumberColumnNames.CreatedUserId].ToString(),
                CreatedProgramCode = dataRow[ReferenceNumberColumnNames.CreatedProgramCode].ToString(),
                LastUpdatedDate = (DateTime?) dataRow[ReferenceNumberColumnNames.LastUpdatedDate],
                LastUpdatedUserId = dataRow[ReferenceNumberColumnNames.LastUpdatedDate].ToString(),
                LastUpdatedProgramCode = dataRow[ReferenceNumberColumnNames.LastUpdatedProgramCode].ToString()
            };
            return referenceNumber;
        }
    }
}
