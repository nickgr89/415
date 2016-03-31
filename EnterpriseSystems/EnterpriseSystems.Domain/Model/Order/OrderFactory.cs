using EnterpriseSystems.Domain.Model.Core;
using System;
using System.Linq;
using EnterpriseSystems.Data.Model.Entities;

namespace EnterpriseSystems.Domain.Model.Order
{
    public class OrderFactory : IOrderFactory
    {
        private static OrderFactory instance;

        public static OrderFactory GetInstance()
        {

                if (instance == null) {
                    instance = new OrderFactory();
                }
                return instance;            

        }

        public Order Create(CustomerRequestVO customerRequest)
        {
            return ((IOrderFactory)instance).Create(customerRequest);
        }
    }
}
