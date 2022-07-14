using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Structural.Bridge
{
  public class Main_Bridge
  {
    public static void RunExample()
    {
      // creating a first TV Device 
      RemoteButton theTV = new TVRemoteMute(new TVDevice(1, 200));

      // creating a second TV Device
      RemoteButton theTV2 = new TVRemotePause(new TVDevice(1, 200));


      // testing the TV with MUTE button 
      Console.WriteLine("testing the TV with the MUTE BUTTON");
      theTV.ButtonFivePressed();
      theTV.ButtonSixPressed();
      theTV.ButtonNinePressed();

      // testing the TV with the PAUSE button 
      Console.WriteLine("testing the TV with the PAUSE BUTTON");
      theTV2.ButtonFivePressed();
      theTV2.ButtonSixPressed();
      theTV2.ButtonNinePressed();
      theTV2.DeviceFeedback();
    }
  }
}
