using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Behavioural.Chain_of_Responsibility
{
  /// <summary>
  /// This is the interface for every element in the chain
  /// </summary>
  public interface Chain
  {
    void SetNextChain(Chain nextChain);

    void Calculate(Numbers request);
  }
}
