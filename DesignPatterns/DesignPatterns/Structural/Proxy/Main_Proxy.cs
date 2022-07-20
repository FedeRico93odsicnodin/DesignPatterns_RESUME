using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Structural.Proxy
{
  public class Main_Proxy
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

      // NEW STUFF: Proxy Design Pattern Code
      // the interface limits access to just the methods you want 
      // made accessible 
      GetATMData atmProxy = new ATMProxy();

      Console.WriteLine("Current ATM State: " + atmProxy.GetATMState().ToString());
      Console.WriteLine("Cash in ATM Machine: " + atmProxy.GetCashInMachine());

      // The user can't perform this action because ATMProxy doesn't have access 
      // to that potentially harmful method
      // atmProxy.SetCashInMachine(10000);

      // applying the PROXY to the first ATM machine instead:
      // the money have been decrease by the request of cash and the state is haspin one
      atmProxy = new ATMProxy(atmMachine);

      Console.WriteLine("Current ATM State: " + atmProxy.GetATMState().ToString());
      Console.WriteLine("Cash in ATM Machine: " + atmProxy.GetCashInMachine());
    }
  }
}
