using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Behavioural.Template_Method
{
    public class Main_Template_Method
    {
        public static void RunExample()
        {
            // creating a new Italian sandwich (ingredients and preparation)
            ItalianHoagie cust12Hoagie = new ItalianHoagie();

            // making the sandwich
            cust12Hoagie.MakeSandwich();

            Console.WriteLine("\n\n");

            // creating a new Veggie hoagie
            VeggieHoagie cust13Hoagie = new VeggieHoagie();

            // making the sandwich
            cust13Hoagie.MakeSandwich();
        }
    }
}
