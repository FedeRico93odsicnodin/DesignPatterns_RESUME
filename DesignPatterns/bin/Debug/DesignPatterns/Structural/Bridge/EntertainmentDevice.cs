using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Structural.Bridge
{
  /// <summary>
  /// Implementor 
  /// With the Bridge design pattern you create 2 layers of abstraction
  /// We have an abstract class representing different types of devices
  /// Another abstract class will represent different types of remote control
  /// 
  /// This allows to use an infinite variety of devices and remotes
  /// </summary>
  public abstract class EntertainmentDevice
  {
    public int DeviceState;

    public int MaxSetting;

    public int VolumeLevel = 0;

    public abstract void ButtonFivePressed();

    public abstract void ButtonSixPressed();

    /// <summary>
    /// Peremeter of the actions and telling the feedback
    /// </summary>
    public void DeviceFeedback()
    {
      if(DeviceState > MaxSetting || DeviceState < 0)
      {
        DeviceState = 0;
      }
      Console.WriteLine("On Channel " + DeviceState);
    }
    /// <summary>
    /// Standard behaviours dictated by this first abstraction
    /// this is the specifications for the volume up and down
    /// </summary>
    public void ButtonSevenPressed()
    {
      VolumeLevel++;
      Console.WriteLine("Volume at: " + VolumeLevel);
    }
    public void ButtonEightPressed()
    {
      VolumeLevel--;
      Console.WriteLine("Volume at:" + VolumeLevel);
    }
  }
}
