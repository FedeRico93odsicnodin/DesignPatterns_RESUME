using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Behavioural.Iterator
{
  /// <summary>
  /// Concrete implementation of the iterator 
  /// </summary>
  public class OrderIterator : Iterator
  {
    private Collection _collection;

    private int _position = -1;

    private bool _reverse = false;


    public OrderIterator(Collection newCollection, bool reverse = false)
    {
      this._collection = newCollection;
      this._reverse = reverse;

      if(reverse)
        this._position = _collection.GetItems().Count;
    }


    public override object Current()
    {
      return this._collection.GetItems()[_position];
    }

    public override int Key()
    {
      return this._position;
    }

    public override bool MoveNext()
    {
      // update of the index for the current position 
      int updatedPosition = this._position + (this._reverse ? -1 : 1);

      // range in the set: for the normal order or the reverse one 
      if (updatedPosition >= 0 && updatedPosition < this._collection.GetItems().Count)
      {
        this._position = updatedPosition;
        return true;
      }
      else
        return false; // out of range 
    }

    /// <summary>
    /// Reset to the starting index for the collection 
    /// </summary>
    public override void Reset()
    {
      this._position = this._reverse ? this._collection.GetItems().Count - 1 : 0;
    }
  }
}
