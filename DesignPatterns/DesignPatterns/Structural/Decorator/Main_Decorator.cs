using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Structural.Decorator
{
  public class Main_Decorator
  {
    public static void RunExample()
    {
      // adding the different components dynamically for creating the pizza we want 
      Pizza3 basicPizza = new TomatoSauce(new Mozzarella(new PlainPizza()));
    }
  }
}
