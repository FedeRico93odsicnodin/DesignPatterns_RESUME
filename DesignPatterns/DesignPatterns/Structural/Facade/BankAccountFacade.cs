using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Structural.Facade
{
  public class BankAccountFacade
  {
    // the elements related to the user
    private int _accountNumber;
    private int _securityCode;

    // the elements related to operations
    private WelcomeToBank _bankWelcome;
    private AccountNumberCheck _acctChecker;
    private SecurityCodeCheck _codeChecker;
    private FundsCheck _fundChecker;

    public BankAccountFacade(int newAccNum, int newSecCode)
    {
      // giving the account number and the security code 
      _accountNumber = newAccNum;
      _securityCode = newSecCode;

      // initializing the elements 
      _bankWelcome = new WelcomeToBank();
      _acctChecker = new AccountNumberCheck();
      _codeChecker = new SecurityCodeCheck();
      _fundChecker = new FundsCheck();
    }


    public int GetAccountNumber() { return _accountNumber; }

    public int GetSecurityCode() { return _securityCode; }


    public void WithdrawCash(double cash)
    {
      if(_acctChecker.AccountActive(GetAccountNumber()) && 
        _codeChecker.IsCodeCorrect(GetSecurityCode()) && 
        _fundChecker.HaveEnoughMoney(cash))
      {
        Console.WriteLine("Transaction Complete");
      }
      else
      {
        Console.WriteLine("Transaction Failed");
      }
    }

    public void DepositCash(double cash)
    {
      if (_acctChecker.AccountActive(GetAccountNumber()) &&
        _codeChecker.IsCodeCorrect(GetSecurityCode()))
      {
        _fundChecker.MakeDeposit(cash);
        Console.WriteLine("Transaction Complete");
      }
      else
      {
        Console.WriteLine("Transaction Failed");
      }
    }
  }
}
