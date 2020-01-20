using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamiAntar.ListException
{
    class HistoryMasihKosongException:Exception
    {
        private string _message;

        public override string Message
        {
            get { return _message; }

        }

        public HistoryMasihKosongException()
        {
            _message = "Belum Ada History !";
        }

        public HistoryMasihKosongException(string msg)
        {
            _message = msg;
        }
    }
}
