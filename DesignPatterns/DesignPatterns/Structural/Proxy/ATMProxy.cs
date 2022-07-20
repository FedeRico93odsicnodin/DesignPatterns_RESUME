using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Structural.Proxy
{
  /// <summary>
  /// In this situation the proxy both creates and destroys 
  /// an ATMMachine Object
  /// </summary>
  public class ATMProxy : GetATMData
  {
    ATMMachine _atmMachine;

    /// <summary>
    /// 2 Types of constructor: the first with a new ATM Machine 
    /// </summary>
    public ATMProxy()
    {
      _atmMachine = new ATMMachine();
    }


    /// <summary>
    /// The second with the possibility of applying a proxy on existing ATM Machine 
    /// </summary>
    /// <param name="_newATMMachine"></param>
    public ATMProxy(ATMMachine _newATMMachine)
    {
      _atmMachine = _newATMMachine;
    }


    /// <summary>
    /// Allows the user to access getATMState in the Object ATMMachine
    /// </summary>
    /// <returns></returns>
    public ATMState GetATMState()
    {
      return _atmMachine.GetATMState();
    }
    
    /// <summary>
    /// Allows the user to access getCashInMachine in the Object ATMMachine
    /// </summary>
    /// <returns></returns>
    public int GetCashInMachine()
    {
      return _atmMachine.GetCashInMachine();
    }
  }
}
