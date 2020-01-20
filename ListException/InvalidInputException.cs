using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamiAntar.ListException
{
    public class InvalidInputException:Exception
    {
        private string _message;

        public override string Message
        {
            get { return _message; }

        }

        public InvalidInputException()
        {
            _message = "Input tidak valid!";
        }

        public InvalidInputException(string msg)
        {
            _message = msg;
        }
    }
}
