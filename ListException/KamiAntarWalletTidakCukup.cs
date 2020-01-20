using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamiAntar.ListException
{
    public class KamiAntarWalletTidakCukup : Exception
    {
        private string _message;

        public override string Message
        {
            get { return _message; }

        }

        public KamiAntarWalletTidakCukup()
        {
            _message = "KamiAntarWallet Tidak Cukup!";
        }

        public KamiAntarWalletTidakCukup(string msg)
        {
            _message = msg;
        }
    }
}
