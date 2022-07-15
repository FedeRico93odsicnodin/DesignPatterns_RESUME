using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Creational.Factory
{
  public class BlastEnemyShip : EnemyShip
  {
    public BlastEnemyShip()
    {
      // setting the properties for this particular Enemy Ship
      Name = "Blast Enemy Ship";
      AmtDamage = 1000;
    }
  }
}
