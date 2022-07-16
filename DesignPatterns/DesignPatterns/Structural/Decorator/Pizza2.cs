using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Structural.Decorator
{
  public abstract class Pizza2
  {
    public abstract void SetDescription(string newDescription);

    public abstract string GetDescription();

    public abstract double GetCost();

    /// <summary>
    /// Added property: this has to be added to the n pizzas extending the Pizza class
    /// </summary>
    /// <returns></returns>
    public abstract bool HasFontina();
  }
}
