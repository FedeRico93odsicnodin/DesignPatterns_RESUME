using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Creational.Factory
{
  public class Main_Factory
  {
    public void RunExample()
    {
      // creating the new ship factory 
      EnemyShipFactory factoryShip = new EnemyShipFactory();

      // asking to the user which ship wants to create 
      Console.WriteLine("Please select the ship (U , R , B)");
      Console.WriteLine("(by default the Rocket ship will be returned)");
      string input = Console.ReadKey().ToString();

      // giving the input to the factory 
      EnemyShip returnedShip = factoryShip.CreateShip(input);

      // seeing the effects of the created ship for the case
      EnemyShipTesting.DoStuffEnemy(returnedShip);
    }
  }
}
