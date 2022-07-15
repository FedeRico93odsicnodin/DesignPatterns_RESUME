using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Creational.Factory
{
  public class RocketEnemyShip : EnemyShip
  {
    public RocketEnemyShip()
    {
      // setting the properties for this particular Enemy Ship
      Name = "Rocket Enemy Ship";
      AmtDamage = 10;
    }
  }
}
