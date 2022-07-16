using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Structural.Decorator
{
  public class PlainPizza : Pizza3
  {
    public double GetCost()
    {
      return 4;
    }

    public string GetDescription()
    {
      return "Thin Dough";
    }
  }
}
