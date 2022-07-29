using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Behavioural.Visitor
{
    public class Liquor : Visitable
    {
        private double _price;

        public Liquor(double item)
        {
            _price = item;
        }


        /// <summary>
        ///  the right visit to the correct object 
        /// </summary>
        /// <param name="visitor"></param>
        /// <returns></returns>
        public double Accept(Visitor visitor)
        {
            return visitor.Visit(this);
        }


        public double GetPrice()
        {
            return _price;
        }
    }
}
