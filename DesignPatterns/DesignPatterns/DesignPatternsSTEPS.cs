using DesignPatterns.DesignPatterns.Behavioural.Chain_of_Responsibility;
using DesignPatterns.DesignPatterns.Behavioural.Command;
using DesignPatterns.DesignPatterns.Behavioural.Iterator;
using DesignPatterns.DesignPatterns.Behavioural.Mediator;
using DesignPatterns.DesignPatterns.Behavioural.Strategy;
using DesignPatterns.DesignPatterns.Creational;
using DesignPatterns.DesignPatterns.Creational.Builder;
using DesignPatterns.DesignPatterns.Creational.Factory;
using DesignPatterns.DesignPatterns.Creational.Prototype;
using DesignPatterns.DesignPatterns.Structural.Adapter;
using DesignPatterns.DesignPatterns.Structural.Bridge;
using DesignPatterns.DesignPatterns.Structural.Composite;
using DesignPatterns.DesignPatterns.Structural.Decorator;
using DesignPatterns.DesignPatterns.Structural.Facade;
using DesignPatterns.DesignPatterns.Structural.FlyWeight;
using DesignPatterns.DesignPatterns.Structural.Proxy;
using DesignPatterns.Model;
using DesignPatterns.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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


    /// <summary>
    /// Demo per il COMMAND 
    /// </summary>
    public static void Command_LiveDEMO()
    {
      // STEP1
      DesignPattern_DEMOStep step1 = MemLists.DesignPattern_DEMOStep.Where(x => x.Num_Step == 1).FirstOrDefault();
      ServiceLocator.GetPrintExampleService.DEMO_GetVisualConsoleElementForCase(step1);
      ServiceLocator.GetPrintExampleService.DEMO_PrintAssociatedCodeLines(step1);
      // running the first example 
      ElectronicDevice newDevice = TVRemote.GetDevice();

      // STEP2
      DesignPattern_DEMOStep step2 = MemLists.DesignPattern_DEMOStep.Where(x => x.Num_Step == 2).FirstOrDefault();
      ServiceLocator.GetPrintExampleService.DEMO_GetVisualConsoleElementForCase(step2);
      ServiceLocator.GetPrintExampleService.DEMO_PrintAssociatedCodeLines(step2);
      // getting the first command ON
      TurnTVOn2 onCommand = new TurnTVOn2(newDevice);

      // STEP3
      DesignPattern_DEMOStep step3 = MemLists.DesignPattern_DEMOStep.Where(x => x.Num_Step == 3).FirstOrDefault();
      ServiceLocator.GetPrintExampleService.DEMO_GetVisualConsoleElementForCase(step3);
      ServiceLocator.GetPrintExampleService.DEMO_PrintAssociatedCodeLines(step3);
      // getting the first button
      DeviceButton2 onPressed = new DeviceButton2(onCommand);

      // STEP4
      DesignPattern_DEMOStep step4 = MemLists.DesignPattern_DEMOStep.Where(x => x.Num_Step == 4).FirstOrDefault();
      ServiceLocator.GetPrintExampleService.DEMO_GetVisualConsoleElementForCase(step4);
      ServiceLocator.GetPrintExampleService.DEMO_PrintAssociatedCodeLines(step4);
      ServiceLocator.GetPrintExampleService.DEMO_ResetColorParameters();
      // running the effect of the first button 
      onPressed.Press();
      ServiceLocator.GetPrintExampleService.DEMO_ResetColorParameters();

      // STEP5
      DesignPattern_DEMOStep step5 = MemLists.DesignPattern_DEMOStep.Where(x => x.Num_Step == 5).FirstOrDefault();
      ServiceLocator.GetPrintExampleService.DEMO_GetVisualConsoleElementForCase(step5);
      ServiceLocator.GetPrintExampleService.DEMO_PrintAssociatedCodeLines(step5);
      // getting the second command OFF (for the same device)
      TurnTVOff2 offCommand = new TurnTVOff2(newDevice);

      // STEP6
      DesignPattern_DEMOStep step6 = MemLists.DesignPattern_DEMOStep.Where(x => x.Num_Step == 6).FirstOrDefault();
      ServiceLocator.GetPrintExampleService.DEMO_GetVisualConsoleElementForCase(step6);
      ServiceLocator.GetPrintExampleService.DEMO_PrintAssociatedCodeLines(step6);
      // passing the command to the button 
      onPressed = new DeviceButton2(offCommand);

      // STEP7
      DesignPattern_DEMOStep step7 = MemLists.DesignPattern_DEMOStep.Where(x => x.Num_Step == 7).FirstOrDefault();
      ServiceLocator.GetPrintExampleService.DEMO_GetVisualConsoleElementForCase(step7);
      ServiceLocator.GetPrintExampleService.DEMO_PrintAssociatedCodeLines(step7);
      ServiceLocator.GetPrintExampleService.DEMO_ResetColorParameters();
      // running the effect of the second command on first button
      onPressed.Press();
      ServiceLocator.GetPrintExampleService.DEMO_ResetColorParameters();

      // STEP8
      DesignPattern_DEMOStep step8 = MemLists.DesignPattern_DEMOStep.Where(x => x.Num_Step == 8).FirstOrDefault();
      ServiceLocator.GetPrintExampleService.DEMO_GetVisualConsoleElementForCase(step8);
      ServiceLocator.GetPrintExampleService.DEMO_PrintAssociatedCodeLines(step8);
      // getting the third command Up 
      TurnTVUp2 volUpCommand = new TurnTVUp2(newDevice);

      // STEP9
      DesignPattern_DEMOStep step9 = MemLists.DesignPattern_DEMOStep.Where(x => x.Num_Step == 9).FirstOrDefault();
      ServiceLocator.GetPrintExampleService.DEMO_GetVisualConsoleElementForCase(step9);
      ServiceLocator.GetPrintExampleService.DEMO_PrintAssociatedCodeLines(step9);
      // passing the third command to the button 
      onPressed = new DeviceButton2(volUpCommand);

      // STEP10
      DesignPattern_DEMOStep step10 = MemLists.DesignPattern_DEMOStep.Where(x => x.Num_Step == 10).FirstOrDefault();
      ServiceLocator.GetPrintExampleService.DEMO_GetVisualConsoleElementForCase(step10);
      ServiceLocator.GetPrintExampleService.DEMO_PrintAssociatedCodeLines(step10);
      ServiceLocator.GetPrintExampleService.DEMO_ResetColorParameters();
      // running the effect of the third command multiple time 
      onPressed.Press();
      onPressed.Press();
      onPressed.Press();
      ServiceLocator.GetPrintExampleService.DEMO_ResetColorParameters();

      // STEP11
      DesignPattern_DEMOStep step11 = MemLists.DesignPattern_DEMOStep.Where(x => x.Num_Step == 11).FirstOrDefault();
      ServiceLocator.GetPrintExampleService.DEMO_GetVisualConsoleElementForCase(step11);
      ServiceLocator.GetPrintExampleService.DEMO_PrintAssociatedCodeLines(step11);
      // instances of 2 more devices: a TV and a RADIO
      Television theTV = new Television();
      Radio theRadio = new Radio();

      // STEP12
      DesignPattern_DEMOStep step12 = MemLists.DesignPattern_DEMOStep.Where(x => x.Num_Step == 12).FirstOrDefault();
      ServiceLocator.GetPrintExampleService.DEMO_GetVisualConsoleElementForCase(step12);
      ServiceLocator.GetPrintExampleService.DEMO_PrintAssociatedCodeLines(step12);
      // adding the 2 devices to the list of all devices
      List<ElectronicDevice> allDevices = new List<ElectronicDevice>();
      allDevices.Add(theTV);
      allDevices.Add(theRadio);

      // STEP13
      DesignPattern_DEMOStep step13 = MemLists.DesignPattern_DEMOStep.Where(x => x.Num_Step == 13).FirstOrDefault();
      ServiceLocator.GetPrintExampleService.DEMO_GetVisualConsoleElementForCase(step13);
      ServiceLocator.GetPrintExampleService.DEMO_PrintAssociatedCodeLines(step13);
      ServiceLocator.GetPrintExampleService.DEMO_ResetColorParameters();
      // running the turning off funcionality 
      TurnItAllOff2 turnOffDevices = new TurnItAllOff2(allDevices);
      DeviceButton2 turnThemOff = new DeviceButton2(turnOffDevices);
      turnThemOff.Press();
      ServiceLocator.GetPrintExampleService.DEMO_ResetColorParameters();

      // STEP1
      DesignPattern_DEMOStep step14 = MemLists.DesignPattern_DEMOStep.Where(x => x.Num_Step == 14).FirstOrDefault();
      ServiceLocator.GetPrintExampleService.DEMO_GetVisualConsoleElementForCase(step14);
      ServiceLocator.GetPrintExampleService.DEMO_PrintAssociatedCodeLines(step14);
      ServiceLocator.GetPrintExampleService.DEMO_ResetColorParameters();
      // running the undo funcionalities on the devices
      turnThemOff.PressUndo();
      ServiceLocator.GetPrintExampleService.DEMO_ResetColorParameters();

      // Lettura comando di exit
      ServiceLocator.GetPrintExampleService.DEMO_ShowExitLabel();
    }


    /// <summary>
    /// Demo per Iterator 
    /// </summary>
    public static void Iterator_LiveDEMO()
    {
      // STEP1
      DesignPattern_DEMOStep step1 = MemLists.DesignPattern_DEMOStep.Where(x => x.Num_Step == 1).FirstOrDefault();
      ServiceLocator.GetPrintExampleService.DEMO_GetVisualConsoleElementForCase(step1);
      ServiceLocator.GetPrintExampleService.DEMO_PrintAssociatedCodeLines(step1);
      ////////// FIRST BLOCK //////////
      // lists of songs which do not implement the iterator definition
      SongsOfThe70s songs70s = new SongsOfThe70s();
      SongsOfThe80s songs80s = new SongsOfThe80s();
      SongsOfThe90s songs90s = new SongsOfThe90s();

      // STEP2
      DesignPattern_DEMOStep step2 = MemLists.DesignPattern_DEMOStep.Where(x => x.Num_Step == 2).FirstOrDefault();
      ServiceLocator.GetPrintExampleService.DEMO_GetVisualConsoleElementForCase(step2);
      ServiceLocator.GetPrintExampleService.DEMO_PrintAssociatedCodeLines(step2);
      ServiceLocator.GetPrintExampleService.DEMO_ResetColorParameters();
      // showing the result of the bad implementation: it is correct but using the iterator 
      // is more clear 
      DesignPatterns.Behavioural.Iterator.DiscJockey discJockeyMike = new DesignPatterns.Behavioural.Iterator.DiscJockey(songs70s, songs80s, songs90s);
      discJockeyMike.ShowTheSongs();
      ServiceLocator.GetPrintExampleService.DEMO_ResetColorParameters();

      // STEP3
      DesignPattern_DEMOStep step3 = MemLists.DesignPattern_DEMOStep.Where(x => x.Num_Step == 3).FirstOrDefault();
      ServiceLocator.GetPrintExampleService.DEMO_GetVisualConsoleElementForCase(step3);
      ServiceLocator.GetPrintExampleService.DEMO_PrintAssociatedCodeLines(step3);
      ////////// SECOND BLOCK //////////
      // creation of the new iterator without using the definition of the songs
      // the iteration could be 
      Collection aSetOfSongs = new Collection();
      aSetOfSongs.AddItem(new SongInfo("Losing My Religion", "REM", 1991));
      aSetOfSongs.AddItem(new SongInfo("Roam", "B 52s", 1989));
      aSetOfSongs.AddItem(new SongInfo("Imagine", "John Lennon", 1971));

      // STEP4
      DesignPattern_DEMOStep step4 = MemLists.DesignPattern_DEMOStep.Where(x => x.Num_Step == 4).FirstOrDefault();
      ServiceLocator.GetPrintExampleService.DEMO_GetVisualConsoleElementForCase(step4);
      ServiceLocator.GetPrintExampleService.DEMO_PrintAssociatedCodeLines(step4);
      ServiceLocator.GetPrintExampleService.DEMO_ResetColorParameters();
      // iteration forward 
      OrderIterator songIterator = (OrderIterator)aSetOfSongs.GetEnumerator();
      while (songIterator.MoveNext())
      {
        SongInfo songInfo = (SongInfo)songIterator.Current();
        Console.WriteLine(songInfo.ToString());
      }
      ServiceLocator.GetPrintExampleService.DEMO_ResetColorParameters();
      // STEP5
      DesignPattern_DEMOStep step5 = MemLists.DesignPattern_DEMOStep.Where(x => x.Num_Step == 5).FirstOrDefault();
      ServiceLocator.GetPrintExampleService.DEMO_GetVisualConsoleElementForCase(step5);
      ServiceLocator.GetPrintExampleService.DEMO_PrintAssociatedCodeLines(step5);
      ServiceLocator.GetPrintExampleService.DEMO_ResetColorParameters();
      // configuring for going behind and reset for the iterator 
      aSetOfSongs.ReverseDirection();
      songIterator = (OrderIterator)aSetOfSongs.GetEnumerator();
      while (songIterator.MoveNext())
      {
        SongInfo songInfo = (SongInfo)songIterator.Current();
        Console.WriteLine(songInfo.ToString());
      }
      ServiceLocator.GetPrintExampleService.DEMO_ResetColorParameters();

      // STEP6
      DesignPattern_DEMOStep step6 = MemLists.DesignPattern_DEMOStep.Where(x => x.Num_Step == 6).FirstOrDefault();
      ServiceLocator.GetPrintExampleService.DEMO_GetVisualConsoleElementForCase(step6);
      ServiceLocator.GetPrintExampleService.DEMO_PrintAssociatedCodeLines(step6);
      ////////// THIRD BLOCK //////////
      // lists of songs which implement the iterator definition 
      SongsOfThe70s2 songs70s2 = new SongsOfThe70s2();
      SongsOfThe80s2 songs80s2 = new SongsOfThe80s2();
      SongsOfThe90s2 songs90s2 = new SongsOfThe90s2();

      // STEP7
      DesignPattern_DEMOStep step7 = MemLists.DesignPattern_DEMOStep.Where(x => x.Num_Step == 7).FirstOrDefault();
      ServiceLocator.GetPrintExampleService.DEMO_GetVisualConsoleElementForCase(step7);
      ServiceLocator.GetPrintExampleService.DEMO_PrintAssociatedCodeLines(step7);
      ServiceLocator.GetPrintExampleService.DEMO_ResetColorParameters();
      // showing the result of the good implementation: this is the standardazed implementation
      // on all possible collection sets
      DiscJockey2 discJockeyTom = new DiscJockey2(songs70s2, songs80s2, songs90s2);
      discJockeyTom.ShowTheSongs();
      ServiceLocator.GetPrintExampleService.DEMO_ResetColorParameters();
      // Lettura comando di exit
      ServiceLocator.GetPrintExampleService.DEMO_ShowExitLabel();
    }


    /// <summary>
    /// Demo per il Mediator 
    /// </summary>
    public static void Mediator_LiveDEMO()
    {
      // STEP1
      DesignPattern_DEMOStep step1 = MemLists.DesignPattern_DEMOStep.Where(x => x.Num_Step == 1).FirstOrDefault();
      ServiceLocator.GetPrintExampleService.DEMO_GetVisualConsoleElementForCase(step1);
      ServiceLocator.GetPrintExampleService.DEMO_PrintAssociatedCodeLines(step1);
      // instance of the mediator between the different clients 
      StockMediator nyse = new StockMediator();

      // STEP2
      DesignPattern_DEMOStep step2 = MemLists.DesignPattern_DEMOStep.Where(x => x.Num_Step == 2).FirstOrDefault();
      ServiceLocator.GetPrintExampleService.DEMO_GetVisualConsoleElementForCase(step2);
      ServiceLocator.GetPrintExampleService.DEMO_PrintAssociatedCodeLines(step2);
      ServiceLocator.GetPrintExampleService.DEMO_ResetColorParameters();
      // first broker: it receives the instance of the mediator just created 
      GormanSlacks broker = new GormanSlacks(nyse);
      ServiceLocator.GetPrintExampleService.DEMO_ResetColorParameters();

      // STEP3
      DesignPattern_DEMOStep step3 = MemLists.DesignPattern_DEMOStep.Where(x => x.Num_Step == 3).FirstOrDefault();
      ServiceLocator.GetPrintExampleService.DEMO_GetVisualConsoleElementForCase(step3);
      ServiceLocator.GetPrintExampleService.DEMO_PrintAssociatedCodeLines(step3);
      ServiceLocator.GetPrintExampleService.DEMO_ResetColorParameters();
      // second broker: it receives the instance of the mediator too
      JTPoorman broker2 = new JTPoorman(nyse);
      ServiceLocator.GetPrintExampleService.DEMO_ResetColorParameters();

      // STEP4
      DesignPattern_DEMOStep step4 = MemLists.DesignPattern_DEMOStep.Where(x => x.Num_Step == 4).FirstOrDefault();
      ServiceLocator.GetPrintExampleService.DEMO_GetVisualConsoleElementForCase(step4);
      ServiceLocator.GetPrintExampleService.DEMO_PrintAssociatedCodeLines(step4);
      ServiceLocator.GetPrintExampleService.DEMO_ResetColorParameters();
      // sold offers of the first broker 
      broker.SaleOffer("MSFT", 100);
      broker.SaleOffer("GOOG", 50);
      ServiceLocator.GetPrintExampleService.DEMO_ResetColorParameters();

      // STEP5
      DesignPattern_DEMOStep step5 = MemLists.DesignPattern_DEMOStep.Where(x => x.Num_Step == 5).FirstOrDefault();
      ServiceLocator.GetPrintExampleService.DEMO_GetVisualConsoleElementForCase(step5);
      ServiceLocator.GetPrintExampleService.DEMO_PrintAssociatedCodeLines(step5);
      ServiceLocator.GetPrintExampleService.DEMO_ResetColorParameters();
      // sold / bought offers of the second broker
      broker2.BuyOffer("MSFT", 100);
      broker2.SaleOffer("NRG", 10);
      ServiceLocator.GetPrintExampleService.DEMO_ResetColorParameters();

      // STEP6
      DesignPattern_DEMOStep step6 = MemLists.DesignPattern_DEMOStep.Where(x => x.Num_Step == 6).FirstOrDefault();
      ServiceLocator.GetPrintExampleService.DEMO_GetVisualConsoleElementForCase(step6);
      ServiceLocator.GetPrintExampleService.DEMO_PrintAssociatedCodeLines(step6);
      ServiceLocator.GetPrintExampleService.DEMO_ResetColorParameters();
      // sold offers by the first broker
      broker.BuyOffer("NRF", 10);
      ServiceLocator.GetPrintExampleService.DEMO_ResetColorParameters();

      // STEP7
      DesignPattern_DEMOStep step7 = MemLists.DesignPattern_DEMOStep.Where(x => x.Num_Step == 7).FirstOrDefault();
      ServiceLocator.GetPrintExampleService.DEMO_GetVisualConsoleElementForCase(step7);
      ServiceLocator.GetPrintExampleService.DEMO_PrintAssociatedCodeLines(step7);
      ServiceLocator.GetPrintExampleService.DEMO_ResetColorParameters();
      // getting all the set of the bought and sold offers 
      nyse.GetStockOfferings();
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


    /// <summary>
    /// Demo per il Singleton 
    /// </summary>
    public static void Singleton_LiveDEMO()
    {
      // STEP1
      DesignPattern_DEMOStep step1 = MemLists.DesignPattern_DEMOStep.Where(x => x.Num_Step == 1).FirstOrDefault();
      ServiceLocator.GetPrintExampleService.DEMO_GetVisualConsoleElementForCase(step1);
      ServiceLocator.GetPrintExampleService.DEMO_PrintAssociatedCodeLines(step1);
      ServiceLocator.GetPrintExampleService.DEMO_ResetColorParameters();
      // assuming Singleton is created from student class 
      // we refer to the GetInstance property from the Singleton class 
      SingletonService fromStudent = SingletonService.GetInstanceSingleton;
      ServiceLocator.GetPrintExampleService.DEMO_ResetColorParameters();
      fromStudent.PrintDetails("From Student");

      // STEP2
      DesignPattern_DEMOStep step2 = MemLists.DesignPattern_DEMOStep.Where(x => x.Num_Step == 2).FirstOrDefault();
      ServiceLocator.GetPrintExampleService.DEMO_GetVisualConsoleElementForCase(step2);
      ServiceLocator.GetPrintExampleService.DEMO_PrintAssociatedCodeLines(step2);
      ServiceLocator.GetPrintExampleService.DEMO_ResetColorParameters();
      // assuming Singleton is created from employee class 
      // we refer to the GetInstance property from the Singleton class 
      // (BUT: in this case the singleton was already created by the student before)
      SingletonService fromEmployee = SingletonService.GetInstanceSingleton;
      fromEmployee.PrintDetails("From Employee");
      ServiceLocator.GetPrintExampleService.DEMO_ResetColorParameters();
      // Lettura comando di exit
      ServiceLocator.GetPrintExampleService.DEMO_ShowExitLabel();
    }


    /// <summary>
    /// Demo per la Factory 
    /// </summary>
    public static void Factory_LiveDEMO()
    {
      // STEP1
      DesignPattern_DEMOStep step1 = MemLists.DesignPattern_DEMOStep.Where(x => x.Num_Step == 1).FirstOrDefault();
      ServiceLocator.GetPrintExampleService.DEMO_GetVisualConsoleElementForCase(step1);
      ServiceLocator.GetPrintExampleService.DEMO_PrintAssociatedCodeLines(step1);
      // creating the new ship factory 
      EnemyShipFactory factoryShip = new EnemyShipFactory();

      // STEP2
      DesignPattern_DEMOStep step2 = MemLists.DesignPattern_DEMOStep.Where(x => x.Num_Step == 2).FirstOrDefault();
      ServiceLocator.GetPrintExampleService.DEMO_GetVisualConsoleElementForCase(step2);
      ServiceLocator.GetPrintExampleService.DEMO_PrintAssociatedCodeLines(step2);
      ServiceLocator.GetPrintExampleService.DEMO_ResetColorParameters();
      // asking to the user which ship wants to create 
      Console.WriteLine("Please select the ship (U , R , B)");
      Console.WriteLine("(by default the Rocket ship will be returned)");
      string input = Console.ReadKey(true).KeyChar.ToString();
      ServiceLocator.GetPrintExampleService.DEMO_ResetColorParameters();

      // STEP3
      DesignPattern_DEMOStep step3 = MemLists.DesignPattern_DEMOStep.Where(x => x.Num_Step == 3).FirstOrDefault();
      ServiceLocator.GetPrintExampleService.DEMO_GetVisualConsoleElementForCase(step3);
      ServiceLocator.GetPrintExampleService.DEMO_PrintAssociatedCodeLines(step3);
      // giving the input to the factory 
      EnemyShip returnedShip = factoryShip.CreateShip(input);

      // STEP4
      DesignPattern_DEMOStep step4 = MemLists.DesignPattern_DEMOStep.Where(x => x.Num_Step == 4).FirstOrDefault();
      ServiceLocator.GetPrintExampleService.DEMO_GetVisualConsoleElementForCase(step4);
      ServiceLocator.GetPrintExampleService.DEMO_PrintAssociatedCodeLines(step4);
      ServiceLocator.GetPrintExampleService.DEMO_ResetColorParameters();
      // seeing the effects of the created ship for the case
      EnemyShipTesting.DoStuffEnemy(returnedShip);
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


    public static void Bridge_LiveDEMO()
    {
      // STEP1
      DesignPattern_DEMOStep step1 = MemLists.DesignPattern_DEMOStep.Where(x => x.Num_Step == 1).FirstOrDefault();
      ServiceLocator.GetPrintExampleService.DEMO_GetVisualConsoleElementForCase(step1);
      ServiceLocator.GetPrintExampleService.DEMO_PrintAssociatedCodeLines(step1);
      // creating a first TV Device 
      RemoteButton theTV = new TVRemoteMute(new TVDevice(1, 200));

      // STEP2
      DesignPattern_DEMOStep step2 = MemLists.DesignPattern_DEMOStep.Where(x => x.Num_Step == 2).FirstOrDefault();
      ServiceLocator.GetPrintExampleService.DEMO_GetVisualConsoleElementForCase(step2);
      ServiceLocator.GetPrintExampleService.DEMO_PrintAssociatedCodeLines(step2);
      // creating a second TV Device
      RemoteButton theTV2 = new TVRemotePause(new TVDevice(1, 200));

      // STEP3
      DesignPattern_DEMOStep step3 = MemLists.DesignPattern_DEMOStep.Where(x => x.Num_Step == 3).FirstOrDefault();
      ServiceLocator.GetPrintExampleService.DEMO_GetVisualConsoleElementForCase(step3);
      ServiceLocator.GetPrintExampleService.DEMO_PrintAssociatedCodeLines(step3);
      ServiceLocator.GetPrintExampleService.DEMO_ResetColorParameters();
      // testing the TV with MUTE button 
      Console.WriteLine("testing the TV with the MUTE BUTTON");
      theTV.ButtonFivePressed();
      theTV.ButtonSixPressed();
      theTV.ButtonNinePressed();
      ServiceLocator.GetPrintExampleService.DEMO_ResetColorParameters();

      // STEP4
      DesignPattern_DEMOStep step4 = MemLists.DesignPattern_DEMOStep.Where(x => x.Num_Step == 4).FirstOrDefault();
      ServiceLocator.GetPrintExampleService.DEMO_GetVisualConsoleElementForCase(step4);
      ServiceLocator.GetPrintExampleService.DEMO_PrintAssociatedCodeLines(step4);
      ServiceLocator.GetPrintExampleService.DEMO_ResetColorParameters();
      // testing the TV with the PAUSE button 
      Console.WriteLine("testing the TV with the PAUSE BUTTON");
      theTV2.ButtonFivePressed();
      theTV2.ButtonSixPressed();
      theTV2.ButtonNinePressed();
      theTV2.DeviceFeedback();
      ServiceLocator.GetPrintExampleService.DEMO_ResetColorParameters();
      // Lettura comando di exit
      ServiceLocator.GetPrintExampleService.DEMO_ShowExitLabel();
    }


    public static void Composite_LiveDEMO()
    {
      // STEP1
      DesignPattern_DEMOStep step1 = MemLists.DesignPattern_DEMOStep.Where(x => x.Num_Step == 1).FirstOrDefault();
      ServiceLocator.GetPrintExampleService.DEMO_GetVisualConsoleElementForCase(step1);
      ServiceLocator.GetPrintExampleService.DEMO_PrintAssociatedCodeLines(step1);
      // defining the music genres (by the means of songgroup implementation of the composition)
      SongComponent industrialMusic = new SongGroup("Industrial", "description of music 1");
      SongComponent heavyMetalMusic = new SongGroup("Heavy Metal", "some other descriptions for the second genre");
      SongComponent dubstepMusic = new SongGroup("Dubstep", "the last description for the music to play");

      // STEP2
      DesignPattern_DEMOStep step2 = MemLists.DesignPattern_DEMOStep.Where(x => x.Num_Step == 2).FirstOrDefault();
      ServiceLocator.GetPrintExampleService.DEMO_GetVisualConsoleElementForCase(step2);
      ServiceLocator.GetPrintExampleService.DEMO_PrintAssociatedCodeLines(step2);
      // defining the list of every available song 
      SongComponent everySong = new SongGroup("SongList", "every song available");

      // STEP3
      DesignPattern_DEMOStep step3 = MemLists.DesignPattern_DEMOStep.Where(x => x.Num_Step == 3).FirstOrDefault();
      ServiceLocator.GetPrintExampleService.DEMO_GetVisualConsoleElementForCase(step3);
      ServiceLocator.GetPrintExampleService.DEMO_PrintAssociatedCodeLines(step3);
      // adding the different music (before to the list of available list and then the songs to the different songlists)
      // adding for the industrial music
      everySong.Add(industrialMusic);
      industrialMusic.Add(new Song("Head like a hole", "NIN", 1990));
      industrialMusic.Add(new Song("Headhunter", "Front 242", 1988));

      // STEP4
      DesignPattern_DEMOStep step4 = MemLists.DesignPattern_DEMOStep.Where(x => x.Num_Step == 4).FirstOrDefault();
      ServiceLocator.GetPrintExampleService.DEMO_GetVisualConsoleElementForCase(step4);
      ServiceLocator.GetPrintExampleService.DEMO_PrintAssociatedCodeLines(step4);
      // adding the dubsteps songs as a second branch of the industrial music 
      industrialMusic.Add(dubstepMusic);
      // adding songs for the dubstep music 
      dubstepMusic.Add(new Song("Centipede", "Knife Party", 2012));
      dubstepMusic.Add(new Song("Tetris", "Doctor P", 2011));

      // STEP5
      DesignPattern_DEMOStep step5 = MemLists.DesignPattern_DEMOStep.Where(x => x.Num_Step == 5).FirstOrDefault();
      ServiceLocator.GetPrintExampleService.DEMO_GetVisualConsoleElementForCase(step5);
      ServiceLocator.GetPrintExampleService.DEMO_PrintAssociatedCodeLines(step5);
      // adding the branch of Metal Music to all the songs 
      everySong.Add(heavyMetalMusic);
      // adding songs to heavy metal 
      heavyMetalMusic.Add(new Song("War Pigs", "Black Sabbath", 1970));
      heavyMetalMusic.Add(new Song("Ace of Spades", "Motorhead", 1980));

      // STEP6
      DesignPattern_DEMOStep step6 = MemLists.DesignPattern_DEMOStep.Where(x => x.Num_Step == 6).FirstOrDefault();
      ServiceLocator.GetPrintExampleService.DEMO_GetVisualConsoleElementForCase(step6);
      ServiceLocator.GetPrintExampleService.DEMO_PrintAssociatedCodeLines(step6);
      ServiceLocator.GetPrintExampleService.DEMO_ResetColorParameters();
      // instance of the DiscJockey which is able to play every song available
      DesignPatterns.Structural.Composite.DiscJockey crazyLarry = new DesignPatterns.Structural.Composite.DiscJockey(everySong);
      crazyLarry.GetSongList();
      ServiceLocator.GetPrintExampleService.DEMO_ResetColorParameters();

      // Lettura comando di exit
      ServiceLocator.GetPrintExampleService.DEMO_ShowExitLabel();
    }


    public static void Decorator_LiveDEMO()
    {
      // STEP1
      DesignPattern_DEMOStep step1 = MemLists.DesignPattern_DEMOStep.Where(x => x.Num_Step == 1).FirstOrDefault();
      ServiceLocator.GetPrintExampleService.DEMO_GetVisualConsoleElementForCase(step1);
      ServiceLocator.GetPrintExampleService.DEMO_PrintAssociatedCodeLines(step1);
      ServiceLocator.GetPrintExampleService.DEMO_ResetColorParameters();
      // adding the different components dynamically for creating the pizza we want 
      Pizza3 basicPizza = new TomatoSauce(new Mozzarella(new PlainPizza()));
      ServiceLocator.GetPrintExampleService.DEMO_ResetColorParameters();
      // Lettura comando di exit
      ServiceLocator.GetPrintExampleService.DEMO_ShowExitLabel();
    }


    public static void Facade_LiveDEMO()
    {
      // STEP1
      DesignPattern_DEMOStep step1 = MemLists.DesignPattern_DEMOStep.Where(x => x.Num_Step == 1).FirstOrDefault();
      ServiceLocator.GetPrintExampleService.DEMO_GetVisualConsoleElementForCase(step1);
      ServiceLocator.GetPrintExampleService.DEMO_PrintAssociatedCodeLines(step1);
      ServiceLocator.GetPrintExampleService.DEMO_ResetColorParameters();
      // creating a new instance of FACADE for accessing the bank account
      // for the creation the account number and the security code have to be passed
      BankAccountFacade accessingBank = new BankAccountFacade(12345678, 1234);
      ServiceLocator.GetPrintExampleService.DEMO_ResetColorParameters();

      // STEP2
      DesignPattern_DEMOStep step2 = MemLists.DesignPattern_DEMOStep.Where(x => x.Num_Step == 2).FirstOrDefault();
      ServiceLocator.GetPrintExampleService.DEMO_GetVisualConsoleElementForCase(step2);
      ServiceLocator.GetPrintExampleService.DEMO_PrintAssociatedCodeLines(step2);
      ServiceLocator.GetPrintExampleService.DEMO_ResetColorParameters();
      // using some methods for doing operations on bank account 
      // withdrawing some cash
      accessingBank.WithdrawCash(50);
      ServiceLocator.GetPrintExampleService.DEMO_ResetColorParameters();

      // STEP3
      DesignPattern_DEMOStep step3 = MemLists.DesignPattern_DEMOStep.Where(x => x.Num_Step == 3).FirstOrDefault();
      ServiceLocator.GetPrintExampleService.DEMO_GetVisualConsoleElementForCase(step3);
      ServiceLocator.GetPrintExampleService.DEMO_PrintAssociatedCodeLines(step3);
      ServiceLocator.GetPrintExampleService.DEMO_ResetColorParameters();
      // using some methods for doing operations on bank account 
      // withdrawing some cash
      accessingBank.WithdrawCash(990);
      ServiceLocator.GetPrintExampleService.DEMO_ResetColorParameters();

      // STEP4
      DesignPattern_DEMOStep step4 = MemLists.DesignPattern_DEMOStep.Where(x => x.Num_Step == 4).FirstOrDefault();
      ServiceLocator.GetPrintExampleService.DEMO_GetVisualConsoleElementForCase(step4);
      ServiceLocator.GetPrintExampleService.DEMO_PrintAssociatedCodeLines(step4);
      ServiceLocator.GetPrintExampleService.DEMO_ResetColorParameters();
      // using some methods for doing operations on bank account 
      // deposite some cash
      accessingBank.DepositCash(1000);
      ServiceLocator.GetPrintExampleService.DEMO_ResetColorParameters();

      // Lettura comando di exit
      ServiceLocator.GetPrintExampleService.DEMO_ShowExitLabel();
    }


    /// <summary>
    /// Demo per il flyweight
    /// </summary>
    public static void FlyWeight_LiveDEMO()
    {
      Main_Flyweight.RunExample(); // directly running example without step
    }


    /// <summary>
    /// Demo for the Proxy
    /// </summary>
    public static void Proxy_LiveDEMO()
    {
      // STEP1
      DesignPattern_DEMOStep step1 = MemLists.DesignPattern_DEMOStep.Where(x => x.Num_Step == 1).FirstOrDefault();
      ServiceLocator.GetPrintExampleService.DEMO_GetVisualConsoleElementForCase(step1);
      ServiceLocator.GetPrintExampleService.DEMO_PrintAssociatedCodeLines(step1);
      // those first set of methods are used without the proxy peremeter
      ATMMachine atmMachine = new ATMMachine();

      // STEP2
      DesignPattern_DEMOStep step2 = MemLists.DesignPattern_DEMOStep.Where(x => x.Num_Step == 2).FirstOrDefault();
      ServiceLocator.GetPrintExampleService.DEMO_GetVisualConsoleElementForCase(step2);
      ServiceLocator.GetPrintExampleService.DEMO_PrintAssociatedCodeLines(step2);
      ServiceLocator.GetPrintExampleService.DEMO_ResetColorParameters();
      atmMachine.InsertCard();

      atmMachine.EjectCard();

      atmMachine.InsertCard();

      atmMachine.InsertPin(1234);

      atmMachine.RequestCash(200);

      atmMachine.InsertCard();

      atmMachine.InsertPin(1111);
      ServiceLocator.GetPrintExampleService.DEMO_ResetColorParameters();

      // STEP3
      DesignPattern_DEMOStep step3 = MemLists.DesignPattern_DEMOStep.Where(x => x.Num_Step == 3).FirstOrDefault();
      ServiceLocator.GetPrintExampleService.DEMO_GetVisualConsoleElementForCase(step3);
      ServiceLocator.GetPrintExampleService.DEMO_PrintAssociatedCodeLines(step3);
      // NEW STUFF: Proxy Design Pattern Code
      // the interface limits access to just the methods you want 
      // made accessible 
      GetATMData atmProxy = new ATMProxy();

      // STEP4
      DesignPattern_DEMOStep step4 = MemLists.DesignPattern_DEMOStep.Where(x => x.Num_Step == 4).FirstOrDefault();
      ServiceLocator.GetPrintExampleService.DEMO_GetVisualConsoleElementForCase(step4);
      ServiceLocator.GetPrintExampleService.DEMO_PrintAssociatedCodeLines(step4);
      ServiceLocator.GetPrintExampleService.DEMO_ResetColorParameters();
      Console.WriteLine("Current ATM State: " + atmProxy.GetATMState().ToString());
      Console.WriteLine("Cash in ATM Machine: " + atmProxy.GetCashInMachine());
      ServiceLocator.GetPrintExampleService.DEMO_ResetColorParameters();

      // The user can't perform this action because ATMProxy doesn't have access 
      // to that potentially harmful method
      // atmProxy.SetCashInMachine(10000);

      // STEP5
      DesignPattern_DEMOStep step5 = MemLists.DesignPattern_DEMOStep.Where(x => x.Num_Step == 5).FirstOrDefault();
      ServiceLocator.GetPrintExampleService.DEMO_GetVisualConsoleElementForCase(step5);
      ServiceLocator.GetPrintExampleService.DEMO_PrintAssociatedCodeLines(step5);
      // applying the PROXY to the first ATM machine instead:
      // the money have been decrease by the request of cash and the state is haspin one
      atmProxy = new ATMProxy(atmMachine);

      // STEP6
      DesignPattern_DEMOStep step6 = MemLists.DesignPattern_DEMOStep.Where(x => x.Num_Step == 6).FirstOrDefault();
      ServiceLocator.GetPrintExampleService.DEMO_GetVisualConsoleElementForCase(step6);
      ServiceLocator.GetPrintExampleService.DEMO_PrintAssociatedCodeLines(step6);
      ServiceLocator.GetPrintExampleService.DEMO_ResetColorParameters();
      Console.WriteLine("Current ATM State: " + atmProxy.GetATMState().ToString());
      Console.WriteLine("Cash in ATM Machine: " + atmProxy.GetCashInMachine());
      ServiceLocator.GetPrintExampleService.DEMO_ResetColorParameters();
      // Lettura comando di exit
      ServiceLocator.GetPrintExampleService.DEMO_ShowExitLabel();
    }
    
    #endregion
  }
}
