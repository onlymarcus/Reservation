using System;
using System.Collections.Generic;
using System.Text;

namespace Courseres.Entities.Exceptions
{
    class DomainExcepcion : ApplicationException

    {
        public DomainExcepcion(string message) : base(message)
        {
        }
    }
}
