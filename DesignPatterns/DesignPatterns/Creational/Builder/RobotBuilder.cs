using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Creational.Builder
{
  /// <summary>
  /// This is the interface for the effective build of all the robot parts
  /// </summary>
  public interface RobotBuilder
  {
    void BuildRobotHead();

    void BuildRobotTorso();

    void BuildRobotArms();

    void BuildRobotLegs();

    /// <summary>
    /// Getter of the final result robot
    /// </summary>
    /// <returns></returns>
    Robot_2 GetRobot();
  }
}
