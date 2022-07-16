using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Structural.Decorator
{
  public class Mozzarella : ToppingDecorator2
  {
    public Mozzarella(Pizza3 newPizza) : base(newPizza)
    {
      Console.WriteLine("Adding Dough");

      Console.WriteLine("Adding Moz");
    }

    public string GetDescription()
    {
      return _tempPizza.GetDescription() + ", Mozzarella";
    }


    public double GetCost()
    {
      return _tempPizza.GetCost() + 0.50;
    }
  }
}
