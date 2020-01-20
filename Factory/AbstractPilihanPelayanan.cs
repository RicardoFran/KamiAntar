using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamiAntar.Factory
{
    public abstract class AbstractPilihanPelayanan
    {
        public abstract Layanan pilihLayanan(string pilihObject, string strategi);
        public Layanan getLayanan(string pilihObject, string strategi)
        {
            Layanan layanan = pilihLayanan(pilihObject, strategi);
            return layanan;
        }
    }
}
