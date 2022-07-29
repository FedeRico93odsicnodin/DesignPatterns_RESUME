using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Behavioural.Template_Method
{
    public class VeggieHoagie : Hoagie
    {
        private string[] _veggiesUsed = { "Lettuce", "Tomatoes", "Onions", "Sweet Peppers" };
        private string[] _condimentsUsed = { "Oil", "Vinegar" };

        /// <summary>
        /// Overriding for not adding the elements concerning the meats and the cheeses 
        /// to the current veggie sandwich
        /// </summary>
        /// <returns></returns>
        public override bool CustomerWantsMeat()
        {
            return false;
        }


        public override bool CustomerWantsCheese()
        {
            return false;
        }


        public override void AddCheese()
        {
            // nothing to do
        }

        public override void AddCondiments()
        {
            Console.WriteLine("Adding the Condiments\n");
            for (int i = 0; i < _condimentsUsed.Length; i++)
                Console.Write(_condimentsUsed[0] + " ");
        }

        public override void AddMeat()
        {
            // nothing to do
        }

        public override void AddVegetables()
        {
            Console.WriteLine("Adding the Vegetables\n");
            for (int i = 0; i < _veggiesUsed.Length; i++)
                Console.Write(_veggiesUsed[0] + " ");
        }
    }
}
