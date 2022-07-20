using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Structural.Proxy
{
  /// <summary>
  /// This interface will contain just those methods
  /// that you want the proxy to provide access to
  /// </summary>
  public interface GetATMData
  {
    ATMState GetATMState();

    int GetCashInMachine();
  }
}
