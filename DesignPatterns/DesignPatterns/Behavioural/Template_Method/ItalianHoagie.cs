using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Behavioural.Template_Method
{
    public class ItalianHoagie : Hoagie
    {
        public override void AddCheese()
        {
            throw new NotImplementedException();
        }

        public override void AddCondiments()
        {
            throw new NotImplementedException();
        }

        public override void AddMeat()
        {
            throw new NotImplementedException();
        }

        public override void AddVegetables()
        {
            throw new NotImplementedException();
        }
    }
}
