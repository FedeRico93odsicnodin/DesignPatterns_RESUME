using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Behavioural.State
{
  public class HasCard : ATMState
  {
    private ATMMachine _atmMachine;

    private bool _pinInserted;

    public HasCard(ATMMachine atmMachine)
    {
      _atmMachine = atmMachine;
      _pinInserted = false;
    }


    public void EjectCard()
    {
      Console.WriteLine("card ejected");
      _atmMachine.SetATMState(_atmMachine.NoCard);
    }

    public void InsertCard()
    {
      Console.WriteLine("a card is already in");
    }

    public void InsertPin(int pinEntered)
    {
      Console.WriteLine("the PIN is inserted");
      _atmMachine.SetATMState(_atmMachine.HasCorrectPin);
    }

    public void RequestCash(int cashToWithdraw)
    {
      Console.WriteLine("insert pin before");
    }

    /// <summary>
    /// Identifying the state 
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
      return "HAS CARD";
    }
  }
}
