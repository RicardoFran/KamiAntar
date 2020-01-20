using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamiAntar.Flyweight
{
    public class PrintListDriver
    {
        //Flyweight Pattern
        public void PrintAllDriver(List<Driver> listdriver)
        {
            //Iterator Pattern
            foreach(Driver driver in listdriver)
            {
                driver.PrintDriver();
                Console.Write("");
            }
        }
    }
}
