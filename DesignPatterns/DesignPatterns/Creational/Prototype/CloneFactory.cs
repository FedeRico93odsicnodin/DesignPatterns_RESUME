using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Creational.Prototype
{
  /// <summary>
  /// Clone factory creation for making the copy of every animal 
  /// which implements the clonable interface
  /// </summary>
  public class CloneFactory
  {
    public Animal GetClone(Animal animalSample)
    {
      // simply return the make copy implemented by the class
      return animalSample.MakeCopy();
    }
  }
}
