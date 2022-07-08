using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatterns.Model.ViewModel;
using DesignPatterns.ViewConsole.ConsolePageServices;
using Terminal.Gui;

namespace DesignPatterns.ViewConsole
{
  internal class Main_Page : GeneralPage
  {
    /// <summary>
    /// Impostazione delle proprieta per la pagina principale: la lista delle diverse tipologie per i design patterns e le loro descrizioni
    /// con la lista dei diversi design patterns disponibili
    /// </summary>
    /// <param name="ViewParams"></param>
    internal Main_Page(DesPatternView ViewParams) : base(ViewParams)
    {
      // impostazione del nuovo valore per il viewbag corrente 
      base.viewBagBase = ViewParams;
      // impostazione parametri principali di view
      ViewParams.Tab_ColorScheme = ViewConsoleConstants.TAB_MAIN_COLORSCHEME;
      // impostazione dei parametri principali
      base.InitMainTabs(ViewParams.Tab_ColorScheme);
    }


    /// <summary>
    /// Creazione dei tabs specifici per i design types correnti e che vengono di volta in volta 
    /// passati alla visualizzazione tab principale inizializzata 
    /// </summary>
    private void CreateDesignTypesTabs()
    {
      // iterazione delle diverse tipologie con inizializzazione per il tab corrente 
      foreach(PatterTypesView currType in viewBagBase.DesignTypesList)
      {
        base.AddTab(GetTabViewFromTypeSpecs(currType));
      }
    }


    /// <summary>
    /// Creazione del nuovo tab a partire dalle specifiche relative alla tipologia per il design type corrente 
    /// </summary>
    /// <param name="currPatternTypeSpecs"></param>
    /// <returns></returns>
    private TabView.Tab GetTabViewFromTypeSpecs(PatterTypesView currPatternTypeSpecs)
    {
      TabView.Tab currTabView = new TabView.Tab();
      currTabView.Text = currPatternTypeSpecs.DesignTypeName; // impostazione per il nome per la tipologia corrente 
      // TODO: implementazione con la creazione della view per la tipologia corrente 
      return currTabView;
    }
  }
}
