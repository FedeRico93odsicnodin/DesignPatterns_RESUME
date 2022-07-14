using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Structural.Bridge
{
  /// <summary>
  /// Abstraction
  /// It will represent numerous ways to work with each device
  /// </summary>
  public abstract class RemoteButton
  {
    private EntertainmentDevice _theDevice;

    public RemoteButton(EntertainmentDevice newDevice)
    {
      _theDevice = newDevice;
    }
    public void ButtonFivePressed()
    {
      _theDevice.ButtonFivePressed();
    }
    public void ButtonSixPressed()
    {
      _theDevice.ButtonSixPressed();
    }
    public void DeviceFeedback()
    {
      _theDevice.DeviceFeedback();
    }

    public abstract void ButtonNinePressed();
  }
}
