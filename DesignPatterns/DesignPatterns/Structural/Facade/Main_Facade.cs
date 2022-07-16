using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Structural.Facade
{
  class Main_Facade
  {
    /// <summary>
    /// In this first implementation of the Example in run there are some elements shown:
    /// all those elements have to work by the mean of the interface
    /// In next implementations we see how all the mechanism work
    /// </summary>
    public static void RunExample()
    {
      // creating a new instance of FACADE for accessing the bank account
      // for the creation the account number and the security code have to be passed
      BankAccountFacade accessingBank = new BankAccountFacade(12345678, 1234);

      // using some methods for doing operations on bank account 
      // withdrawing some cash
      accessingBank.WithdrawCash(50);

      // using some methods for doing operations on bank account 
      // withdrawing some cash
      accessingBank.WithdrawCash(990);

      // using some methods for doing operations on bank account 
      // deposite some cash
      accessingBank.DepositCash(1000);
    }
  }
}
