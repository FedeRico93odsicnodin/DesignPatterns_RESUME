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
  public class Robot_2 : RobotPlan
  {
    private string _robotArms;
    private string _robotHead;
    private string _robotLegs;
    private string _robotTorso;

    public string GetRobotArms()
    {
      return _robotArms;
    }

    public string GetRobotHead()
    {
      return _robotHead;
    }

    public string GetRobotLegs()
    {
      return _robotLegs;
    }

    public string GetRobotTorso()
    {
      return _robotTorso;
    }

    /// <summary>
    /// Those are a set of getters and setters for the different parts of the robot
    /// </summary>
    /// <param name="arms"></param>
    public void SetRobotArms(string arms)
    {
      this._robotArms = arms;
    }

    public void SetRobotHead(string header)
    {
      this._robotHead = header;
    }

    public void SetRobotLegs(string legs)
    {
      this._robotLegs = legs;
    }

    public void SetRobotTorso(string torso)
    {
      this._robotTorso = torso;
    }
  }
}
