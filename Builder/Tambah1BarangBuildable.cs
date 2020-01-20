using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamiAntar.Builder
{
    public class Tambah1BarangBuildable : BarangBuildable
    {
        List<int> actions;
        public Tambah1BarangBuildable()
        {
        }

        public void go()
        {
            foreach  (int i in actions)
            {
                switch(i)
                {
                    case 1: Start();
                        break;
                }
            }
        }

        public void loadActions(List<int> a)
        {
            actions = a;
        }

        public void Start()
        {
            Console.WriteLine("Menambah barang");
        }
    }
}
