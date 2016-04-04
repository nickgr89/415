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
                select stop).OrderByDescending(x => x.StopNumber).First();

            var address = new Address(origin.AddressLine1, origin.AddressLine2, origin.AddressCityName,origin.AddressStateCode, origin.AddressPostalCode);
            _order.Origin = new Facility(origin.OrganizationName, address);


            // test 4/9, Create_SetsDestinationFromLastStop
            var destination = (from stop
                in customerRequest.Stops
                select stop).OrderByDescending(x => x.StopNumber).Last();

            var address1 = new Address(destination.AddressLine1, destination.AddressLine2, destination.AddressCityName,destination.AddressStateCode, destination.AddressPostalCode);
            _order.Origin = new Facility(destination.OrganizationName, address1);


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
            }


            // test 6/9, Create_SetsLegTypeToDeliveryWhenLastStopIsShipTo
            var status = (from stop
                in customerRequest.Stops
                select stop).OrderByDescending(x => x.StopNumber).Last();
            if (status.RoleType == StopRoleTypes.ShipTo)
            {
                _order.LegType = LegType.Delivery;
            }


            // test 7/9, Create_SetsScheduledFromFinalAppointmentWhenExists
            var final = (from appt
                in customerRequest.Appointments
                select appt).OrderByDescending(x => x.FunctionType).First();
            if (final.FunctionType != null)
            {
                _order.Scheduled = new Appointment(final.AppointmentBegin.Value, final.AppointmentEnd.Value);
            }
            else
            {
                // test 8/9, Create_SetsScheduledEmptyWhenFinalAppointmentNotExists
                _order.Scheduled.IsEmpty();
            }


            // test 9/9, Create_SetsProjectFromBusinessEntityKey
            _order.Project = customerRequest.BusinessEntityKey;


            return _order;
        }
    }
}
