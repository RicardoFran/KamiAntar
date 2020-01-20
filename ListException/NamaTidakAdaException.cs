using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamiAntar.ListException
{
    public class NamaTidakAdaException : Exception
    {
        private string _message;

        public override string Message
        {
            get { return _message; }
        }

        public NamaTidakAdaException()
        {
            _message = "Nama tidak ada !";
        }

        public NamaTidakAdaException(string msg)
        {
            _message = msg;
        }
    }
}
