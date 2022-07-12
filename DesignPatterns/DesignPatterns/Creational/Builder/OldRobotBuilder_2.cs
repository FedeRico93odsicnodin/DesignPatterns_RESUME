using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Creational.Builder
{
  public class OldRobotBuilder_2 : RobotBuilder
  {
    private Robot_2 _robot;

    /// <summary>
    /// Initializing the robot to be got in the constructor
    /// </summary>
    public OldRobotBuilder_2()
    {
      _robot = new Robot_2();
    }

    /// <summary>
    /// Building the robot in the "old" style
    /// </summary>
    public void BuildRobotArms()
    {
      _robot.SetRobotArms("Blowtorch Arms");
    }

    public void BuildRobotHead()
    {
      _robot.SetRobotHead("Not so sapient brain");
    }

    public void BuildRobotLegs()
    {
      _robot.SetRobotLegs("Roller Skates");
    }

    public void BuildRobotTorso()
    {
      _robot.SetRobotTorso("Ancient Torso");
    }

    public Robot_2 GetRobot()
    {
      return _robot;
    }
  }
}
