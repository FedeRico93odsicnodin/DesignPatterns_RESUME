using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DesignPatterns.DesignPatterns.Creational.Prototype
{
  class Main_Prototype
  {
    public static void RunExample()
    {
      // the clone factory 
      CloneFactory animalMaker = new CloneFactory();

      // the first sheep creation
      Sheep sally = new Sheep();

      // the cloned sheep 
      Sheep clonedSheep = (Sheep)animalMaker.GetClone(sally);

      // the first sheep 
      Console.WriteLine(sally.ToString());

      // the cloned sheep 
      Console.WriteLine(clonedSheep.ToString());
    }
  }
}
