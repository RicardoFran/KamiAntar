using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamiAntar.ListException
{
    public class DriverTidakAdaException : Exception
    {
        private string _message;

        public override string Message
        {
            get { return _message; }

        }

        public DriverTidakAdaException()
        {
            _message = "Driver Tidak Ada!";
        }

        public DriverTidakAdaException(string msg)
        {
            _message = msg;
        }
    }
}
