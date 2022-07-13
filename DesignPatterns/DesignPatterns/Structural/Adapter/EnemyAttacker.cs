using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Structural.Adapter
{
  /// <summary>
  /// This is the general and standardized interface for all the 
  /// enemy attackers in a game
  /// </summary>
  public interface EnemyAttacker
  {
    void FireWeapon();
    void DriveForward();
    void AssignDriver(string driverName);
  }
}
