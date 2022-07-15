using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Creational.Singleton
{
  public class SingletonService2
  {
    private static int _counter = 0;
    private static SingletonService2 _istanceSingleton = null;
    /// <summary>
    /// Getter for the single instance of the class (which is sealed)
    /// </summary>
    public static SingletonService2 GetInstanceSingleton
    {
      get
      {
        if (_istanceSingleton == null)
          _istanceSingleton = new SingletonService2();

        return _istanceSingleton;
      }
    }
    /// <summary>
    /// Private constructor: not invokable from another class
    /// </summary>
    protected SingletonService2()
    {
      _counter++;
      Console.WriteLine("counter value " + _counter);
    }
    public void PrintDetails(string message)
    {
      Console.WriteLine(message);
    }
  }


  public class DerivedSingleton : SingletonService2
  {
  }

}
