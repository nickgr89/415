using EnterpriseSystems.Domain.Model.Core;
using System;
using System.Linq;
using EnterpriseSystems.Data.Model.Entities;

namespace EnterpriseSystems.Domain.Model.Order
{
    public class OrderFactory : IOrderFactory
    {
        private static OrderFactory _order;






        // test 1/9
        public static OrderFactory GetInstance()
        {
                if (_order == null) {
                _order = new OrderFactory();
                }
                return _order;
        }

        public Order Create(CustomerRequestVO customerRequest)
        {
            var _order = new Order();

            // test 2/9
            var result = from refNum 
                in customerRequest.ReferenceNumbers
                where (refNum.ReferenceNumberType == ReferenceNumberTypes.BillOfLading)
                select refNum.ReferenceNumber;
            _order.OrderNumber = result;




            return _order;
        }
    }
}
