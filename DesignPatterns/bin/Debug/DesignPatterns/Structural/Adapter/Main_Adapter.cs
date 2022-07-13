using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Structural.Adapter
{
  public class Main_Adapter
  {
    public static void RunExample()
    {
      // this is the 'standard' enemy, which implemnts the interface by default 
      // and on this creation 
      EnemyTank rx7Tank = new EnemyTank();

      // this is the EnemyRobot, maybe it exists before the creation of the interface
      // and the given standardization and it doesn't implemnt it by default 
      EnemyRobot fredTheRobot = new EnemyRobot();

      // this is the adapter for our fred the robot
      EnemyAttacker robotAdapter = new EnemyRobotAdapter(fredTheRobot);

      // CASE 1: the robot and its actions without using the adapter 
      // free from the context of the standardization 
      Console.WriteLine("the robot: ");
      fredTheRobot.ReactToHuman("Paul");
      fredTheRobot.WalkForwand();
      fredTheRobot.SmashWithHands();

      // CASE 2: the EnemyAttacker standardized at its creation 
      // in this case the tank 
      rx7Tank.AssignDriver("Frank");
      rx7Tank.DriveForward();
      rx7Tank.FireWeapon();

      // CASE 3 (THE ADAPTED CASE): the robot seen with the implementation 
      // of standard interface made through the adapter 
      robotAdapter.AssignDriver("Mark");
      robotAdapter.DriveForward();
      robotAdapter.FireWeapon();
    }
  }
}
