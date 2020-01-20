using KamiAntar.ListException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KamiAntar.Observer;
namespace KamiAntar.Singleton
{
    public class ListDriver
    {
        private static ListDriver instance;

        public List<Driver> list = null;

        private ListDriver()
        {
            list = new List<Driver>();
        }

        public static ListDriver GetListDriverInstance()
        {
            if (instance == null)
            {
                instance = new ListDriver();
            }
            return instance;
        }

        public void addDriver(string name, string notelepon, string nopolisi, string kendaraan, string password)
        {
            foreach (Driver d in list)
            {
                if (d.Name.ToLower() == name.ToLower())
                {
                    throw (new NamaSudahAdaException());
                }
            }
            Driver driver = new Driver(name, notelepon, nopolisi, kendaraan, password);
            list.Add(driver);
            Console.WriteLine("Akun Driver Berhasil Dibuat !");
        }

        public void addDriver(Driver driver)
        {
            foreach (Driver d in list)
            {
                if (d.Name.ToLower() == driver.Name.ToLower())
                {
                    throw (new NamaSudahAdaException());
                }
            }
            list.Add(driver);
        }

        public void deleteDriver(string name)
        {
            Driver driveryangdicari = searchDriver(name);
            if (driveryangdicari != null)
            {
                list.Remove(driveryangdicari);
            }
        }

        public Driver searchDriver(string name)
        {
            foreach (Driver d in list)
            {
                if (d.Name.ToLower() == name.ToLower())
                {
                    return d;
                }
            }
            throw (new NamaTidakAdaException());
        }

        public Driver searchDriver(string name, string password)
        {
            foreach (Driver d in list)
            {
                if (d.Name.ToLower() == name.ToLower() && d.Password.ToLower() == password.ToLower())
                {
                    return d;
                }
            }
            throw (new NamaTidakAdaException());
        }

        public Driver GetDriver()
        {
            foreach (Driver d in list)
            {
                if (d.Active == true)
                {
                    return d;
                }
            }
            throw (new NamaTidakAdaException());
        }

        public void PrintAllDriver()
        {
            foreach (Driver d in list)
            {
                if (d.Active == true)
                {
                    d.PrintData();
                }
            }
        }

        public void notifyObserver()
        {
            foreach (Driver d in list)
            {
                if (d.Active == true)
                {
                    new ConcreteObserver().update(d);
                }
            }
        }
    }
}
