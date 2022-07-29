using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Behavioural.Visitor
{
    /// <summary>
    /// This is another example of visitor applied to the visitable elements 
    /// for the tax calculation during holidays
    /// </summary>
    public class TaxHolidayVisitor : Visitor
    {
        public double Visit(Liquor liquorItem)
        {
            Console.WriteLine("Liquor Item: Price with tax holiday");
            double finalPriceWithFee = liquorItem.GetPrice() * 0.10 + liquorItem.GetPrice();
            finalPriceWithFee = Math.Round(finalPriceWithFee, 2);
            return finalPriceWithFee;
        }

        public double Visit(Tobacco tobaccoItem)
        {
            Console.WriteLine("Tobacco Item: Price with tax holiday");
            double finalPriceWithFee = tobaccoItem.GetPrice() * 0.15 + tobaccoItem.GetPrice();
            finalPriceWithFee = Math.Round(finalPriceWithFee, 2);
            return finalPriceWithFee;
        }

        public double Visit(Necessity necessityItem)
        {
            Console.WriteLine("Tobacco Item: Price with tax holiday");
            double finalPriceWithFee = necessityItem.GetPrice() * 0.01 + necessityItem.GetPrice();
            finalPriceWithFee = Math.Round(finalPriceWithFee, 2);
            return finalPriceWithFee;
        }
    }
}
