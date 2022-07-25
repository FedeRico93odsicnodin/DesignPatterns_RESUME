using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Behavioural.Iterator
{
  public abstract class IteratorAggregate : IEnumerable
  {
    // returns an iterator or another IteratorAggregate for the implementing object 
    public abstract IEnumerator GetEnumerator();
  }
}
