using KamiAntar.ListException;
using KamiAntar.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamiAntar
{
    public class User:MasterTemplate
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw (new NamaTidakAdaException("Nama tidak boleh kosong !"));
                _name = value;
            }
        }
        private string _notelepon;

        public string NoTelepon
        {
            get { return _notelepon; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw (new InvalidInputException("Input tidak boleh kosong !"));
                _notelepon = value;
            }
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw (new InvalidInputException("Input tidak boleh kosong !"));
                _password = value;
            }
        }

        public int Poin { get; set; }

        private decimal _kamiantarwallet;

        public decimal KamiAntarWallet
        {
            get { return _kamiantarwallet; }
            set
            {
                if (value<10000)
                    throw (new InvalidInputException("Input tidak boleh dibawah Rp.10.000,00 !"));
                _kamiantarwallet = value;
            }
        }

        public User(string name,string notelepon,string password,decimal kamiantarwallet)
        {
            Name = name;
            NoTelepon = notelepon;
            Password = password;
            KamiAntarWallet = kamiantarwallet;
            Poin = 0;
        }

        public override void PrintData()
        {
            Console.WriteLine(Name + " " + NoTelepon);
        }

        public void SetKamiAntarWallet(decimal saldo)
        {
            KamiAntarWallet += saldo;
        }
    }
}
