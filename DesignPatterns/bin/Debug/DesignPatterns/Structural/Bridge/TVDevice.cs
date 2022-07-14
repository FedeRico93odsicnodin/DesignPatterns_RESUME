using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Structural.Bridge
{
  /// <summary>
  /// Concrete implementor
  /// It is specified what does it make different from other device 
  /// </summary>
  public class TVDevice : EntertainmentDevice
  {
    public TVDevice(int newDeviceState, int newMaxSetting)
    {
      DeviceState = newDeviceState;
      MaxSetting = newMaxSetting;
    } 

    public override void ButtonFivePressed()
    {
      Console.WriteLine("Channel Down");
      DeviceState--;
    }

    public override void ButtonSixPressed()
    {
      Console.WriteLine("Channel Up");
      DeviceState++;
    }
  }
}
