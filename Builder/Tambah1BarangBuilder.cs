using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamiAntar.Builder
{
    public class Tambah1BarangBuilder : BarangBuilder
    {
        Tambah1BarangBuildable barang;
        List<int> actions;

        public Tambah1BarangBuilder()
        {
            barang = new Tambah1BarangBuildable();
            actions = new List<int>();
        }

        public void Additem()
        {
            actions.Add(1);
        }

        public BarangBuildable getBarang()
        {
            barang.loadActions(actions);
            return barang;
        }
    }
}
