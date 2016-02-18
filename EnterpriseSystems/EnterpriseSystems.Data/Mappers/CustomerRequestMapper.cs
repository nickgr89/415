using EnterpriseSystems.Data.DAO;
using EnterpriseSystems.Data.Hydraters;
using EnterpriseSystems.Data.Model.Entities;
using System;
using System.Collections.Generic;

namespace EnterpriseSystems.Data.Mappers
{
    public class CustomerRequestMapper
    {
        private IDatabase Database { get; set; }
        private IHydrater<CustomerRequestVO> CustomerRequestHydrater { get; set; }

        public CustomerRequestMapper(IDatabase database, IHydrater<CustomerRequestVO> customerRequestHydrater)
        {
            Database = database;
            CustomerRequestHydrater = customerRequestHydrater;
        }

        public CustomerRequestVO GetCustomerRequestByIdentity(CustomerRequestVO customerRequest)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CustomerRequestVO> GetCustomerRequestsByReferenceNumber(CustomerRequestVO customerRequest)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CustomerRequestVO> GetCustomerRequestsByReferenceNumberAndBusinessName(CustomerRequestVO customerRequest)
        {
            throw new NotImplementedException();
        }
    }
}
