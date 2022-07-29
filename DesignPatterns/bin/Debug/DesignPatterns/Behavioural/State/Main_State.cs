using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Behavioural.State
{
  public class Main_State
  {
    public static void RunExample()
    {
      // those first set of methods are used without the proxy peremeter
      ATMMachine atmMachine = new ATMMachine();

      atmMachine.InsertCard();

      atmMachine.EjectCard();

      atmMachine.InsertCard();

      atmMachine.InsertPin(1234);

      atmMachine.RequestCash(200);

      atmMachine.InsertCard();

      atmMachine.InsertPin(1111);
    }
  }
}
