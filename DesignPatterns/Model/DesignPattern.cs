using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Model
{
    /// <summary>
    /// Modellazione per la descrizione del desgin pattern corrente 
    /// </summary>
    public class DesignPattern
    {
        public int ID { get; set; }


        public string Name { get; set; }


        public int DesignType_ID { get; set; }


        public bool HasExample { get; set; }
    }
}
