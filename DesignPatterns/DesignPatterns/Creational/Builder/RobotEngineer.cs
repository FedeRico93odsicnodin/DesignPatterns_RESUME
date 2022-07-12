using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Creational.Builder
{
  /// <summary>
  /// This is the engineer that builds the robot: in construction time the type of robot builder is 
  /// passed as input so as the engineer can understand which robot type refers to
  /// </summary>
  public class RobotEngineer
  {
    private RobotBuilder _robotBuilder;

    public RobotEngineer(RobotBuilder robotBuilder)
    {
      _robotBuilder = robotBuilder;
    }


    /// <summary>
    /// Return of the built robot
    /// </summary>
    /// <returns></returns>
    public Robot_2 GetRobot()
    {
      return this._robotBuilder.GetRobot();
    }


    public void MakeRobot()
    {
      // building the current robot
      this._robotBuilder.BuildRobotArms();
      this._robotBuilder.BuildRobotHead();
      this._robotBuilder.BuildRobotLegs();
      this._robotBuilder.BuildRobotTorso();
    }
  }
}
