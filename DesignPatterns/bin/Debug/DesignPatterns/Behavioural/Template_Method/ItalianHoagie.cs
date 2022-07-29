using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Behavioural.Template_Method
{
    public class ItalianHoagie : Hoagie
    {
        private string[] _meatUsed = { "Salami", "Pepperoni", "Capicola Ham" };
        private string[] _cheeseUsed = { "Provolone" };
        private string[] _veggiesUsed = { "Lettuce", "Tomatoes", "Onions", "Sweet Peppers" };
        private string[] _condimentsUsed = { "Oil", "Vinegar" };


        /// <summary>
        /// Specializations for the Italian sandwich
        /// </summary>
        public override void AddCheese()
        {
            Console.WriteLine("Adding the Cheese\n");
            for (int i = 0; i < _cheeseUsed.Length; i++)
                Console.Write(_cheeseUsed[0] + " ");
        }

        public override void AddCondiments()
        {
            Console.WriteLine("Adding the Condiments\n");
            for (int i = 0; i < _condimentsUsed.Length; i++)
                Console.Write(_condimentsUsed[0] + " ");
        }

        public override void AddMeat()
        {
            Console.WriteLine("Adding the Meat\n");
            for (int i = 0; i < _meatUsed.Length; i++)
                Console.Write(_meatUsed[0] + " ");
        }

        public override void AddVegetables()
        {
            Console.WriteLine("Adding the Vegetables\n");
            for (int i = 0; i < _veggiesUsed.Length; i++)
                Console.Write(_veggiesUsed[0] + " "); 
        }
    }
}
