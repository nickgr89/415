using EnterpriseSystems.Domain.Model.Core;
using System;
using System.Linq;
using System.Security.Cryptography;
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
            var order = new Order();

            //// test 2/9, Create_SetsOrderNumberFromBillOfLading
            //var orderNum = (from refNum 
            //    in customerRequest.ReferenceNumbers
            //    where (refNum.ReferenceNumberType == ReferenceNumberTypes.BillOfLading)
            //    select refNum.ReferenceNumber).First();
            //order.OrderNumber = new OrderNumber(orderNum);


            //// test 3/9 Create_SetsOriginFromFirstStop
            //var origin = (from stop
            //    in customerRequest.Stops
            //    select stop).OrderByDescending(x => x.StopNumber).First();

            //var address = new Address(origin.AddressLine1, origin.AddressLine2, origin.AddressCityName,origin.AddressStateCode, origin.AddressPostalCode);
            //order.Origin = new Facility(origin.OrganizationName, address);


            //// test 4/9, Create_SetsDestinationFromLastStop
            //var destination = (from stop
            //    in customerRequest.Stops
            //    select stop).OrderByDescending(x => x.StopNumber).Last();

            //var address1 = new Address(destination.AddressLine1, destination.AddressLine2, destination.AddressCityName,destination.AddressStateCode, destination.AddressPostalCode);
            //order.Origin = new Facility(destination.OrganizationName, address1);


            //// test 5/9, Create_SetsWorkTypeFromConsumerClassificationType
            //var consumer = customerRequest.ConsumerClassificationType;
            //if (consumer == "HOMEDELVR")
            //{
            //    order.WorkType = WorkType.Home;
            //}else if (consumer == "BLDRDIRECT" || consumer == "BLDRINDRCT")
            //{
            //    order.WorkType = WorkType.Builder;
            //}else
            //{
            //    order.WorkType = WorkType.Retail;
            //}


            //// test 6/9, Create_SetsLegTypeToDeliveryWhenLastStopIsShipTo
            //var status = (from stop
            //    in customerRequest.Stops
            //    select stop).OrderByDescending(x => x.StopNumber).Last();
            //if (status.RoleType == StopRoleTypes.ShipTo)
            //{
            //    order.LegType = LegType.Delivery;
            //}


            //// test 7/9, Create_SetsScheduledFromFinalAppointmentWhenExists
            //var final = (from appt
            //    in customerRequest.Appointments
            //    select appt).OrderByDescending(x => x.FunctionType).First();
            //if (final.FunctionType != null)
            //{
            //    order.Scheduled = new Appointment(final.AppointmentBegin.Value, final.AppointmentEnd.Value);
            //}
            //else
            //{
            //    // test 8/9, Create_SetsScheduledEmptyWhenFinalAppointmentNotExists
            //    order.Scheduled.IsEmpty();
            //}


            //// test 9/9, Create_SetsProjectFromBusinessEntityKey
            //order.Project = customerRequest.BusinessEntityKey;


            return order;
        }

        public static Order SetsOrderNumber(CustomerRequestVO customerRequest, Order order)
        {
            // test 2/9, Create_SetsOrderNumberFromBillOfLading
            var orderNum = (from refNum
                in customerRequest.ReferenceNumbers
                            where (refNum.ReferenceNumberType == ReferenceNumberTypes.BillOfLading)
                            select refNum.ReferenceNumber).First();
            order.OrderNumber = new OrderNumber(orderNum);

            return order;
            
        }

        public static Order SetsOrigin(CustomerRequestVO customerRequest, Order order)
        {
            // test 3/9 Create_SetsOriginFromFirstStop
            var origin = (from stop
                in customerRequest.Stops
                          select stop).OrderByDescending(x => x.StopNumber).First();

            var address = new Address(origin.AddressLine1, origin.AddressLine2, origin.AddressCityName, origin.AddressStateCode, origin.AddressPostalCode);
            order.Origin = new Facility(origin.OrganizationName, address);

            return order;
        }

        public static Order SetsDestinationFromLastStop(CustomerRequestVO customerRequest, Order order)
        {
            // test 4/9, Create_SetsDestinationFromLastStop
            var destination = (from stop
                in customerRequest.Stops
                               select stop).OrderByDescending(x => x.StopNumber).Last();

            var address1 = new Address(destination.AddressLine1, destination.AddressLine2, destination.AddressCityName, destination.AddressStateCode, destination.AddressPostalCode);
            order.Origin = new Facility(destination.OrganizationName, address1);

            return order;
        }

        public static Order SetsWorkType(CustomerRequestVO customerRequest, Order order)
        {
            // test 5/9, Create_SetsWorkTypeFromConsumerClassificationType
            var consumer = customerRequest.ConsumerClassificationType;
            if (consumer == "HOMEDELVR")
            {
                order.WorkType = WorkType.Home;
            }
            else if (consumer == "BLDRDIRECT" || consumer == "BLDRINDRCT")
            {
                order.WorkType = WorkType.Builder;
            }
            else
            {
                order.WorkType = WorkType.Retail;
            }

            return order;
        }

        public static Order SetsLegType(CustomerRequestVO customerRequest, Order order)
        {
            // test 6/9, Create_SetsLegTypeToDeliveryWhenLastStopIsShipTo
            var status = (from stop
                in customerRequest.Stops
                          select stop).OrderByDescending(x => x.StopNumber).Last();
            if (status.RoleType == StopRoleTypes.ShipTo)
            {
                order.LegType = LegType.Delivery;
            }

            return order;
        }

        public static Order SetsScheduled(CustomerRequestVO customerRequest, Order order)
        {
            // test 7/9, Create_SetsScheduledFromFinalAppointmentWhenExists
            var final = (from appt
                in customerRequest.Appointments
                         select appt).OrderByDescending(x => x.FunctionType).First();
            if (final.FunctionType != null)
            {
                order.Scheduled = new Appointment(final.AppointmentBegin.Value, final.AppointmentEnd.Value);
            }
            else
            {
                // test 8/9, Create_SetsScheduledEmptyWhenFinalAppointmentNotExists
                order.Scheduled.IsEmpty();
            }

            return order;
        }

        public static Order SetsProject(CustomerRequestVO customerRequest, Order order)
        {
            // test 9/9, Create_SetsProjectFromBusinessEntityKey
            order.Project = customerRequest.BusinessEntityKey;

            return order;
        }
    }
}
