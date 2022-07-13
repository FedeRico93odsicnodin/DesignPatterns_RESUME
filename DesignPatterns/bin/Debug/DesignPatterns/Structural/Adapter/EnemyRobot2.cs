using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Structural.Adapter
{
  public class EnemyRobot2
  {
    Random generator = new Random();

    // this is more similar to the method interface 'FireWeapon()'
    public void SmashWithHands()
    {
      int attackDamage = generator.Next(1, 11) + 1;
      Console.WriteLine("Enemy robot causes " + attackDamage + " damage with its hands");
    }

    // this is more similar to the method interface 'DriveForward()'
    public void WalkForwand()
    {
      int movement = generator.Next(1, 6) + 1;
      Console.WriteLine("Enemy Robot walks forward " + movement + " Spaces");
    }

    // this is more similar to the method interface 'AssignDriver(string driverName)'
    public void ReactToHuman(string human)
    {
      Console.WriteLine("Enemy robot says 'Hello' to " + human);
    }
  }
}
