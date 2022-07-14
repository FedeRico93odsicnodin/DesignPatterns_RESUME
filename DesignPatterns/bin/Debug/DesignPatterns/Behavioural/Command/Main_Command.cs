using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Behavioural.Command
{
  class Main_Command
  {
    public static void RunExample()
    {
      // running the first example 
      ElectronicDevice newDevice = TVRemote.GetDevice();

      // getting the first command ON
      TurnTVOn2 onCommand = new TurnTVOn2(newDevice);

      // getting the first button
      DeviceButton2 onPressed = new DeviceButton2(onCommand);

      // running the effect of the first button 
      onPressed.Press();

      // getting the second command OFF (for the same device)
      TurnTVOff2 offCommand = new TurnTVOff2(newDevice);

      // passing the command to the button 
      onPressed = new DeviceButton2(offCommand);

      // running the effect of the second command on first button
      onPressed.Press();

      // getting the third command Up 
      TurnTVUp2 volUpCommand = new TurnTVUp2(newDevice);

      // passing the third command to the button 
      onPressed = new DeviceButton2(volUpCommand);

      // running the effect of the third command multiple time 
      onPressed.Press();
      onPressed.Press();
      onPressed.Press();

      // instances of 2 more devices: a TV and a RADIO
      Television theTV = new Television();
      Radio theRadio = new Radio();

      // adding the 2 devices to the list of all devices
      List<ElectronicDevice> allDevices = new List<ElectronicDevice>();
      allDevices.Add(theTV);
      allDevices.Add(theRadio);

      // running the turning off funcionality 
      TurnItAllOff2 turnOffDevices = new TurnItAllOff2(allDevices);
      DeviceButton2 turnThemOff = new DeviceButton2(turnOffDevices);
      turnThemOff.Press();

      // running the undo funcionalities on the devices
      turnThemOff.PressUndo();
    }
  }
}
