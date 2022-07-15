using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Creational.Factory
{
  class EnemyShipTesting
  {
    public static void RunExample()
    {
      EnemyShip ufoShip = new UFOEnemyShip();

      DoStuffEnemy(ufoShip);
    }
    /// <summary>
    /// Old way to implement a constructor and some actions for the class 
    /// we want our enemy to do something ...
    /// This way is not dynamic
    /// </summary>
    /// <param name="anEnemyShip"></param>
    public static void DoStuffEnemy(EnemyShip anEnemyShip)
    {
      anEnemyShip.DisplayEnemyShip();
      anEnemyShip.FollowHeroShip();
      anEnemyShip.EnemyShipShoots();
    }
  }
}
