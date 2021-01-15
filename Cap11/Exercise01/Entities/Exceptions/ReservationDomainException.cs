using System;
using System.Collections.Generic;
using System.Text;

namespace Cap11.Exercise01.Entities.Exceptions
{
    class ReservationDomainException : ApplicationException
    {
        public ReservationDomainException(string message) : base(message) { }
    }
}
