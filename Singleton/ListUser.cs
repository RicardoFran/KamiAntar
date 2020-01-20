using KamiAntar.ListException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace KamiAntar.Singleton
{
    public class ListUser
    {
        private static ListUser instance;

        public List<User> list = null;

        private ListUser()
        {
            list = new List<User>();
        }

        public static ListUser GetListUserInstance()
        {
                if (instance == null)
                {
                    instance = new ListUser();
                }
                return instance;
        }

        public void addUser(string name, string notelepon, string password, decimal kamiantarwallet)
        {
            foreach (User u in list)
            {
                if (u.Name.ToLower() == name.ToLower())
                {
                    throw (new NamaSudahAdaException());
                }
            }
            User user = new User(name, notelepon, password, kamiantarwallet);
            list.Add(user);
            Console.WriteLine("Akun User Berhasil Dibuat !");
        }

        public void addUser(User user)
        {
            foreach (User u in list)
            {
                if (u.Name.ToLower() == user.Name.ToLower())
                {
                    throw (new NamaSudahAdaException());
                }
            }
            list.Add(user);
        }

        public void deleteUser(string name)
        {
            User useryangdicari = searchUser(name);
            if (useryangdicari != null)
            {
                list.Remove(useryangdicari);
            }
        }

        public User searchUser(string name)
        {
            foreach (User u in list)
            {
                if (u.Name.ToLower() == name.ToLower())
                {
                    return u;
                }
            }
            throw (new NamaTidakAdaException());
        }

        public User searchUser(string name, string password)
        {
            foreach (User u in list)
            {
                if (u.Name.ToLower() == name.ToLower() && u.Password.ToLower() == password.ToLower())
                {
                    return u;
                }
            }
            throw (new NamaTidakAdaException());
        }

        public void PrintAllUser()
        {
            foreach (User u in list)
            {
                u.PrintData();
            }
        }
    }
}
