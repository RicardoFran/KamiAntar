using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamiAntar.ChainOfResponsibility
{
    public class BayarMenggunakanKamiAntarWallet : IValidatorBayar
    {
        const int bmi = 1;
        IValidatorBayar successor;
        public BayarMenggunakanKamiAntarWallet(IValidatorBayar s)
        {
            successor = s;
        }

        public void GetBayar(int bayarconstant)
        {
            if(bmi == bayarconstant)
            {
                Console.WriteLine("Bayar Menggunakan KamiAntarWallet");
            }
            else
            {
                Console.WriteLine("KamiAntarWallet tidak cukup");
                successor.GetBayar(bayarconstant);
            }
        }
    }
}
