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
            throw new NotImplementedException();
        }
    }
}
