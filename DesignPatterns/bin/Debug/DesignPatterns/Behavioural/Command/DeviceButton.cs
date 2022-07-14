using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Behavioural.Command
{
  /// <summary>
  /// NB: devie button knows nothing 
  /// it doesn't know what device or command is being used
  /// </summary>
  public class DeviceButton
  {
    private Command _theCommand;

    public DeviceButton(Command newCommand)
    {
      _theCommand = newCommand;
    }

    public void Press()
    {
      _theCommand.Execute();
    }
  }
}
