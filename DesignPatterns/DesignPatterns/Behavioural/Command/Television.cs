using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Behavioural.Command
{
  public class Television : ElectronicDevice
  {
    private int _volume;

    public void Off()
    {
      // implementation of the interface 
      Console.WriteLine("TV is OFF");
    }

    public void On()
    {
      // implementation of the interface 
      Console.WriteLine("TV is ON");
    }

    public void VolumeDown()
    {
      // implementation of the interface 
      _volume--;
      Console.WriteLine("TV Volume is at " + _volume);
    }

    public void VolumeUp()
    {
      // implementation of the interface 
      _volume++;
      Console.WriteLine("TV Volume is at " + _volume);
    }
  }
}
