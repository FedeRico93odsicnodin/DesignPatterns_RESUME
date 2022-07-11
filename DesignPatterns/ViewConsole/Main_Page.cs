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
    /// Mappa i diversi design patterns in base al button per il contesto corrente 
    /// </summary>
    private Dictionary<int, Button> _desPatternsMapperSelector;


    /// <summary>
    /// Impostazione delle proprieta per la pagina principale: la lista delle diverse tipologie per i design patterns e le loro descrizioni
    /// con la lista dei diversi design patterns disponibili
    /// </summary>
    /// <param name="ViewParams"></param>
    internal Main_Page(DesPatternView ViewParams) : base(ViewParams)
    {
      // impostazione parametri principali di view
      ViewParams.Tab_ColorScheme = ViewConsoleConstants.TAB_MAIN_COLORSCHEME;
      ViewParams.Buttons_ColorScheme = ViewConsoleConstants.BUTTON_MAIN_COLORSCHEME;
      // impostazione della pagina come una pagina di main 
      base.PageType = Utils.Constants.PAGE_TYPE.MAIN;
      // impostazione del nuovo valore per il viewbag corrente 
      base.viewBagBase = ViewParams;
      // inizializzazione del dizionario di mappatura per i diversi design patterns nel contesto corrente 
      _desPatternsMapperSelector = new Dictionary<int, Button>();
      // impostazione dei parametri principali
      base.InitMainTabs(ViewParams.Tab_ColorScheme);
      // disattivazione dei buttons relativi alla visualizzazione dei diversi comandi 
      base.Btn_Demo_Activation(false);
      base.Btn_Example_Activation(false);
      base.Btn_ForwardDescr_Activation(false);
      base.Btn_Next_Activation(false);
      base.Btn_Prev_Activation(false);
      base.Btn_WrongExample_Activation(false);
      base.Btn_Main_Activation(false);
      // creazione delle diverse tabs
      CreateDesignTypesTabs();
    }


    /// <summary>
    /// Creazione dei tabs specifici per i design types correnti e che vengono di volta in volta 
    /// passati alla visualizzazione tab principale inizializzata 
    /// </summary>
    private void CreateDesignTypesTabs()
    {
      // iterazione delle diverse tipologie con inizializzazione per il tab corrente 
      foreach (PatternTypesView currType in viewBagBase.DesignTypesList)
      {
        base.AddTab(GetTabViewFromTypeSpecs(currType));
      }
    }


    /// <summary>
    /// Creazione del nuovo tab a partire dalle specifiche relative alla tipologia per il design type corrente 
    /// </summary>
    /// <param name="currPatternTypeSpecs"></param>
    /// <returns></returns>
    private TabView.Tab GetTabViewFromTypeSpecs(PatternTypesView currPatternTypeSpecs)
    {
      TabView.Tab currTabView = new TabView.Tab();
      currTabView.Text = currPatternTypeSpecs.DesignTypeName; // impostazione per il nome per la tipologia corrente 
      currTabView.View = DesTypeWinCreation(currPatternTypeSpecs.DesignTypeDescription, currPatternTypeSpecs.DesignPatternList
        );
      return currTabView;
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="txtType"></param>
    /// <param name="currDesPatternsList"></param>
    /// <returns></returns>
    private View DesTypeWinCreation(string txtType, Dictionary<int, string> currDesPatternsList)
    {
      View desPatternView = new View()
      {
        Width = Dim.Fill() - 4,
        Height = Dim.Fill() - 4,
        X = 2,
        Y = 2,
        ColorScheme = base.viewBagBase.Win_ColorScheme,
        Visible = true,
        Text = txtType,
      };
      View buttonsView = new View()
      {
        Width = Dim.Fill() - 4,
        Height = Dim.Fill() - 4,
        Visible = true,
      };
      // creazione dei diversi buttons e inserimento nel dizionario per poter effettuare la corrispondenza
      int startingX = 3;
      int startingY = txtType.Split('\n').Length + 1;
      foreach (KeyValuePair<int, string> designPatternNameID in currDesPatternsList)
      {
        Button desPatternBtn = new Button()
        {
          Text = designPatternNameID.Value,
          X = startingX,
          Y = startingY,
          ColorScheme = viewBagBase.Buttons_ColorScheme
        };
        startingX = startingX + designPatternNameID.Value.Length + 5;
        desPatternBtn.Clicked += () => DesPatternClickedAction(desPatternBtn);
        buttonsView.Add(desPatternBtn);
        _desPatternsMapperSelector.Add(designPatternNameID.Key, desPatternBtn);
      }
      desPatternView.Add(buttonsView);
      return desPatternView;

    }


    #region FUNCTION BUTTONS DESIGN PATTERNS CLICKED

    /// <summary>
    /// Passo alla visualizzazione per il design pattern corrente 
    /// </summary>
    /// <param name="desPatternButton"></param>
    private void DesPatternClickedAction(Button desPatternButton)
    {
      // ricerco l'ID per il design pattern corrente 
      int designPatternID = _desPatternsMapperSelector.Where(x => x.Value == desPatternButton).FirstOrDefault().Key;
      // richiamo del metodo relativo alla visualizzazione delle pagine per il design pattern selezionato 
      ServiceLocator.GetContextSelectorService.ChangePageContext_DesPatternDescription(designPatternID);
    }
    
    #endregion
  }
}
