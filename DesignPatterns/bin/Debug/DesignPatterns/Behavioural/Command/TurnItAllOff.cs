using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Behavioural.Command
{
  public class TurnItAllOff : Command
  {
    private List<ElectronicDevice> _theDevices;

    public TurnItAllOff(List<ElectronicDevice> newDevices)
    {
      _theDevices = newDevices;
    }

    public void Execute()
    {
      // every device is turned off
      foreach (ElectronicDevice device in _theDevices)
        device.Off();
    }
  }
}
