using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamiAntar.Observer
{
    public class ConcreteObserver
    {
        public void update(Driver d)
        {
            Console.WriteLine(d.Name + " " + d.NoTelepon + " " + d.NoPolisi + " " + d.Kendaraan);
        }
    }
}
