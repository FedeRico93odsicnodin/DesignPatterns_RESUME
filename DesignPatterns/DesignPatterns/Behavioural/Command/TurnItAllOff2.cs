using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Behavioural.Command
{
  public class TurnItAllOff2 : Command2
  {
    private List<ElectronicDevice> _theDevices;

    public TurnItAllOff2(List<ElectronicDevice> newDevices)
    {
      _theDevices = newDevices;
    }

    public void Execute()
    {
      // every device is turned off
      foreach (ElectronicDevice device in _theDevices)
        device.Off();
    }

    public void Undo()
    {
      // every device is turned on
      foreach (ElectronicDevice device in _theDevices)
        device.On();
    }
  }
}
