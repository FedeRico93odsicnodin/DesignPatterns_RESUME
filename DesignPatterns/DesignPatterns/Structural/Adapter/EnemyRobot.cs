using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Structural.Adapter
{
  /// <summary>
  /// This is the class which does not implement the interface standard 
  /// by default 
  /// Maybe it was a definition of an enemy which was there before the 
  /// adopted standardization 
  /// </summary>
  public class EnemyRobot
  {
    Random generator = new Random();

    public void SmashWithHands()
    {
      int attackDamage = generator.Next(1, 11) + 1;
      Console.WriteLine("Enemy robot causes " + attackDamage + " damage with its hands");
    }


    public void WalkForwand()
    {
      int movement = generator.Next(1, 6) + 1;
      Console.WriteLine("Enemy Robot walks forward " + movement + " Spaces");
    }


    public void ReactToHuman(string human)
    {
      Console.WriteLine("Enemy robot says 'Hello' to " + human);
    }
  }
}
