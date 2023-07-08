using System;

namespace App.Entities.Exceptions
{
    class DomainException : ApplicationException
    {
        public DomainException(string message) : base(message) { }

    }
}
