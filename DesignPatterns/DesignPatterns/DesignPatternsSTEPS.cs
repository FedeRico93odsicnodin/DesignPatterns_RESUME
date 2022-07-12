using DesignPatterns.DesignPatterns.Behavioural.Strategy;
using DesignPatterns.DesignPatterns.Creational.Builder;
using DesignPatterns.Model;
using DesignPatterns.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns
{
  /// <summary>
  /// Tutti gli steps per i design patterns di cui è stata creata una live demo 
  /// </summary>
  public static class DesignPatternsSTEPS
  {
    #region BNEHAVIOURAL

    /// <summary>
    /// Demo per lo strategy
    /// </summary>
    public static void Strategy_LiveDEMO()
    {
      // STEP1
      DesignPattern_DEMOStep step1 = MemLists.DesignPattern_DEMOStep.Where(x => x.Num_Step == 1).FirstOrDefault();
      ServiceLocator.GetPrintExampleService.DEMO_GetVisualConsoleElementForCase(step1);
      ServiceLocator.GetPrintExampleService.DEMO_PrintAssociatedCodeLines(step1);
      // first creation of the dog 
      Animal_Implementation4 sparky = new Dog();
      // second representation of a bird
      Animal_Implementation4 treety = new Bird();

      // STEP2
      DesignPattern_DEMOStep step2 = MemLists.DesignPattern_DEMOStep.Where(x => x.Num_Step == 2).FirstOrDefault();
      ServiceLocator.GetPrintExampleService.DEMO_GetVisualConsoleElementForCase(step2);
      ServiceLocator.GetPrintExampleService.DEMO_PrintAssociatedCodeLines(step2);
      ServiceLocator.GetPrintExampleService.DEMO_ResetColorParameters();
      // visualizing the ability to fly
      Console.WriteLine("Dog: " + sparky.TryToFly());
      Console.WriteLine("Bird: " + treety.TryToFly());
      ServiceLocator.GetPrintExampleService.DEMO_ResetColorParameters();
      // STEP3
      DesignPattern_DEMOStep step3 = MemLists.DesignPattern_DEMOStep.Where(x => x.Num_Step == 3).FirstOrDefault();
      ServiceLocator.GetPrintExampleService.DEMO_GetVisualConsoleElementForCase(step3);
      ServiceLocator.GetPrintExampleService.DEMO_PrintAssociatedCodeLines(step3);
      // set the ability to fly DYNAMICALLY
      sparky.SetFlyingAbility(new ItFlys());

      // STEP4
      DesignPattern_DEMOStep step4 = MemLists.DesignPattern_DEMOStep.Where(x => x.Num_Step == 4).FirstOrDefault();
      ServiceLocator.GetPrintExampleService.DEMO_GetVisualConsoleElementForCase(step4);
      ServiceLocator.GetPrintExampleService.DEMO_PrintAssociatedCodeLines(step4);
      ServiceLocator.GetPrintExampleService.DEMO_ResetColorParameters();
      Console.WriteLine("Dog: " + sparky.TryToFly());
      ServiceLocator.GetPrintExampleService.DEMO_ResetColorParameters();
      // Lettura comando di exit
      ServiceLocator.GetPrintExampleService.DEMO_ShowExitLabel();
      
    }

    #endregion


    #region CREATIONAL

    /// <summary>
    /// Demo per il Builder 
    /// </summary>
    public static void Builder_LiveDEMO()
    {
      // STEP1
      DesignPattern_DEMOStep step1 = MemLists.DesignPattern_DEMOStep.Where(x => x.Num_Step == 1).FirstOrDefault();
      ServiceLocator.GetPrintExampleService.DEMO_GetVisualConsoleElementForCase(step1);
      ServiceLocator.GetPrintExampleService.DEMO_PrintAssociatedCodeLines(step1);
      // specifying the style for the robot builder 
      RobotBuilder oldStyleRobot = new OldRobotBuilder_2();

      // STEP2
      DesignPattern_DEMOStep step2 = MemLists.DesignPattern_DEMOStep.Where(x => x.Num_Step == 2).FirstOrDefault();
      ServiceLocator.GetPrintExampleService.DEMO_GetVisualConsoleElementForCase(step2);
      ServiceLocator.GetPrintExampleService.DEMO_PrintAssociatedCodeLines(step2);
      // asking for a new Engineer able to build the robot (old robot)
      RobotEngineer robotEngineer = new RobotEngineer(oldStyleRobot);

      // STEP3  
      DesignPattern_DEMOStep step3 = MemLists.DesignPattern_DEMOStep.Where(x => x.Num_Step == 3).FirstOrDefault();
      ServiceLocator.GetPrintExampleService.DEMO_GetVisualConsoleElementForCase(step3);
      ServiceLocator.GetPrintExampleService.DEMO_PrintAssociatedCodeLines(step3);
      // the engineer will construct the robot for us!
      robotEngineer.MakeRobot();

      // STEP4  
      DesignPattern_DEMOStep step4 = MemLists.DesignPattern_DEMOStep.Where(x => x.Num_Step == 4).FirstOrDefault();
      ServiceLocator.GetPrintExampleService.DEMO_GetVisualConsoleElementForCase(step4);
      ServiceLocator.GetPrintExampleService.DEMO_PrintAssociatedCodeLines(step4);
      // obtaining our first robot
      Robot_2 firstRobot = robotEngineer.GetRobot();

      // STEP4
      DesignPattern_DEMOStep step5 = MemLists.DesignPattern_DEMOStep.Where(x => x.Num_Step == 5).FirstOrDefault();
      ServiceLocator.GetPrintExampleService.DEMO_GetVisualConsoleElementForCase(step5);
      ServiceLocator.GetPrintExampleService.DEMO_PrintAssociatedCodeLines(step5);
      ServiceLocator.GetPrintExampleService.DEMO_ResetColorParameters();
      // printing the specifications of the fresh built robot 
      Console.WriteLine("Robot built!");

      Console.WriteLine("Robot Head Type: " + firstRobot.GetRobotHead());
      Console.WriteLine("Robot Arms Type: " + firstRobot.GetRobotArms());
      Console.WriteLine("Robot Legs Type: " + firstRobot.GetRobotLegs());
      Console.WriteLine("Robot Torso Type: " + firstRobot.GetRobotTorso());
      ServiceLocator.GetPrintExampleService.DEMO_ResetColorParameters();
      // Lettura comando di exit
      ServiceLocator.GetPrintExampleService.DEMO_ShowExitLabel();
    }

    #endregion
  }
}
