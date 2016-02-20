using EnterpriseSystems.Data.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data;

namespace EnterpriseSystems.Data.Hydraters
{
    public class CommentHydrater:IHydrater<CommentVO>
    {
        public IEnumerable<CommentVO> Hydrate(DataTable dataTable)
        {
            var comments = new List<CommentVO>();

            if (dataTable != null)
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    var comment = HydrateEntity(dataRow);
                    comments.Add(comment);
                }
            }

            return comments;
        }

        private CommentVO HydrateEntity(DataRow dataRow)
        {
            var comment = new CommentVO
            {
                Identity = (int) dataRow["REQ_ETY_CMM_I"],
                EntityName = dataRow["ETY_NM"].ToString(),
                EntityIdentity = (int) dataRow["ETY_KEY_I"],
                SequenceNumber = (short) dataRow["SEQ_NBR"],
                CommentType = dataRow["CMM_TYP"].ToString(),
                CommentText = dataRow["CMM_TXT"].ToString(),
                CreatedDate = (DateTime?) dataRow["CRT_S"],
                CreatedUserId = dataRow["CRT_UID"].ToString(),
                CreatedProgramCode = dataRow["CRT_PGM_C"].ToString(),
                LastUpdatedDate = (DateTime?) dataRow["LST_UPD_S"],
                LastUpdatedUserId = dataRow["LST_UPD_UID"].ToString(),
                LastUpdatedProgramCode = dataRow["LST_UPD_PGM_C"].ToString()
            };

            return comment;
        }
    }
}
