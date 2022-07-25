using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Behavioural.Iterator
{
  public class Collection : IteratorAggregate
  {
    private IList _collection = new List<object>();

    protected bool Direction = false;
    
    public void ReverseDirection()
    {
      Direction = !Direction;
    }

    /// <summary>
    /// This allow a subclass to customize the iterator 
    /// </summary>
    protected void SetItems(object collection)
    {
      _collection = (IList)collection;
    }

    public List<object> GetItems()
    {
      return _collection.Cast<object>().ToList();
    }
    
    public void AddItem(object item)
    {
      this._collection.Add(item);
    }
    
    /// <summary>
    /// This method is eventually overridden by a subclass which uses 
    /// specific logic for the set at hand
    /// </summary>
    /// <returns></returns>
    public override IEnumerator GetEnumerator()
    {
      return new OrderIterator(this, Direction);
    }
  }
}
