using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Behavioural.Command
{
  public class TVRemote
  {
    public static ElectronicDevice GetDevice()
    {
      // the television is the receiver for doing everything
      return new Television();
    }
  }
}
