using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Creational.Builder
{
  /// <summary>
  /// This is the ensample of all the parts needed for the robot creation 
  /// </summary>
  public interface RobotPlan
  {
    void SetRobotHead(string header);

    void SetRobotTorso(string torso);

    void SetRobotArms(string arms);

    void SetRobotLegs(string legs);

    string GetRobotHead();

    string GetRobotTorso();

    string GetRobotArms();

    string GetRobotLegs();  
  }
}
