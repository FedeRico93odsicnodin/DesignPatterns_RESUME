using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Creational.Factory
{
  public class UFOEnemyShip : EnemyShip
  {
    public UFOEnemyShip()
    {
      // setting the properties for this particular kind of enemy ship
      Name = "UFO enemy ship";
      AmtDamage = 20;
    }
  }
}
