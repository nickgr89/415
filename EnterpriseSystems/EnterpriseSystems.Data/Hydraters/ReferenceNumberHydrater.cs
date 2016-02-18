using EnterpriseSystems.Data.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data;

namespace EnterpriseSystems.Data.Hydraters
{
    public class ReferenceNumberHydrater:IHydrater<ReferenceNumberVO>
    {
        public IEnumerable<ReferenceNumberVO> Hydrate(DataTable dataTable)
        {
            throw new NotImplementedException();
        }
    }
}
