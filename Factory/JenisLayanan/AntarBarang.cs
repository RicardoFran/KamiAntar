using KamiAntar.Strategy.JenisPembayaran;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamiAntar.Factory.JenisLayanan
{
    public class AntarBarang : Layanan
    {
        public AntarBarang(string strategi)
        {
            Name = "Antar Barang";
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
