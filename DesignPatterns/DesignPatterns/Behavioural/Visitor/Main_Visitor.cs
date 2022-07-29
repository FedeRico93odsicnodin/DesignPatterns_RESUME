using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Behavioural.Visitor
{
    public class Main_Visitor
    {
        public static void RunExample()
        {
            // initialization of the 2 possible fee applications (Visitor)
            TaxVisitor taxCalc = new TaxVisitor();
            TaxHolidayVisitor taxHolidayCalc = new TaxHolidayVisitor();

            // initializing some products to which there's the need to apply taxes
            Necessity milk = new Necessity(3.47);
            Liquor vodka = new Liquor(11.99);
            Tobacco cigars = new Tobacco(19.99);

            // displaying normal year period price with taxes 
            Console.WriteLine(milk.Accept(taxCalc));
            Console.WriteLine(vodka.Accept(taxCalc));
            Console.WriteLine(cigars.Accept(taxCalc));

            // calculating the tax holiday prices
            Console.WriteLine("\n\nTAX HOLIDAY PRICES\n\n");

            // displaying holiday prices with taxes 
            Console.WriteLine(milk.Accept(taxHolidayCalc));
            Console.WriteLine(vodka.Accept(taxHolidayCalc));
            Console.WriteLine(cigars.Accept(taxHolidayCalc));
        }
    }
}
