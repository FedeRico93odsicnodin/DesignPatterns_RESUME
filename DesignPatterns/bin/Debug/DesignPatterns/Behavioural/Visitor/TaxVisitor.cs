using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Behavioural.Visitor
{
    public class TaxVisitor : Visitor
    {
        /// <summary>
        /// Calculates total price based on this being taxed 
        /// as liquor item
        /// </summary>
        /// <param name="liquorItem"></param>
        /// <returns></returns>
        public double Visit(Liquor liquorItem)
        {
            Console.WriteLine("Liquor Item: Price with tax");
            double finalPriceWithFee = liquorItem.GetPrice() * 0.18 + liquorItem.GetPrice();
            finalPriceWithFee = Math.Round(finalPriceWithFee, 2);
            return finalPriceWithFee;
        }

        /// <summary>
        /// Calculates total price based on this being taxed
        /// as tobacco item
        /// </summary>
        /// <param name="tobaccoItem"></param>
        /// <returns></returns>
        public double Visit(Tobacco tobaccoItem)
        {
            Console.WriteLine("Tobacco Item: Price with tax");
            double finalPriceWithFee = tobaccoItem.GetPrice() * 0.32 + tobaccoItem.GetPrice();
            finalPriceWithFee = Math.Round(finalPriceWithFee, 2);
            return finalPriceWithFee;
        }

        /// <summary>
        /// Calculate total price based on this being taxed 
        /// as necessity item
        /// </summary>
        /// <param name="necessityItem"></param>
        /// <returns></returns>
        public double Visit(Necessity necessityItem)
        {
            Console.WriteLine("Tobacco Item: Price with tax");
            double finalPriceWithFee = necessityItem.GetPrice() * 0.02 + necessityItem.GetPrice();
            finalPriceWithFee = Math.Round(finalPriceWithFee, 2);
            return finalPriceWithFee;
        }
    }
}
