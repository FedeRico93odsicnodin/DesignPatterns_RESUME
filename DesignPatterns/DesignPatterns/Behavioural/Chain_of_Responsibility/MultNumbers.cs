using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Behavioural.Chain_of_Responsibility
{
  public class MultNumbers : Chain
  {
    private Chain _nextInChain;

    public void Calculate(Numbers request)
    {
      // if i can, I do the calculus
      if (request.GetCalcWanted() == "mult")
      {
        Console.WriteLine(request.GetNumber1() + " * " + request.GetNumber2() + " = " +
          (request.GetNumber1() * request.GetNumber2()));
      }
      // else I'm passing the responsibility to the next element in the chain
      else
      {
        _nextInChain.Calculate(request);
      }
    }

    public void SetNextChain(Chain nextChain)
    {
      this._nextInChain = nextChain;
    }
  }
}
