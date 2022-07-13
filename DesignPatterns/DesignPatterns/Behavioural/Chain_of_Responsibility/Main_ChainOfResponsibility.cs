using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Behavioural.Chain_of_Responsibility
{
  class Main_ChainOfResponsibility
  {
    public static void RunExample()
    {
      // elements of the chain initialization
      Chain chainCalc1 = new AddNumbers();
      Chain chainCalc2 = new SubNumbers();
      Chain chainCalc3 = new MultNumbers();
      Chain chainCalc4 = new DivNumbers();

      // making and setting the elements in the chain 
      chainCalc1.SetNextChain(chainCalc2);
      chainCalc2.SetNextChain(chainCalc3);
      chainCalc3.SetNextChain(chainCalc4);

      // CASE 1 intializing the number object 
      Numbers request = new Numbers(4, 2, "add");

      // doing the calculus
      chainCalc1.Calculate(request);

      // CASE 2: intizializing the number object 
      Numbers request2 = new Numbers(5, 5, "mult");

      // doing the calculus
      chainCalc1.Calculate(request2);

      // CASE 3: initializing the number object 
      Numbers request3 = new Numbers(2, 7, "not");

      // failing in doing the calculus
      chainCalc1.Calculate(request3);
    }
  }
}
