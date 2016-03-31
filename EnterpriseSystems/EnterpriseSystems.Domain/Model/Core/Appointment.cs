using System;

namespace EnterpriseSystems.Domain.Model.Core
{
    public class Appointment
    {
        public DateTime Start { get; private set; }
        public DateTime End { get; private set; }
        public static readonly Appointment Empty = new Appointment(DateTime.MinValue, DateTime.MaxValue);

        public Appointment(DateTime start, DateTime end)
        {
            Start = start;
            End = end;
        }

        public bool IsEmpty()
        {
            return (this == Empty);
        }
    }

}
