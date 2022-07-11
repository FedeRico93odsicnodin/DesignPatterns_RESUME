using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Behavioural.Strategy
{
  /// <summary>
  /// Representation of a dog
  /// </summary>
  public class Dog : Animal_Implementation4
  {
    public void DigHole()
    {
      Console.WriteLine("Dug a hole");
    }

    public Dog()
    {
      Sound = "Bark";
      // setting the variable dynamically when constructing the object 
      FlyingType = new CantFly();
    }
  }
  /// <summary>
  /// Representation of a bird
  /// </summary>
  public class Bird : Animal_Implementation4
  {
    public Bird()
    {
      Sound = "Tweet";
      FlyingType = new ItFlys();
    }
  }
}
