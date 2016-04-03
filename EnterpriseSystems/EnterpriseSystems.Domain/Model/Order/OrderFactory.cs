using EnterpriseSystems.Domain.Model.Core;
using System;
using System.Linq;
using EnterpriseSystems.Data.Model.Entities;

namespace EnterpriseSystems.Domain.Model.Order
{
    public class OrderFactory : IOrderFactory
    {
        private static OrderFactory _order;


        // test 1/9, GetInstance_ReturnsSingletonInstance
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

            // test 2/9, Create_SetsOrderNumberFromBillOfLading
            var orderNum = (from refNum 
                in customerRequest.ReferenceNumbers
                where (refNum.ReferenceNumberType == ReferenceNumberTypes.BillOfLading)
                select refNum.ReferenceNumber).First();
            _order.OrderNumber = new OrderNumber(orderNum);


            // test 3/9 Create_SetsOriginFromFirstStop
            var origin = (from stop
                in customerRequest.Stops
                /*where (stop.StopNumber == 1)*/
                select stop).First();



            /*_order.Origin.Name = origin.OrganizationName;
            _order.Origin.Address.AddressLines[0] = origin.AddressLine1;
            _order.Origin.Address.AddressLines.[1] = origin.AddressLine2;
            _order.Origin.Address.City = origin.AddressCityName;
            _order.Origin.Address.StateCode = origin.AddressStateCode;
            _order.Origin.Address.PostalCode = origin.AddressPostalCode;


            // test 4/9, Create_SetsDestinationFromLastStop
            var destination = from stop
                in customerRequest.Stops
                where (stop.StopNumber == 2)
                select stop;
            _order.Origin.Name = destination.OrganizationName;
            _order.Origin.Address.AddressLines[0] = destination.AddressLine1;
            _order.Origin.Address.AddressLines[1] = destination.AddressLine2;
            _order.Origin.Address.City = destination.AddressCityName;
            _order.Origin.Address.StateCode = destination.AddressStateCode;
            _order.Origin.Address.PostalCode = destination.AddressPostalCode;


            // test 5/9, Create_SetsWorkTypeFromConsumerClassificationType
            var consumer = customerRequest.ConsumerClassificationType;
            if (consumer == "HOMEDELVR")
            {
                _order.WorkType = WorkType.Home;
            }else if (consumer == "BLDRDIRECT" || consumer == "BLDRINDRCT")
            {
                _order.WorkType = WorkType.Builder;
            }else
            {
                _order.WorkType = WorkType.Retail;
            }*/



            return _order;
        }
    }
}
