using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatterns.Model;
using DesignPatterns.Model.ViewModel;

namespace DesignPatterns.ViewConsole
{



  /// <summary>
  /// Pagina per la visualizzazione dell'esempio legato al design pattern attualmente in iterazione 
  /// </summary>
  internal class ShowExample_Page : GeneralPage
  {

    /// <summary>
    /// descrizione per il design pattern e la pagina attuale 
    /// </summary>
    DesignPatternDescription _designPatternDescription;


    /// <summary>
    /// Impostazione per il design pattern e per la sua descrizione attuali
    /// </summary>
    /// <param name="designPattern"></param>
    /// <param name="designPatternDescription"></param>
    internal ShowExample_Page(
      DesignPatternDescription designPatternDescription)
    {
      _designPatternDescription = designPatternDescription;
    }

    protected override DesPatternView DefineParamValues()
    {
      throw new NotImplementedException();
    }
  }
}
