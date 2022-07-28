using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Behavioural.Memento
{
  public class Caretaker
  {
    ArrayList _saveArticles = new ArrayList();

    public void AddMemento(Memento m) { _saveArticles.Add(m); }

    public Memento GetMemento(int index) { return (Memento)_saveArticles[index]; } 

    public void SetMemento(int index, Memento modified)
    {
      _saveArticles[index] = modified;
    }

    public int GetLastIndex() { return (_saveArticles.Count - 1); }
  }
}
