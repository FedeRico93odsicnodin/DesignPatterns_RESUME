using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Creational.Factory
{
  /// <summary>
  /// This abstract class represents all the properties which the enemy has to be 
  /// in the game 
  /// </summary>
  public class EnemyShip
  {
    private string _name;
    private double _amtDamage;

    public string Name { get => _name; set => _name = value; }
    public double AmtDamage { get => _amtDamage; set => _amtDamage = value; }

    public void FollowHeroShip()
    {
      Console.WriteLine(Name + " is following the hero");
    }

    public void DisplayEnemyShip()
    {
      Console.WriteLine(Name + " is on screen");
    }

    public void EnemyShipShoots()
    {
      Console.WriteLine(Name + " attacks and does " + AmtDamage);
    }
  }
}
