using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Structural.Adapter
{
  /// <summary>
  /// This is the adapter to the standard interface for an 
  /// EnemyRobot object
  /// </summary>
  public class EnemyRobotAdapter : EnemyAttacker
  {
    EnemyRobot _theRobot;

    public EnemyRobotAdapter(EnemyRobot newRobot)
    {
      // the object I want to adapt with this specific adapter
      _theRobot = newRobot;
    }

    // I'm adapting this method implementation to the robot
    public void AssignDriver(string driverName)
    {
      _theRobot.ReactToHuman(driverName);
    }
    // I'm adapting this method implementation to the robot
    public void DriveForward()
    {
      _theRobot.WalkForwand();
    }
    // I'm adapting this method implementation to the robot
    public void FireWeapon()
    {
      _theRobot.SmashWithHands();
    }
  }
}
