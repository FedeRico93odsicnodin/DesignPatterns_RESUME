using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Behavioural.Command
{
  class Radio : ElectronicDevice
  {
    private int _radioVolume;

    public void Off()
    {
      Console.WriteLine("Radio is OFF");
    }

    public void On()
    {
      Console.WriteLine("Radio is ON");
    }

    public void VolumeDown()
    {
      _radioVolume--;
      Console.WriteLine("Radio Volume is at " + _radioVolume);
    }

    public void VolumeUp()
    {
      _radioVolume++;
      Console.WriteLine("Radio Volume is at " + _radioVolume);
    }
  }
}
