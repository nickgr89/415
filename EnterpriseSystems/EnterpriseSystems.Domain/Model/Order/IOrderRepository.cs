using EnterpriseSystems.Domain.Model.Core;
using System.Collections.Generic;

namespace EnterpriseSystems.Domain.Model.Order
{
    public interface IOrderRepository
    {
        IEnumerable<Order> FindByScheduledAndFacility(Appointment scheduled, Facility facility);
        IEnumerable<Order> FindByOrderNumber(OrderNumber orderNumber);
    }
}
