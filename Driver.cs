using KamiAntar.ListException;
using KamiAntar.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamiAntar
{
    public class Driver:MasterTemplate
    {
        public int Rating { get; set; }

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
        private string _nopolisi;

        public string NoPolisi
        {
            get { return _nopolisi; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw (new InvalidInputException("Input tidak boleh kosong !"));
                _nopolisi = value;
            }
        }
        private string _kendaraan;

        public string Kendaraan
        {
            get { return _kendaraan; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw (new InvalidInputException("Input tidak boleh kosong !"));
                _kendaraan = value;
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
        public User Penumpang { get; set; }
        public bool Active { get; set; }
        public Driver(string name,string notelepon,string nopolisi,string kendaraan,string password)
        {
            Name = name;
            NoTelepon = notelepon;
            NoPolisi = nopolisi;
            Kendaraan = kendaraan;
            Password = password;
            Active = true;
            Rating = 0;
        }
        public void AddPenumpang(User penumpang)
        {
            Penumpang = penumpang;
        }
        public override void PrintData()
        {
            Console.WriteLine(Name+" "+NoTelepon+" "+NoPolisi+" "+Kendaraan);
        }
    }
}
