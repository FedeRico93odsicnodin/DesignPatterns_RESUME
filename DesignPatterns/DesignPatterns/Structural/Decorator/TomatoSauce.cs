using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Structural.Decorator
{
  public class TomatoSauce : ToppingDecorator2
  {
    public TomatoSauce(Pizza3 newPizza) : base(newPizza)
    {
      Console.WriteLine("Adding Sauce");
    }

    public string GetDescription()
    {
      return _tempPizza.GetDescription() + ", Tomato Sauce";
    }


    public double GetCost()
    {
      return _tempPizza.GetCost() + 0.35;
    }
  }
}
