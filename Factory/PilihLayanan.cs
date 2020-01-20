using KamiAntar.Factory.JenisLayanan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamiAntar.Factory
{
    public class PilihLayanan : AbstractPilihanPelayanan
    {
        public override Layanan pilihLayanan(string pilihObject, string strategi)
        {
            Layanan layanan = new Layanan();
            if (pilihObject == "1")
            {
                layanan = new AntarBarang(strategi);
            }
            else if (pilihObject == "2")
            {
                layanan = new AntarJemput(strategi);
            }
            return layanan;
        }
    }
}
