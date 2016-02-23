using EnterpriseSystems.Data.DAO;
using EnterpriseSystems.Data.Hydraters;
using EnterpriseSystems.Data.Model.Entities;
using System.Linq;
using EnterpriseSystems.Data.Model.Constants;

namespace EnterpriseSystems.Data.Mappers
{
    public class StopMapper
    {
        private IDatabase Database { get; set; }
        private IHydrater<StopVO> Hydrater { get; set; }

        public StopMapper(IDatabase database, IHydrater<StopVO> hydrater)
        {
            Database = database;
            Hydrater = hydrater;
        }

        public StopVO GetStopsByCustomerRequest(CustomerRequestVO customerRequest)
        {
            const string selectQueryStatement = "SELECT * FROM REQ_ETY_OGN WHERE ETY_NM = 'CUS_REQ' AND ETY_KEY_I = @CUS_REQ_I";

            var query = Database.CreateQuery(selectQueryStatement);
            query.AddParameter(customerRequest.Identity, StopQueryParameters.Identity);
            var result = Database.RunSelect(query);
            var entity = Hydrater.Hydrate(result).FirstOrDefault();

            return entity;
        }
    }
}
