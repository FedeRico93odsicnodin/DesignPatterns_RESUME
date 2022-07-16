using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Structural.Facade
{
  public class FundsCheck
  {
    private double _cashInAccount = 1000;

    public double GetCashInAccount() { return _cashInAccount; }

    public void DecreaseCashInAccount(double cashWithDrawn)
    {
      _cashInAccount -= cashWithDrawn;
    }

    public void IncreaseCashInAccount(double cashDeposited)
    {
      _cashInAccount += cashDeposited;
    }

    public bool HaveEnoughMoney(double cashToWithdrawal)
    {
      if(cashToWithdrawal > GetCashInAccount())
      {
        Console.WriteLine("Error: you don't have enough money");
        Console.WriteLine("Current Balance: " + GetCashInAccount());
        return false;
      }
      else
      {
        DecreaseCashInAccount(cashToWithdrawal);
        Console.WriteLine("Withdrawal complete: current balance is " + GetCashInAccount());
        return true;
      }
    }
    
    public void MakeDeposit(double cashToDeposit)
    {
      IncreaseCashInAccount(cashToDeposit);
      Console.WriteLine("Deposit complete: current balance is " + GetCashInAccount());
    }
  }
}
