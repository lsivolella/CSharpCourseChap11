using System;
using System.Collections.Generic;
using System.Text;

namespace Cap11.Exercise02.Entities.Exceptions
{
    class AccountDomainException : ApplicationException
    {
        public AccountDomainException(string message) : base(message) { }
    }
}
