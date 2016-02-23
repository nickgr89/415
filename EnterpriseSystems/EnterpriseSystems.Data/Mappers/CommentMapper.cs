using EnterpriseSystems.Data.DAO;
using EnterpriseSystems.Data.Hydraters;
using EnterpriseSystems.Data.Model.Entities;
using System.Linq;
using EnterpriseSystems.Data.Model.Constants;

namespace EnterpriseSystems.Data.Mappers
{
    public class CommentMapper
    {
        private IDatabase Database { get; set; }
        private IHydrater<CommentVO> Hydrater { get; set; }

        public CommentMapper(IDatabase database, IHydrater<CommentVO> hydrater)
        {
            Database = database;
            Hydrater = hydrater;
        }

        public CommentVO GetCommentsByCustomerRequest(CustomerRequestVO customerRequest)
        {
            const string selectQueryStatement = "SELECT * FROM REQ_ETY_CMM WHERE ETY_NM = 'CUS_REQ' AND ETY_KEY_I = @CUS_REQ_I";

            var query = Database.CreateQuery(selectQueryStatement);
            query.AddParameter(customerRequest.Identity, CommentQueryParameters.Identity);
            var result = Database.RunSelect(query);
            var entity = Hydrater.Hydrate(result).FirstOrDefault();

            return entity;
        }
    }
}
