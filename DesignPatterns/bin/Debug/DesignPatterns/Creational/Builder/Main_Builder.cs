using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Creational.Builder
{
  public static class Main_Builder
  {
    public static void RunExample()
    {
      // specifying the style for the robot builder 
      RobotBuilder oldStyleRobot = new OldRobotBuilder_2();

      // asking for a new Engineer able to build the robot (old robot)
      RobotEngineer robotEngineer = new RobotEngineer(oldStyleRobot);

      // the engineer will construct the robot for us!
      robotEngineer.MakeRobot();

      // obtaining our first robot
      Robot_2 firstRobot = robotEngineer.GetRobot();

      // printing the specifications of the fresh built robot 
      Console.WriteLine("Robot built!");

      Console.WriteLine("Robot Head Type: " + firstRobot.GetRobotHead());
      Console.WriteLine("Robot Arms Type: " + firstRobot.GetRobotArms());
      Console.WriteLine("Robot Legs Type: " + firstRobot.GetRobotLegs());
      Console.WriteLine("Robot Torso Type: " + firstRobot.GetRobotTorso());
    }
  }
}
