using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Structural.Decorator
{
  /// <summary>
  /// A first implementation of the Pizza
  /// </summary>
  public abstract class Pizza
  {
    public abstract void SetDescription(string newDescription);

    public abstract string GetDescription();

    public abstract double GetCost();
  }
}
