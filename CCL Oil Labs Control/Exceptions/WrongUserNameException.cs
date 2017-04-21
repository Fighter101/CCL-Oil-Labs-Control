using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCL_Oil_Labs_Control.Exceptions
{
    class WrongUserNameException : Exception
    {
        public WrongUserNameException(string message) : base(message)
        {
        }
    }
}
