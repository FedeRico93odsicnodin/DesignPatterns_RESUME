using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Structural.Bridge
{
  /// <summary>
  /// Refined abstraction
  /// If I decide I want to further extend the remote I can
  /// </summary>
  public class TVRemoteMute : RemoteButton
  {
    public TVRemoteMute(EntertainmentDevice newDevice) : base(newDevice)
    {
    }

    public override void ButtonNinePressed()
    {
      Console.WriteLine("TV Was Mute");
    }
  }
}
