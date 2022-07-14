using DesignPatterns.DesignPatterns.Behavioural.Chain_of_Responsibility;
using DesignPatterns.DesignPatterns.Behavioural.Strategy;
using DesignPatterns.DesignPatterns.Creational.Builder;
using DesignPatterns.DesignPatterns.Creational.Prototype;
using DesignPatterns.DesignPatterns.Structural.Adapter;
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
    #region BEHAVIOURAL

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


    /// <summary>
    /// Demo per il chain of responsibility
    /// </summary>
    public static void Chain_Of_Responsibility_LiveDEMO()
    {
      // STEP1
      DesignPattern_DEMOStep step1 = MemLists.DesignPattern_DEMOStep.Where(x => x.Num_Step == 1).FirstOrDefault();
      ServiceLocator.GetPrintExampleService.DEMO_GetVisualConsoleElementForCase(step1);
      ServiceLocator.GetPrintExampleService.DEMO_PrintAssociatedCodeLines(step1);
      // elements of the chain initialization
      Chain chainCalc1 = new AddNumbers();
      Chain chainCalc2 = new SubNumbers();
      Chain chainCalc3 = new MultNumbers();
      Chain chainCalc4 = new DivNumbers();

      // STEP2
      DesignPattern_DEMOStep step2 = MemLists.DesignPattern_DEMOStep.Where(x => x.Num_Step == 2).FirstOrDefault();
      ServiceLocator.GetPrintExampleService.DEMO_GetVisualConsoleElementForCase(step2);
      ServiceLocator.GetPrintExampleService.DEMO_PrintAssociatedCodeLines(step2);
      // making and setting the elements in the chain 
      chainCalc1.SetNextChain(chainCalc2);
      chainCalc2.SetNextChain(chainCalc3);
      chainCalc3.SetNextChain(chainCalc4);

      // STEP3
      DesignPattern_DEMOStep step3 = MemLists.DesignPattern_DEMOStep.Where(x => x.Num_Step == 3).FirstOrDefault();
      ServiceLocator.GetPrintExampleService.DEMO_GetVisualConsoleElementForCase(step3);
      ServiceLocator.GetPrintExampleService.DEMO_PrintAssociatedCodeLines(step3);
      ServiceLocator.GetPrintExampleService.DEMO_ResetColorParameters();
      // CASE 1 intializing the number object 
      Numbers request = new Numbers(4, 2, "add");

      // doing the calculus
      chainCalc1.Calculate(request);
      ServiceLocator.GetPrintExampleService.DEMO_ResetColorParameters();
      // STEP4
      DesignPattern_DEMOStep step4 = MemLists.DesignPattern_DEMOStep.Where(x => x.Num_Step == 4).FirstOrDefault();
      ServiceLocator.GetPrintExampleService.DEMO_GetVisualConsoleElementForCase(step4);
      ServiceLocator.GetPrintExampleService.DEMO_PrintAssociatedCodeLines(step4);
      ServiceLocator.GetPrintExampleService.DEMO_ResetColorParameters();
      // CASE 2: intizializing the number object 
      Numbers request2 = new Numbers(5, 5, "mult");
      
      // doing the calculus
      chainCalc1.Calculate(request2);
      ServiceLocator.GetPrintExampleService.DEMO_ResetColorParameters();
      // STEP5
      DesignPattern_DEMOStep step5 = MemLists.DesignPattern_DEMOStep.Where(x => x.Num_Step == 5).FirstOrDefault();
      ServiceLocator.GetPrintExampleService.DEMO_GetVisualConsoleElementForCase(step5);
      ServiceLocator.GetPrintExampleService.DEMO_PrintAssociatedCodeLines(step5);
      ServiceLocator.GetPrintExampleService.DEMO_ResetColorParameters();
      // CASE 3: initializing the number object 
      Numbers request3 = new Numbers(2, 7, "not");

      // failing in doing the calculus
      chainCalc1.Calculate(request3);
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


    /// <summary>
    /// Demo per il Prototype
    /// </summary>
    public static void Prototype_LiveDEMO()
    {
      // STEP1
      DesignPattern_DEMOStep step1 = MemLists.DesignPattern_DEMOStep.Where(x => x.Num_Step == 1).FirstOrDefault();
      ServiceLocator.GetPrintExampleService.DEMO_GetVisualConsoleElementForCase(step1);
      ServiceLocator.GetPrintExampleService.DEMO_PrintAssociatedCodeLines(step1);
      // the clone factory 
      CloneFactory animalMaker = new CloneFactory();

      // STEP2
      DesignPattern_DEMOStep step2 = MemLists.DesignPattern_DEMOStep.Where(x => x.Num_Step == 2).FirstOrDefault();
      ServiceLocator.GetPrintExampleService.DEMO_GetVisualConsoleElementForCase(step2);
      ServiceLocator.GetPrintExampleService.DEMO_PrintAssociatedCodeLines(step2);
      // the first sheep creation
      Sheep sally = new Sheep();

      // STEP3
      DesignPattern_DEMOStep step3 = MemLists.DesignPattern_DEMOStep.Where(x => x.Num_Step == 3).FirstOrDefault();
      ServiceLocator.GetPrintExampleService.DEMO_GetVisualConsoleElementForCase(step3);
      ServiceLocator.GetPrintExampleService.DEMO_PrintAssociatedCodeLines(step3);
      ServiceLocator.GetPrintExampleService.DEMO_ResetColorParameters();
      // the cloned sheep 
      Sheep clonedSheep = (Sheep)animalMaker.GetClone(sally);
      ServiceLocator.GetPrintExampleService.DEMO_ResetColorParameters();

      // STEP4
      DesignPattern_DEMOStep step4 = MemLists.DesignPattern_DEMOStep.Where(x => x.Num_Step == 4).FirstOrDefault();
      ServiceLocator.GetPrintExampleService.DEMO_GetVisualConsoleElementForCase(step4);
      ServiceLocator.GetPrintExampleService.DEMO_PrintAssociatedCodeLines(step4);
      ServiceLocator.GetPrintExampleService.DEMO_ResetColorParameters();
      // the first sheep 
      Console.WriteLine(sally.ToString());
      ServiceLocator.GetPrintExampleService.DEMO_ResetColorParameters();

      // STEP5
      DesignPattern_DEMOStep step5 = MemLists.DesignPattern_DEMOStep.Where(x => x.Num_Step == 5).FirstOrDefault();
      ServiceLocator.GetPrintExampleService.DEMO_GetVisualConsoleElementForCase(step5);
      ServiceLocator.GetPrintExampleService.DEMO_PrintAssociatedCodeLines(step5);
      ServiceLocator.GetPrintExampleService.DEMO_ResetColorParameters();
      // the cloned sheep 
      Console.WriteLine(clonedSheep.ToString());
      ServiceLocator.GetPrintExampleService.DEMO_ResetColorParameters();
      // Lettura comando di exit
      ServiceLocator.GetPrintExampleService.DEMO_ShowExitLabel();
    }

    #endregion


    #region STRUCTURAL

    /// <summary>
    /// Demo for the adapter
    /// </summary>
    public static void Adapter_LiveDEMO()
    {
      // STEP1
      DesignPattern_DEMOStep step1 = MemLists.DesignPattern_DEMOStep.Where(x => x.Num_Step == 1).FirstOrDefault();
      ServiceLocator.GetPrintExampleService.DEMO_GetVisualConsoleElementForCase(step1);
      ServiceLocator.GetPrintExampleService.DEMO_PrintAssociatedCodeLines(step1);
      // this is the 'standard' enemy, which implemnts the interface by default 
      // and on this creation 
      EnemyTank rx7Tank = new EnemyTank();

      // STEP2
      DesignPattern_DEMOStep step2 = MemLists.DesignPattern_DEMOStep.Where(x => x.Num_Step == 2).FirstOrDefault();
      ServiceLocator.GetPrintExampleService.DEMO_GetVisualConsoleElementForCase(step2);
      ServiceLocator.GetPrintExampleService.DEMO_PrintAssociatedCodeLines(step2);
      // this is the EnemyRobot, maybe it exists before the creation of the interface
      // and the given standardization and it doesn't implemnt it by default 
      EnemyRobot fredTheRobot = new EnemyRobot();

      // STEP3
      DesignPattern_DEMOStep step3 = MemLists.DesignPattern_DEMOStep.Where(x => x.Num_Step == 3).FirstOrDefault();
      ServiceLocator.GetPrintExampleService.DEMO_GetVisualConsoleElementForCase(step3);
      ServiceLocator.GetPrintExampleService.DEMO_PrintAssociatedCodeLines(step3);
      // this is the adapter for our fred the robot
      EnemyAttacker robotAdapter = new EnemyRobotAdapter(fredTheRobot);

      // STEP4
      DesignPattern_DEMOStep step4 = MemLists.DesignPattern_DEMOStep.Where(x => x.Num_Step == 4).FirstOrDefault();
      ServiceLocator.GetPrintExampleService.DEMO_GetVisualConsoleElementForCase(step4);
      ServiceLocator.GetPrintExampleService.DEMO_PrintAssociatedCodeLines(step4);
      ServiceLocator.GetPrintExampleService.DEMO_ResetColorParameters();
      // CASE 1: the robot and its actions without using the adapter 
      // free from the context of the standardization 
      Console.WriteLine("the robot: ");
      fredTheRobot.ReactToHuman("Paul");
      fredTheRobot.WalkForwand();
      fredTheRobot.SmashWithHands();
      ServiceLocator.GetPrintExampleService.DEMO_ResetColorParameters();

      // STEP5
      DesignPattern_DEMOStep step5 = MemLists.DesignPattern_DEMOStep.Where(x => x.Num_Step == 5).FirstOrDefault();
      ServiceLocator.GetPrintExampleService.DEMO_GetVisualConsoleElementForCase(step5);
      ServiceLocator.GetPrintExampleService.DEMO_PrintAssociatedCodeLines(step5);
      ServiceLocator.GetPrintExampleService.DEMO_ResetColorParameters();
      // CASE 2: the EnemyAttacker standardized at its creation 
      // in this case the tank 
      rx7Tank.AssignDriver("Frank");
      rx7Tank.DriveForward();
      rx7Tank.FireWeapon();
      ServiceLocator.GetPrintExampleService.DEMO_ResetColorParameters();

      // STEP6
      DesignPattern_DEMOStep step6 = MemLists.DesignPattern_DEMOStep.Where(x => x.Num_Step == 6).FirstOrDefault();
      ServiceLocator.GetPrintExampleService.DEMO_GetVisualConsoleElementForCase(step6);
      ServiceLocator.GetPrintExampleService.DEMO_PrintAssociatedCodeLines(step6);
      ServiceLocator.GetPrintExampleService.DEMO_ResetColorParameters();
      // CASE 3 (THE ADAPTED CASE): the robot seen with the implementation 
      // of standard interface made through the adapter 
      robotAdapter.AssignDriver("Mark");
      robotAdapter.DriveForward();
      robotAdapter.FireWeapon();
      ServiceLocator.GetPrintExampleService.DEMO_ResetColorParameters();
      // Lettura comando di exit
      ServiceLocator.GetPrintExampleService.DEMO_ShowExitLabel();
    }

    #endregion
  }
}
