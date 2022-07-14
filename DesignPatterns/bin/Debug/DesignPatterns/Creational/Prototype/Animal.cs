using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Creational.Prototype
{
  /// <summary>
  /// This is the main class: this implements the interface 
  /// which allow to make the clone of the object
  /// </summary>
  public abstract class Animal : ICloneable
  {
    /// <summary>
    /// Implementing the interface
    /// </summary>
    /// <returns></returns>
    public object Clone()
    {
      return this.MemberwiseClone();
    }
    /// <summary>
    /// This has to be implemented by every animal subclass 
    /// for making the clone of the current animal
    /// </summary>
    /// <returns></returns>
    public abstract Animal MakeCopy();
  }
}
