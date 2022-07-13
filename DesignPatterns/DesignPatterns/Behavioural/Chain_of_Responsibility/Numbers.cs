using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Behavioural.Chain_of_Responsibility
{
  public class Numbers
  {
    private int _number1;
    private int _number2;

    private string _calculationWanted;

    public Numbers(int newNum1, int newNum2, string calcWanted)
    {
      _number1 = newNum1;
      _number2 = newNum2;
      _calculationWanted = calcWanted;
    }

    public int GetNumber1() { return _number1; }
    public int GetNumber2() { return _number2; }
    public string GetCalcWanted() { return _calculationWanted; }
  }
}
