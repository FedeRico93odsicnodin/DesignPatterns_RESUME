using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatterns.Model;
using DesignPatterns.Model.ViewModel;
using DesignPatterns.Utils;
using DesignPatterns.ViewConsole.ConsolePageServices;

namespace DesignPatterns.ViewConsole
{


  /// <summary>
  /// Pagina per la visualizzazione particolare del design pattern in considerazione 
  /// </summary>
  internal class ShowDescription_Page : GeneralPage
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
    internal ShowDescription_Page(
      DesignPatternDescription designPatternDescription)
    {
      _designPatternDescription = designPatternDescription;
    }


    /// <summary>
    /// Impostazione oggetto di descrizione in base alle specifiche attuali 
    /// </summary>
    /// <returns></returns>
    protected override DesPatternView DefineParamValues()
    {
      // istanza finestra con tutti i parametri utili alla descrizione corrente
      DesPatternView desPatternScheme = new DesPatternView()
      {
        // parametri di finestra grafici 
        Title_ColorScheme = ViewConsoleConstants.TITLE_DESCR_COLORSCHEME,
        Txt_ColorScheme = ViewConsoleConstants.TEXT_DESCR_COLORSCHEME,
        Buttons_ColorScheme = ViewConsoleConstants.BUTTON_DESCR_COLORSCHEME,
        Win_ColorScheme = ViewConsoleConstants.WIN_DESCR_COLORSCHEME,

        // parametri relativi al design pattern corrente
        DesignPatternName = MemLists.DesignPatterns.Where(x => x.ID == _designPatternDescription.ID_DesignPattern).FirstOrDefault().Name,
        Design_PatternID = _designPatternDescription.ID_DesignPattern,
        DesignPatternDescription = _designPatternDescription.Description,
        DesignPatternDescriptionID = _designPatternDescription.ID,
        PageType = Constants.PAGE_TYPE.DESCRIPTION,
        DesignPatternContextEnum = (_designPatternDescription.ID_Vis == 0) ? _designPatternDescription.ID : _designPatternDescription.ID_Vis
      };

      return desPatternScheme;
    }
  }
}
