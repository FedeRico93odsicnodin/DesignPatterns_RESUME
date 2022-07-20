using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Structural.Proxy
{
  public class ATMMachine : GetATMData
  {
    public ATMState HasCard;
    public ATMState NoCard;
    public ATMState HasCorrectPin;
    public ATMState AtmOutOfMoney;

    private ATMState _atmState;

    private int _cashInMachine = 2000;


    public ATMMachine()
    {
      // initialization the different elements 
      HasCard = new HasCard(this);
      NoCard = new NoCard(this);
      HasCorrectPin = new HasPin(this);
      AtmOutOfMoney = new NoCard(this);

      // first state for the machine 
      _atmState = NoCard;

      if(_cashInMachine < 0)
      {
        _atmState = AtmOutOfMoney;
      }
    }

    public void SetATMState(ATMState newAtmState)
    {
      if (_cashInMachine < 0)
      {
        _atmState = AtmOutOfMoney;
      }
      else
      {
        _atmState = newAtmState;
      }
    }

    public void SetCashInMachine(int newCashInMachine)
    {
      _cashInMachine += newCashInMachine;
      _atmState = NoCard;
    }

    public void GetCashInMachine(int cashRequest)
    {
      if(_cashInMachine < cashRequest)
      {
        Console.WriteLine("insufficient cash");
      }
      else
      {
        _cashInMachine -= cashRequest;
        Console.WriteLine("cash is withdrawn");
      }
    }

    public void InsertCard()
    {
      _atmState.InsertCard();
    }

    public void InsertPin(int pin)
    {
      _atmState.InsertPin(pin);
    }

    public void EjectCard()
    {
      _atmState.EjectCard();
    }

    public void RequestCash(int cashToWithdraw)
    {
      _atmState.RequestCash(cashToWithdraw);
    }
    
    public ATMState GetATMState()
    {
      return _atmState;
    }

    public int GetCashInMachine()
    {
      return _cashInMachine;
    }
  }
}
