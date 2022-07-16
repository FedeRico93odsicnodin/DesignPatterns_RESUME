using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Structural.Decorator
{
  public class ToppingDecorator2 : Pizza3
  {
    protected Pizza3 _tempPizza;

    public ToppingDecorator2(Pizza3 newPizza)
    {
      _tempPizza = newPizza;
    }


    public double GetCost()
    {
      return _tempPizza.GetCost();
    }

    public string GetDescription()
    {
      return _tempPizza.GetDescription();
    }
  }
}
