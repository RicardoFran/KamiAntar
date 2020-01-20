using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamiAntar.ChainOfResponsibility
{
    public class BayarMenggunakanCash : IValidatorBayar
    {
        public void GetBayar(int bayarconstant)
        {
            Console.WriteLine("Bayar Menggunakan Cash");
        }
    }
}
