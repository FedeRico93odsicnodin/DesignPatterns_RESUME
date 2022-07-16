using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Structural.Facade
{
  /// <summary>
  /// Simply for checking the correctness of the security code 
  /// </summary>
  public class SecurityCodeCheck
  {
    private int _securityCode = 1234;

    public int GetSecurityCode() { return _securityCode; }

    public bool IsCodeCorrect(int securityCodeToCheck)
    {
      if (securityCodeToCheck == _securityCode)
        return true;
      else
        return false;
    }
  }
}
