using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Behavioural.Command
{
  public class DeviceButton2
  {
    private Command2 _theCommand;

    public DeviceButton2(Command2 newCommand)
    {
      _theCommand = newCommand;
    }

    public void Press()
    {
      _theCommand.Execute();
    }

    public void PressUndo()
    {
      _theCommand.Execute();
    }
  }
}
