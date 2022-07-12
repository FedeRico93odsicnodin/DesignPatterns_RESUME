using DesignPatterns.Model;
using DesignPatterns.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Behavioural.Strategy
{
  public class Main_Strategy
  {
    public static void RunExample()
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
  }
}
