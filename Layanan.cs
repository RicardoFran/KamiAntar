using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KamiAntar.Strategy;

namespace KamiAntar
{
    public class Layanan
    {
        public string Name { get; set; }
        public Driver Driver { get; set; }
        public User User { get; set; }
        public decimal Tagihan { get; set; }

        public Layanan(){}
        public Layanan(string name,Driver driver,User user,decimal tagihan)
        {
            Name = name;
            Driver = driver;
            User = user;
            Tagihan = tagihan;
        }
        private IStrategiPembayaran strategiPembayaran;
        public void SetStrategiPembayaran(IStrategiPembayaran strategiPembayaran)
        {
            this.strategiPembayaran = strategiPembayaran;
        }
        public void Jenisstrategi()
        {
            strategiPembayaran.jenispembayaran();
        }

    }
}
