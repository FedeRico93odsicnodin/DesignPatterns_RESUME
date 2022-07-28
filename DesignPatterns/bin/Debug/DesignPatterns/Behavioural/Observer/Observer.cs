using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Behavioural.Observer
{
  /// <summary>
  /// The observers update method is called when the Subject changes
  /// </summary>
  public interface Observer
  {
    void Update(double ibmPrice, double applPrice, double googPrice);
  }
}
