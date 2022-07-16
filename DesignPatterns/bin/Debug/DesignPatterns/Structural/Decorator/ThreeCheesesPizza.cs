using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Structural.Decorator
{
  public class ThreeCheesesPizza : Pizza
  {
    private string _description = "Mozzarella, Fontina, Parmesan, Cheese Pizza";

    public override double GetCost()
    {
      return 10;
    }

    public override string GetDescription()
    {
      return _description;
    }

    public override void SetDescription(string newDescription)
    {
      _description = newDescription;
    }
  }
}
