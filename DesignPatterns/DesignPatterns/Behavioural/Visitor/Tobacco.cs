using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Behavioural.Visitor
{
    public class Tobacco : Visitable
    {
        private double _price;


        public Tobacco(double price)
        {
            _price = price;
        }


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
