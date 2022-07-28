using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Behavioural.Memento
{
  public class Memento
  {
    private string _article;

    public Memento(string articleSave)
    {
      _article = articleSave;
    }

    public string GetSavedArticle()
    {
      return _article;
    }
  }
}
