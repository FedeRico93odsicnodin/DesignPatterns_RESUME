using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Behavioural.Mediator
{
  public class JTPoorman : Colleague
  {
    public JTPoorman(Mediator newMediator) : base(newMediator)
    {
      Console.WriteLine("JT Poorman signed up with the stockexchange\n");
    }
  }
}
