using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Creational.Builder
{
  /// <summary>
  /// This is the implementation of the interface: all the elements that a robot needs to be set
  /// for the correct creation
  /// </summary>
  public class Robot : RobotPlan
  {
    public string GetRobotArms()
    {
      throw new NotImplementedException();
    }

    public string GetRobotHead()
    {
      throw new NotImplementedException();
    }

    public string GetRobotLegs()
    {
      throw new NotImplementedException();
    }

    public string GetRobotTorso()
    {
      throw new NotImplementedException();
    }

    public void SetRobotArms(string arms)
    {
      throw new NotImplementedException();
    }

    public void SetRobotHead(string header)
    {
      throw new NotImplementedException();
    }

    public void SetRobotLegs(string legs)
    {
      throw new NotImplementedException();
    }

    public void SetRobotTorso(string torso)
    {
      throw new NotImplementedException();
    }
  }
}
