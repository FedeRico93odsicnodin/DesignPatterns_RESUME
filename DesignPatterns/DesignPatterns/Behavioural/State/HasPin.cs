using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Behavioural.State
{
  public class HasPin : ATMState
  {
    private ATMMachine _atmMachine;

    public HasPin(ATMMachine atmMachine)
    {
      _atmMachine = atmMachine;
    }

    public void EjectCard()
    {
      Console.WriteLine("card is ejected");
      _atmMachine.SetATMState(_atmMachine.NoCard);
    }

    public void InsertCard()
    {
      Console.WriteLine("another card is already in");
    }

    public void InsertPin(int pinEntered)
    {
      Console.WriteLine("a PIN has been already entered");
    }

    public void RequestCash(int cashToWithdraw)
    {
      _atmMachine.GetCashInMachine(cashToWithdraw);
    }

    /// <summary>
    /// Identifying the state 
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
      return "HAS PIN";
    }
  }
}
