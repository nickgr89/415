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
            throw new NotImplementedException();
        }
    }
}
