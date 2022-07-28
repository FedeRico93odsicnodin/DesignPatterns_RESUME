using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Behavioural.Memento
{
  public class Originator
  {
    private string _article;

    /// <summary>
    /// For displaying the article just saved
    /// </summary>
    public string GetArticle { get { return _article; } }

    /// <summary>
    /// Message to be displayed each time 
    /// </summary>
    public string Message { get; set; }

    public void Set(string newArticle)
    {
      Message = "From Originator: Current Version of the Article [" + newArticle + "]";
      _article = newArticle;
    }
    

    public Memento StoreInMemento()
    {
      Message = "From Originator: Saving to Memento";
      return new Memento(_article);
    }

    public string RestoreFromMemento(Memento memento)
    {
      _article = memento.GetSavedArticle();

      Message = "From Originator: Previous Saved in Memento [" + _article + "]";

      return _article;
    }
  }
}
