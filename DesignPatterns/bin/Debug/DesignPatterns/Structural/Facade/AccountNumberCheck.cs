using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Structural.Facade
{
  /// <summary>
  /// Simply for checking if the account bank is valid
  /// </summary>
  public class AccountNumberCheck
  {
    private int _accountNumber = 12345678;

    public int GetAccountNumber() { return _accountNumber; }

    public bool AccountActive(int accNumToCheck)
    {
      if (accNumToCheck == GetAccountNumber())
        return true;
      else
        return false;
    }
  }
}
