using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Behavioural.Observer
{
  /// <summary>
  /// This interface handles adding, deleting and updating all observers 
  /// </summary>
  public interface Subject
  {
    void Register(Observer o);

    void Unregister(Observer o);

    void NotifyObserver();
  }
}
