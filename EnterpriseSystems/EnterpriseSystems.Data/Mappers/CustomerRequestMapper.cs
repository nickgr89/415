using EnterpriseSystems.Data.DAO;
using EnterpriseSystems.Data.Hydraters;
using EnterpriseSystems.Data.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EnterpriseSystems.Data.Mappers
{
    public class CustomerRequestMapper
    {
        private IDatabase Database { get; set; }
        private IHydrater<CustomerRequestVO> Hydrater { get; set; }

        public CustomerRequestMapper(IDatabase database, IHydrater<CustomerRequestVO> hydrater)
        {
            Database = database;
            Hydrater = hydrater;
        }

        public CustomerRequestVO GetCustomerRequestByIdentity(CustomerRequestVO customerRequest)
        {
            const string selectQueryStatement = "SELECT * FROM CUS_REQ WHERE CUS_REQ_I = @CUS_REQ_I";

            var query = Database.CreateQuery(selectQueryStatement);
            query.AddParameter(customerRequest.Identity, "@CUS_REQ_I");
            var result = Database.RunSelect(query);
            var entity = Hydrater.Hydrate(result).FirstOrDefault();

            return entity;
        }

        public IEnumerable<CustomerRequestVO> GetCustomerRequestsByReferenceNumber(CustomerRequestVO customerRequest)
        {
            var referenceNumber = customerRequest.ReferenceNumbers.First().ReferenceNumber;

            throw new NotImplementedException();
        }

        public IEnumerable<CustomerRequestVO> GetCustomerRequestsByReferenceNumberAndBusinessName(CustomerRequestVO customerRequest)
        {
            var referenceNumber = customerRequest.ReferenceNumbers.First().ReferenceNumber;
            var businessName = customerRequest.BusinessEntityKey;

            throw new NotImplementedException();
        }
    }
}
