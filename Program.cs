
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KamiAntar.ListException;
using KamiAntar.Decorator;
using KamiAntar.Decorator.JenisContentLayanan;
using KamiAntar.Factory;
using KamiAntar.Singleton;
using KamiAntar.ChainOfResponsibility;
using KamiAntar.Builder;

namespace KamiAntar
{
    class Program
    {
        static void Main(string[] args)
        {
            #region List Driver+User+Layanan
            //List penampung driver user layanan
            ListDriver listdriver;
            listdriver = ListDriver.GetListDriverInstance();
            ListUser listuser;
            listuser = ListUser.GetListUserInstance();
            listlayanan = new List<Layanan>();
            #endregion

            #region Validator Pilihan Menu Utama
            //Variabel validator pilihan menu
            string pilmenuutama = "";
            #endregion

            #region Data Awal
            //Data dummy awal
            Driver d1= new Driver("jim", "9087", "D 1831", "mobil", "jim");
            listdriver.addDriver(d1);
            Driver d2 = new Driver("ricardo", "0878", "D 5973", "motor", "ricardo");
            listdriver.addDriver(d2);
            User u1 = new User("lydia", "5432", "lydia", 1000000);
            listuser.addUser(u1);
            User u2 = new User("dennis", "3456", "dennis", 1000000);
            listuser.addUser(u2);
            
            string lokasiantar;
            string lokasijemput;
            string lokasipickup;
            string detaillayanan;
            string barang;
            int jarak;
            decimal tagihan;
            decimal kamiantarwallet;
            Random rnd = new Random();
            BayarMenggunakanKamiAntarWallet bmkaw;
            BayarMenggunakanCash bmi;
            IContentLayanan contentLayanan;

            string pilihlayanan;
            string pilihmetodepembayaran;
            Driver driver;
            User user;

            Layanan layanan;
            AbstractPilihanPelayanan createlayanan;

            BarangBuilder builder;
            BarangBuildable barangpesanan;
            builder = new Tambah1BarangBuilder();
            int input,total;
            #endregion

            while (pilmenuutama != "0")
            {
                #region Validator Menu User+Driver
                string menudriver1 = "";
                string menudriver2 = "";
                string menuuser1 = "";
                string menuuser2 = "";
                #endregion
                Console.WriteLine("--------------------------------");
                Console.WriteLine("Kami Antar Application ~");
                Console.WriteLine("1. Sebagai Driver");
                Console.WriteLine("2. Sebagai User");
                Console.WriteLine("0. Exit");
                Console.Write("Pilihan : ");
                try
                {
                    pilmenuutama = Console.ReadLine();

                    if (pilmenuutama == "1")
                    {
                        Console.WriteLine("--------------------------------");
                        Console.WriteLine("1. Daftar");
                        Console.WriteLine("2. Login");
                        Console.WriteLine("0. Kembali");
                        Console.Write("Pilihan : ");
                        menudriver1 = Console.ReadLine();
                        while (menudriver1 != "0")
                        {
                            if (menudriver1 == "1")
                            {
                                try
                                {
                                    Console.WriteLine("--------------------------------");
                                    Console.WriteLine("Daftar Driver Kami Antar");
                                    Console.Write("Nama : ");
                                    string nama = Console.ReadLine();
                                    Console.Write("No.Telepon : ");
                                    string notelepon = Console.ReadLine();
                                    Console.Write("Kendaraan : ");
                                    string kendaraan = Console.ReadLine();
                                    Console.Write("No.Polisi : ");
                                    string nopolisi = Console.ReadLine();
                                    Console.Write("Password : ");
                                    string password = Console.ReadLine();
                                    listdriver.addDriver(nama, notelepon, nopolisi, kendaraan, password);
                                    Console.WriteLine("--------------------------------");
                                    while (menudriver2 != "0")
                                    {
                                        driver = listdriver.searchDriver(nama);
                                        menudriver2 = "";
                                        Console.WriteLine("--------------------------------");
                                        Console.WriteLine("Nama : "+driver.Name);
                                        if(driver.Active==true)
                                        {
                                            Console.WriteLine("Status Driver : Aktif");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Status Driver : Tidak Aktif");
                                        }
                                        Console.WriteLine();
                                        Console.WriteLine("Rating : " + driver.Rating);
                                        Console.WriteLine("Menu Driver");
                                        Console.WriteLine("1. Aktif");
                                        Console.WriteLine("2. Non Aktif");
                                        Console.WriteLine("3. Lihat History");
                                        Console.WriteLine("4. Log out");
                                        Console.Write("Pilihan : ");
                                        menudriver2 = Console.ReadLine();
                                        if(menudriver2 == "1")
                                        {
                                            driver.Active = true;
                                        }
                                        else if(menudriver2 == "2")
                                        {
                                            driver.Active = false;
                                        }
                                        else if (menudriver2 == "3")
                                        {
                                            try
                                            {
                                                PrintHistoryDriver(driver.Name);
                                            }
                                            catch(HistoryMasihKosongException ex)
                                            {
                                                Console.WriteLine(ex.Message);
                                            }
                                        }
                                        else if (menudriver2 == "4")
                                        {
                                            menudriver1 = "0";
                                            menudriver2 = "0";
                                        }
                                        else
                                        {
                                            throw (new InvalidInputException());
                                        }
                                    }
                                }
                                catch (NamaSudahAdaException ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                                catch (InvalidInputException ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                            }
                            else if (menudriver1 == "2")
                            {
                                try
                                {
                                    Console.WriteLine("--------------------------------");
                                    Console.WriteLine("-LogIn-");
                                    Console.Write("Masukkan Nama : ");
                                    string nama = Console.ReadLine();
                                    Console.Write("Password : ");
                                    string password = Console.ReadLine();
                                    if (listdriver.searchDriver(nama,password) != null)
                                    {
                                        while (menudriver2 != "0")
                                        {
                                            driver = listdriver.searchDriver(nama);
                                            menudriver2 = "";
                                            Console.WriteLine("--------------------------------");
                                            Console.WriteLine("Nama : " + driver.Name);
                                            if (driver.Active == true)
                                            {
                                                Console.WriteLine("Status Driver : Aktif");
                                            }
                                            else
                                            {
                                                Console.WriteLine("Status Driver : Tidak Aktif");
                                            }
                                            Console.WriteLine();
                                            Console.WriteLine("Rating : " + driver.Rating);
                                            Console.WriteLine("Menu Driver");
                                            Console.WriteLine("1. Aktif");
                                            Console.WriteLine("2. Non Aktif");
                                            Console.WriteLine("3. Lihat History");
                                            Console.WriteLine("4. Log out");
                                            Console.Write("Pilihan : ");
                                            menudriver2 = Console.ReadLine();
                                            if (menudriver2 == "1")
                                            {
                                                driver.Active = true;
                                            }
                                            else if (menudriver2 == "2")
                                            {
                                                driver.Active = false;
                                            }
                                            else if (menudriver2 == "3")
                                            {
                                                try
                                                {
                                                    PrintHistoryDriver(driver.Name);
                                                }
                                                catch (HistoryMasihKosongException ex)
                                                {
                                                    Console.WriteLine(ex.Message);
                                                }
                                            }
                                            else if (menudriver2 == "4")
                                            {
                                                menudriver1 = "0";
                                                menudriver2 = "0";
                                            }
                                            else
                                            {
                                                throw (new InvalidInputException());
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Login Gagal!");
                                        break;
                                    }
                                }
                                catch (NamaTidakAdaException ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                            }
                        }
                    }
                    else if (pilmenuutama == "2")
                    {
                        Console.WriteLine("--------------------------------");
                        Console.WriteLine("1. Daftar");
                        Console.WriteLine("2. Login");
                        Console.WriteLine("0. Kembali");
                        Console.Write("Pilihan : ");
                        menuuser1 = Console.ReadLine();
                        if (menuuser1 == "1")
                        {
                            try
                            {
                                Console.WriteLine("--------------------------------");
                                Console.WriteLine("Daftar User Kami Antar");
                                Console.Write("Nama : ");
                                string nama = Console.ReadLine();
                                Console.Write("No.Telepon : ");
                                string notelepon = Console.ReadLine();
                                Console.Write("Password : ");
                                string password = Console.ReadLine();
                                Console.WriteLine("TopUp KamiAntarWallet : ");
                                Console.WriteLine("Minimal TopUp Rp.10.000,00");
                                Console.Write("Input Saldo : ");
                                decimal.TryParse(Console.ReadLine(),out kamiantarwallet);
                                listuser.addUser(nama, notelepon,password,kamiantarwallet);
                                Console.WriteLine("--------------------------------");
                                while (menuuser2 != "0")
                                {
                                    user = listuser.searchUser(nama);

                                    menuuser2 = "";
                                    Console.WriteLine("--------------------------------");
                                    Console.WriteLine("Nama : " + user.Name);
                                    Console.WriteLine("Saldo KamiAntarWallet : Rp." + user.KamiAntarWallet);
                                    Console.WriteLine();
                                    Console.WriteLine("Menu User");
                                    Console.WriteLine("1. Kami Antar Jemput");
                                    Console.WriteLine("2. Kami Antar Barang");
                                    Console.WriteLine("3. Lihat History");
                                    Console.WriteLine("4. Topup KamiAntarWallet");
                                    Console.WriteLine("5. Log out");
                                    Console.Write("Pilihan : ");
                                    menuuser2 = Console.ReadLine();
                                    if (menuuser2 == "1")
                                    {
                                        Console.WriteLine("--------------------------------");
                                        createlayanan = new PilihLayanan();
                                        driver = listdriver.GetDriver();
                                        Console.WriteLine("Dapat Driver !");
                                        Console.WriteLine("Nama Driver : " + driver.Name);
                                        Console.Write("Lokasi Jemput : ");
                                        lokasijemput = Console.ReadLine();
                                        Console.Write("Lokasi Antar : ");
                                        lokasiantar = Console.ReadLine();
                                        jarak = rnd.Next(50, 5000);
                                        Console.WriteLine("Jarak : " + Convert.ToString(jarak) + " Meter");
                                        tagihan = jarak * 500;
                                        Console.WriteLine("Total Tagihan : Rp." + tagihan);
                                        Console.WriteLine("Pilih Metode Pembayaran : ");
                                        Console.WriteLine("1.Cash");
                                        Console.WriteLine("2.KamiAntarWallet");
                                        Console.Write("Pilih : ");
                                        pilihmetodepembayaran = Console.ReadLine();
                                        contentLayanan = new ContentLayanan("Nama User : " + user.Name);
                                        if (pilihmetodepembayaran == "1")
                                        {
                                            layanan = createlayanan.pilihLayanan("1", "1");
                                            layanan.Jenisstrategi();
                                            detaillayanan = layanan.Name;
                                            addLayanan(driver, user, detaillayanan, tagihan);
                                        }
                                        else if (pilihmetodepembayaran == "2")
                                        {
                                            bmi = new BayarMenggunakanCash();
                                            bmkaw = new BayarMenggunakanKamiAntarWallet(bmi);
                                            if(user.KamiAntarWallet < tagihan)
                                            {
                                                bmkaw.GetBayar(2);
                                                layanan = createlayanan.pilihLayanan("1", "1");
                                                layanan.Jenisstrategi();
                                                detaillayanan = layanan.Name;
                                                addLayanan(driver, user, detaillayanan, tagihan);
                                            }
                                            else
                                            {
                                                bmkaw.GetBayar(1);
                                                user.KamiAntarWallet -= tagihan;
                                                layanan = createlayanan.pilihLayanan("1", "2");
                                                layanan.Jenisstrategi();
                                                detaillayanan = layanan.Name;
                                                addLayanan(driver, user, detaillayanan, tagihan);
                                            }
                                        }
                                        Console.WriteLine("--------------------------------");
                                        Console.WriteLine("Driver On The Way");
                                        Console.WriteLine("Driver Tiba");
                                        Console.WriteLine("Driver Selesai Mengantar");
                                    }
                                    else if (menuuser2 == "2")
                                    {
                                        Console.WriteLine("--------------------------------");
                                        createlayanan = new PilihLayanan();
                                        driver = listdriver.GetDriver();
                                        Console.WriteLine("Dapat Driver !");
                                        Console.WriteLine("Nama Driver : " + driver.Name);
                                        Console.Write("Barang yang ingin diantar : ");
                                        barang = Console.ReadLine();
                                        Console.Write("Lokasi PickUp Barang : ");
                                        lokasipickup = Console.ReadLine();
                                        input = 0;
                                        total = 0;
                                        while (input != 2)
                                        {
                                            input = Menu(builder, input);
                                            total += 1;
                                        }
                                        barangpesanan = builder.getBarang();
                                        barangpesanan.go();
                                        Console.Write("Lokasi Antar : ");
                                        lokasiantar = Console.ReadLine();
                                        jarak = rnd.Next(50, 5000);
                                        Console.WriteLine("Jarak : " + Convert.ToString(jarak) + " Meter");
                                        contentLayanan = new ContentLayanan("Nama Barang : " + barang + " dengan " + total + " barang lainnya ,");
                                        Console.WriteLine("Pilih Jenis Layanan : ");
                                        Console.WriteLine("1.Express");
                                        Console.WriteLine("2.Reguler");
                                        Console.Write("Pilihan : ");
                                        pilihlayanan = Console.ReadLine();
                                        if (pilihlayanan == "1")
                                        {
                                            Express(contentLayanan);
                                        }
                                        else if (pilihlayanan == "2")
                                        {
                                            Reguler(contentLayanan);
                                        }
                                        tagihan = jarak * 500;
                                        Console.WriteLine("Total Tagihan : Rp." + tagihan);
                                        Console.WriteLine("Pilih Metode Pembayaran : ");
                                        Console.WriteLine("1.Cash");
                                        Console.WriteLine("2.KamiAntarWallet");
                                        Console.Write("Pilih : ");
                                        pilihmetodepembayaran = Console.ReadLine();
                                        if (pilihmetodepembayaran == "1")
                                        {
                                            layanan = createlayanan.pilihLayanan("2", "1");
                                            layanan.Jenisstrategi();
                                            Console.Write(" ");
                                            detaillayanan = layanan.Name;
                                            addLayanan(driver, user, detaillayanan, tagihan);
                                        }
                                        else if (pilihmetodepembayaran == "2")
                                        {
                                            bmi = new BayarMenggunakanCash();
                                            bmkaw = new BayarMenggunakanKamiAntarWallet(bmi);
                                            bmkaw.GetBayar(1);
                                            if (user.KamiAntarWallet < tagihan)
                                            {
                                                layanan = createlayanan.pilihLayanan("2", "1");
                                                layanan.Jenisstrategi();
                                                detaillayanan = layanan.Name;
                                                addLayanan(driver, user, detaillayanan, tagihan);
                                            }
                                            else
                                            {
                                                user.KamiAntarWallet -= tagihan;
                                                layanan = createlayanan.pilihLayanan("2", "2");
                                                layanan.Jenisstrategi();
                                                detaillayanan = layanan.Name;
                                                addLayanan(driver, user, detaillayanan, tagihan);
                                            }
                                        }
                                    }
                                    else if (menuuser2 == "3")
                                    {
                                        try
                                        {
                                            PrintHistoryUser(user.Name);
                                        }
                                        catch (HistoryMasihKosongException ex)
                                        {
                                            Console.WriteLine(ex.Message);
                                        }
                                    }
                                    else if (menuuser2 == "4")
                                    {
                                        try
                                        {
                                            listdriver.notifyObserver();
                                        }
                                        catch (InvalidInputException ex)
                                        {
                                            Console.WriteLine(ex.Message);
                                        }
                                    }
                                    else if (menuuser2 == "5")
                                    {
                                        try
                                        {
                                            Console.WriteLine("TopUp KamiAntarWallet : ");
                                            Console.WriteLine("Minimal TopUp Rp.10.000,00");
                                            Console.Write("Input Saldo : ");
                                            decimal.TryParse(Console.ReadLine(), out kamiantarwallet);
                                            user.SetKamiAntarWallet(kamiantarwallet);
                                        }
                                        catch (InvalidInputException ex)
                                        {
                                            Console.WriteLine(ex.Message);
                                        }
                                    }
                                    else if (menuuser2 == "6")
                                    {
                                        menuuser1 = "0";
                                        menuuser2 = "0";
                                    }
                                    else
                                    {
                                        throw (new InvalidInputException());
                                    }
                                }
                            }
                            catch (NamaSudahAdaException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            catch (InvalidInputException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                        else if (menuuser1 == "2")
                        {
                            try
                            {
                                Console.WriteLine("--------------------------------");
                                Console.WriteLine("-LogIn-");
                                Console.Write("Masukkan Nama : ");
                                string nama = Console.ReadLine();
                                Console.Write("Password : ");
                                string password = Console.ReadLine();
                                if (listuser.searchUser(nama,password) != null)
                                {
                                    while (menuuser2 != "0")
                                    {
                                        user = listuser.searchUser(nama);
                                        menuuser2 = "";
                                        Console.WriteLine("--------------------------------");
                                        Console.WriteLine("Nama : " + user.Name);
                                        Console.WriteLine("Saldo KamiAntarWallet : Rp." + user.KamiAntarWallet);
                                        Console.WriteLine();
                                        Console.WriteLine("Menu User");
                                        Console.WriteLine("1. Kami Antar Jemput");
                                        Console.WriteLine("2. Kami Antar Barang");
                                        Console.WriteLine("3. Lihat History");
                                        Console.WriteLine("4. Lihat Driver sekitar anda");
                                        Console.WriteLine("5. Topup KamiAntarWallet");
                                        Console.WriteLine("6. Log out");
                                        Console.Write("Pilihan : ");
                                        menuuser2 = Console.ReadLine();
                                        if (menuuser2 == "1")
                                        {
                                            Console.WriteLine("--------------------------------");
                                            createlayanan = new PilihLayanan();
                                            driver = listdriver.GetDriver();
                                            Console.WriteLine("Dapat Driver !");
                                            Console.WriteLine("Nama Driver : " + driver.Name);
                                            Console.Write("Lokasi Jemput : ");
                                            lokasijemput = Console.ReadLine();
                                            Console.Write("Lokasi Antar : ");
                                            lokasiantar = Console.ReadLine();
                                            jarak = rnd.Next(50, 5000);
                                            Console.WriteLine("Jarak : " + Convert.ToString(jarak) + " Meter");
                                            tagihan = jarak * 500;
                                            Console.WriteLine("Total Tagihan : Rp." + tagihan);
                                            Console.WriteLine("Pilih Metode Pembayaran : ");
                                            Console.WriteLine("1.Cash");
                                            Console.WriteLine("2.KamiAntarWallet");
                                            Console.Write("Pilih : ");
                                            pilihmetodepembayaran = Console.ReadLine();
                                            contentLayanan = new ContentLayanan("Nama User : " + user.Name);
                                            if (pilihmetodepembayaran == "1")
                                            {
                                                layanan = createlayanan.pilihLayanan("1", "1");
                                                layanan.Jenisstrategi();
                                                detaillayanan = layanan.Name;
                                                addLayanan(driver, user, detaillayanan, tagihan);
                                            }
                                            else if (pilihmetodepembayaran == "2")
                                            {
                                                bmi = new BayarMenggunakanCash();
                                                bmkaw = new BayarMenggunakanKamiAntarWallet(bmi);
                                                if (user.KamiAntarWallet < tagihan)
                                                {
                                                    bmkaw.GetBayar(2);
                                                    layanan = createlayanan.pilihLayanan("1", "1");
                                                    layanan.Jenisstrategi();
                                                    detaillayanan = layanan.Name;
                                                    addLayanan(driver, user, detaillayanan, tagihan);
                                                }
                                                else
                                                {
                                                    bmkaw.GetBayar(1);
                                                    user.KamiAntarWallet -= tagihan;
                                                    layanan = createlayanan.pilihLayanan("1", "2");
                                                    layanan.Jenisstrategi();
                                                    detaillayanan = layanan.Name;
                                                    addLayanan(driver, user, detaillayanan, tagihan);
                                                }
                                            }
                                            Console.WriteLine("--------------------------------");
                                            Console.WriteLine("Driver On The Way");
                                            Console.WriteLine("Driver Tiba");
                                            Console.WriteLine("Driver Selesai Mengantar");
                                            driver.Rating += 1;
                                        }
                                        else if (menuuser2 == "2")
                                        {
                                            Console.WriteLine("--------------------------------");
                                            createlayanan = new PilihLayanan();
                                            driver = listdriver.GetDriver();
                                            Console.WriteLine("Dapat Driver !");
                                            Console.WriteLine("Nama Driver : " + driver.Name);
                                            Console.Write("Barang yang ingin diantar : ");
                                            barang = Console.ReadLine();
                                            Console.Write("Lokasi PickUp Barang : ");
                                            lokasipickup = Console.ReadLine();
                                            input = 0;
                                            total = 0;
                                            while(input!=2)
                                            {
                                                input = Menu(builder, input);
                                                total += 1;
                                            }
                                            barangpesanan = builder.getBarang();
                                            barangpesanan.go();
                                            Console.Write("Lokasi Antar : ");
                                            lokasiantar = Console.ReadLine();
                                            jarak = rnd.Next(50, 5000);
                                            Console.WriteLine("Jarak : " + Convert.ToString(jarak) + " Meter");
                                            contentLayanan = new ContentLayanan("Nama Barang : " + barang + " dengan "+total+" barang lainnya ,");
                                            Console.WriteLine("Pilih Jenis Layanan : ");
                                            Console.WriteLine("1.Express");
                                            Console.WriteLine("2.Reguler");
                                            Console.Write("Pilihan : ");
                                            pilihlayanan = Console.ReadLine();
                                            if (pilihlayanan == "1")
                                            {
                                                Express(contentLayanan);
                                            }
                                            else if (pilihlayanan == "2")
                                            {
                                                Reguler(contentLayanan);
                                            }
                                            tagihan = jarak * 500;
                                            Console.WriteLine("Total Tagihan : Rp." + tagihan);
                                            Console.WriteLine("Pilih Metode Pembayaran : ");
                                            Console.WriteLine("1.Cash");
                                            Console.WriteLine("2.KamiAntarWallet");
                                            Console.Write("Pilih : ");
                                            pilihmetodepembayaran = Console.ReadLine();
                                            if (pilihmetodepembayaran == "1")
                                            {
                                                layanan = createlayanan.pilihLayanan("2", "1");
                                                layanan.Jenisstrategi();
                                                detaillayanan = layanan.Name;
                                                addLayanan(driver, user, detaillayanan, tagihan);
                                            }
                                            else if (pilihmetodepembayaran == "2")
                                            {
                                                bmi = new BayarMenggunakanCash();
                                                bmkaw = new BayarMenggunakanKamiAntarWallet(bmi);
                                                if (user.KamiAntarWallet < tagihan)
                                                {
                                                    bmkaw.GetBayar(2);
                                                    layanan = createlayanan.pilihLayanan("1", "1");
                                                    layanan.Jenisstrategi();
                                                    detaillayanan = layanan.Name;
                                                    addLayanan(driver, user, detaillayanan, tagihan);
                                                }
                                                else
                                                {
                                                    bmkaw.GetBayar(1);
                                                    user.KamiAntarWallet -= tagihan;
                                                    layanan = createlayanan.pilihLayanan("1", "2");
                                                    layanan.Jenisstrategi();
                                                    detaillayanan = layanan.Name;
                                                    addLayanan(driver, user, detaillayanan, tagihan);
                                                }
                                            }
                                            Console.WriteLine("--------------------------------");
                                            Console.WriteLine("Driver On The Way");
                                            Console.WriteLine("Driver Pickup Barang");
                                            Console.WriteLine("Driver Selesai Mengantar");
                                            driver.Rating += 1;
                                        }
                                        else if (menuuser2 == "3")
                                        {
                                            try
                                            {
                                                PrintHistoryUser(user.Name);
                                            }
                                            catch (HistoryMasihKosongException ex)
                                            {
                                                Console.WriteLine(ex.Message);
                                            }
                                        }
                                        else if (menuuser2 == "4")
                                        {
                                            try
                                            {
                                                listdriver.notifyObserver();
                                            }
                                            catch (InvalidInputException ex)
                                            {
                                                Console.WriteLine(ex.Message);
                                            }
                                        }
                                        else if (menuuser2 == "5")
                                        {
                                            try
                                            {
                                                Console.WriteLine("TopUp KamiAntarWallet : ");
                                                Console.WriteLine("Minimal TopUp Rp.10.000,00");
                                                Console.Write("Input Saldo : ");
                                                decimal.TryParse(Console.ReadLine(), out kamiantarwallet);
                                                user.SetKamiAntarWallet(kamiantarwallet);
                                            }
                                            catch (InvalidInputException ex)
                                            {
                                                Console.WriteLine(ex.Message);
                                            }
                                        }
                                        else if (menuuser2 == "6")
                                        {
                                            menuuser1 = "0";
                                            menuuser2 = "0";
                                        }
                                        else
                                        {
                                            throw (new InvalidInputException());
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Login Gagal!");
                                    break;
                                }
                            }
                            catch (NamaTidakAdaException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                    }
                    else
                    {
                        throw(new InvalidInputException());
                    }                   
                }
                catch (InvalidInputException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        #region List Layanan
        static List<Layanan> listlayanan;

        static void addLayanan(Driver driver,User user,string name,decimal tagihan)
        {
            Layanan layanan = new Layanan(name, driver, user, tagihan);
            listlayanan.Add(layanan);
        }
        #endregion

        #region Decorator Content Layanan
        static void Express(IContentLayanan contentLayanan)
        {
            ExpressContentLayananDecorator express = new ExpressContentLayananDecorator(contentLayanan);
            Console.WriteLine(express.GetContents());
        }
        static void Reguler(IContentLayanan contentLayanan)
        {
            RegulerContentLayananDecorator reguler = new RegulerContentLayananDecorator(contentLayanan);
            Console.WriteLine(reguler.GetContents());
        }
        #endregion

        #region Flyweight Pattern+Itterator
        static void PrintHistoryUser(string name)
        {
            Console.WriteLine();
            foreach (Layanan l in listlayanan)
            {
                if(l.User.Name==name)
                {
                    Console.WriteLine("Jenis Layanan : "+l.Name+", Dengan Tagihan : "+l.Tagihan+ ", Nama Driver : " + l.Driver.Name);
                }
            }
        }
        static void PrintHistoryDriver(string name)
        {
            Console.WriteLine();
            foreach (Layanan l in listlayanan)
            {
                if (l.Driver.Name == name)
                {
                    Console.WriteLine("Jenis Layanan : " + l.Name + ", Dengan Tagihan : " + l.Tagihan + ", Nama Pemesan : " + l.User.Name);
                }
            }
        }
        #endregion

        private static int Menu(BarangBuilder builder,int input)
        {
            Console.WriteLine("Tambah Barang:");
            Console.WriteLine("1.Yes");
            Console.WriteLine("2.No");
            int.TryParse(Console.ReadLine(), out input);
            switch (input)
            {
                case 1: builder.Additem();
                    break;
                case 2: break;
            }
            return input;
        }
    }
}