using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Structural.Proxy
{
  public class NoCash : ATMState
  {
    private ATMMachine _atmMachine;

    public NoCash(ATMMachine atmMachine)
    {
      _atmMachine = atmMachine;
    }

    public void EjectCard()
    {
      Console.WriteLine("no money");
    }

    public void InsertCard()
    {
      Console.WriteLine("no money");
    }

    public void InsertPin(int pinEntered)
    {
      Console.WriteLine("no money");
    }

    public void RequestCash(int cashToWithdraw)
    {
      Console.WriteLine("no money");
    }

    /// <summary>
    /// Identifying the state 
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
      return "NO CASH";
    }
  }
}
