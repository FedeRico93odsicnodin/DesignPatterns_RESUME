using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Behavioural.Command
{
  /// <summary>
  /// Interface for the receiver
  /// </summary>
  public interface ElectronicDevice
  {
    void On();

    void Off();

    void VolumeUp();

    void VolumeDown();
  }
}
