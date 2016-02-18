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
            throw new NotImplementedException();
        }
    }
}
