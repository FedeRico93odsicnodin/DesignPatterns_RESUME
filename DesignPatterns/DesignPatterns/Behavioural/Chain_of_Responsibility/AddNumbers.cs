using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Behavioural.Chain_of_Responsibility
{
  /// <summary>
  /// This is an element in the chain: implementation of the given interface
  /// </summary>
  public class AddNumbers : Chain
  {
    private Chain _nextInChain;

    public void Calculate(Numbers request)
    {
      // if i can, I do the calculus
      if(request.GetCalcWanted() == "add")
      {
        Console.WriteLine(request.GetNumber1() + " + " + request.GetNumber2() + " = " + 
          (request.GetNumber1() + request.GetNumber2()));
      }
      // else I'm passing the responsibility to the next element in the chain
      else
      {
        _nextInChain.Calculate(request);
      }
    }

    /// <summary>
    /// Setting the next element in the chain
    /// </summary>
    /// <param name="nextChain"></param>
    public void SetNextChain(Chain nextChain)
    {
      this._nextInChain = nextChain;
    }
  }
}
