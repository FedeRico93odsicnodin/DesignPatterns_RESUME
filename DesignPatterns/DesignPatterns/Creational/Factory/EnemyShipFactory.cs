using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Creational.Factory
{
  public class EnemyShipFactory
  {
    public EnemyShip CreateShip(string shipType)
    {
      switch(shipType)
      {
        case "U": return new UFOEnemyShip();
        case "R": return new RocketEnemyShip();
        case "B": return new BlastEnemyShip();
      }
      // by default we return a rocket enemy ship
      return new RocketEnemyShip();
    }
  }
}
