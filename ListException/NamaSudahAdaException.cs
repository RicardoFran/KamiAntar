using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamiAntar.ListException
{
    public class NamaSudahAdaException:Exception
    {
        private string _message;

        public override string Message
        {
            get { return _message; }

        }

        public NamaSudahAdaException()
        {
            _message = "Nama Sudah Ada!";
        }

        public NamaSudahAdaException(string msg)
        {
            _message = msg;
        }
    }
}
