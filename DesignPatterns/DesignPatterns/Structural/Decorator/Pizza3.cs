using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Structural.Decorator
{
  /// <summary>
  /// Basic element for the decorator 
  /// </summary>
  public interface Pizza3
  {
    string GetDescription();

    double GetCost();
  }
}
