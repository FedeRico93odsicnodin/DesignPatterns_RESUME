using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Behavioural.Mediator
{
  public class GormanSlacks : Colleague
  {
    public GormanSlacks(Mediator newMediator) : base(newMediator)
    {
      Console.WriteLine("Gorman Slacks signed up with the stockexchange\n");
    }
  }
}
