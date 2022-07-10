using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Behavioural.Strategy
{
  /// <summary>
  /// Interface Fly: this is the generalization 
  /// </summary>
  public interface Flys
  {
    string fly();
  }


  /// <summary>
  /// Class which specifies the ability to fly
  /// </summary>
  public class ItFlys : Flys
  {
    public string fly()
    {
      return "Flying High";
    }
  }


  /// <summary>
  /// Class which specifies the unability to fly
  /// </summary>
  public class CantFly : Flys
  {
    public string fly()
    {
      return "I Can't fly";
    }
  }
}
