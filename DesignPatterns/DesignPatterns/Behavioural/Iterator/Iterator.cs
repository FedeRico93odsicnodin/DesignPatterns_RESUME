using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Behavioural.Iterator
{
  /// <summary>
  /// Iterator to be implemented 
  /// </summary>
  public abstract class Iterator : IEnumerator
  {
    object IEnumerator.Current => Current();

    public abstract int Key();

    public abstract object Current();

    public abstract bool MoveNext();

    public abstract void Reset();
  }
}
