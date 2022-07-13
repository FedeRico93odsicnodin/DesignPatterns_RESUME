using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Structural.Adapter
{
  /// <summary>
  /// This is a tank implementing the standard interfaces
  /// </summary>
  public class EnemyTank : EnemyAttacker
  {
    public void AssignDriver(string driverName)
    {
      Console.WriteLine(driverName + " is driving the tank");
    }

    public void DriveForward()
    {
      Random rnd = new Random();
      int movement = rnd.Next(1, 6);
      Console.WriteLine("Enemy tank moves " + movement + " spaces");
    }

    public void FireWeapon()
    {
      Console.WriteLine("Enemy tank is firing!");
    }
  }
}
