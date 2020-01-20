using KamiAntar.Strategy.JenisPembayaran;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamiAntar.Factory.JenisLayanan
{
    public class AntarJemput : Layanan
    {
        public AntarJemput(string strategi)
        {
            Name = "Antar Jemput";
            if (strategi == "1")
            {
                this.SetStrategiPembayaran(new Cash());
            }
            else if (strategi == "2")
            {
                this.SetStrategiPembayaran(new KamiAntarWallet());
            }
        }
    }
}
