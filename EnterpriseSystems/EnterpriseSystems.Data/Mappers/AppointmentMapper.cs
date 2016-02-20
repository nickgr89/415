using EnterpriseSystems.Data.DAO;
using EnterpriseSystems.Data.Hydraters;
using EnterpriseSystems.Data.Model.Constants;
using EnterpriseSystems.Data.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EnterpriseSystems.Data.Mappers
{
    public class AppointmentMapper
    {
        private IDatabase Database { get; set; }
        private IHydrater<AppointmentVO> Hydrater { get; set; }

        public AppointmentMapper(IDatabase database, IHydrater<AppointmentVO> hydrater)
        {
            Database = database;
            Hydrater = hydrater;
        }

        public AppointmentVO GetAppointmentByCustomerRequest(CustomerRequestVO customerRequest)
        {
            const string selectQueryStatement = "SELECT * FROM REQ_ETY_SCH WHERE ETY_NM = 'CUS_REQ' AND ETY_KEY_I = @CUS_REQ_I";

            var query = Database.CreateQuery(selectQueryStatement);
            query.AddParameter(customerRequest.Identity, AppointmentQueryParameters.Identity);
            var result = Database.RunSelect(query);
            var entity = Hydrater.Hydrate(result).FirstOrDefault();

            return entity;
        }

        public IEnumerable<AppointmentVO> GetAppointmentsByStop(AppointmentVO appointment)
        {
            var stop = appointment.Stops;

            const string selectQueryStatement = "SELECT A.* FROM CUS_REQ A, REQ_ETY_REF_NBR B WHERE "
                                    + "B.ETY_NM = 'CUS_REQ' AND B.ETY_KEY_I = A.CUS_REQ_I AND "
                                    + "B.REF_NBR = @REF_NBR";
            var query = Database.CreateQuery(selectQueryStatement);
            query.AddParameter(stop, AppointmentQueryParameters.Stop);
            var result = Database.RunSelect(query);
            var entity = Hydrater.Hydrate(result).FirstOrDefault();
            yield return entity;
        }
    }
}
