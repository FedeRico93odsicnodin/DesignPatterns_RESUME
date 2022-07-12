using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Creational.Builder
{
  /// <summary>
  /// For instance those are the specifactions for the construction of 
  /// an old robot
  /// </summary>
  public class OldRobotBuilder : RobotBuilder
  {
    
    public void BuildRobotArms()
    {
      throw new NotImplementedException();
    }

    public void BuildRobotHead()
    {
      throw new NotImplementedException();
    }

    public void BuildRobotLegs()
    {
      throw new NotImplementedException();
    }

    public void BuildRobotTorso()
    {
      throw new NotImplementedException();
    }
    
    Robot_2 RobotBuilder.GetRobot()
    {
      throw new NotImplementedException();
    }
  }
}
