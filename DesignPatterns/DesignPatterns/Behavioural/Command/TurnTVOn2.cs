using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Behavioural.Command
{
  public class TurnTVOn2 : Command2
  {
    ElectronicDevice _theDevice;

    public TurnTVOn2(ElectronicDevice newDevice)
    {
      // implementation is done by the means of the interface of the receiver
      // the implementation is valid for every receiver which has this interface 
      _theDevice = newDevice;
    }


    public void Execute()
    {
      _theDevice.On();
    }

    public void Undo()
    {
      _theDevice.Off();
    }
  }
}
