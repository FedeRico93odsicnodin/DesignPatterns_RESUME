using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Creational.Prototype
{
  public class Sheep : Animal
  {
    /// <summary>
    /// Implementation of the make copy for the sheep
    /// </summary>
    /// <returns></returns>
    public override Animal MakeCopy()
    {
      Console.WriteLine("Sheep is being made");
      Sheep sheepObject = null;
      // cloning the sheep by the mean of the ICloneable interface
      sheepObject = (Sheep)base.Clone(); 
      return sheepObject;
    }
    /// <summary>
    /// To string override
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
      return "Dolly is my Hero, Baaaaah";
    }
  }
}
