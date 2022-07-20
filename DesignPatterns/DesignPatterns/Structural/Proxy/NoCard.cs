using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Structural.Proxy
{
  public class NoCard : ATMState
  {
    private ATMMachine _atmMachine;

    public NoCard(ATMMachine atmMachine)
    {
      _atmMachine = atmMachine;
    }


    public void EjectCard()
    {
      Console.WriteLine("no card in the machine");
    }

    public void InsertCard()
    {
      Console.WriteLine("card is inserted");
      _atmMachine.SetATMState(_atmMachine.HasCard);
    }

    public void InsertPin(int pinEntered)
    {
      Console.WriteLine("insert card before");
    }

    public void RequestCash(int cashToWithdraw)
    {
      Console.WriteLine("insert card before");
    }

    /// <summary>
    /// Identifying the state 
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
      return "NO CARD";
    }
  }
}
