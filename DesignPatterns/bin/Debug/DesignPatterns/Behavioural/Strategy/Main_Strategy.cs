using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Behavioural.Strategy
{
  public class Main_Strategy
  {
    public static void RunExample()
    {
      // first creation of the dog 
      Animal_Implementation4 sparky = new Dog();
      // second representation of a bird
      Animal_Implementation4 treety = new Bird();
      // visualizing the ability to fly
      Console.WriteLine("Dog: " + sparky.TryToFly());
      Console.WriteLine("Bird: " + treety.TryToFly());

      // set the ability to fly DYNAMICALLY
      sparky.SetFlyingAbility(new ItFlys());
      Console.WriteLine("Dog: " + sparky.TryToFly());
    }
  }
}
