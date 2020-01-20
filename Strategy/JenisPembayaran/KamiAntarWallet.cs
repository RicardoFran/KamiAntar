using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamiAntar.Strategy.JenisPembayaran
{
    public class KamiAntarWallet : IStrategiPembayaran
    {
        public string jenispembayaran()
        {
            return "Memakai KamiAntarWallet";
        }
    }
}
