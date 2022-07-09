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
  /// Pagina per la visualizzazione dell'esempio legato al design pattern attualmente in iterazione 
  /// </summary>
  internal class ShowExample_Page : GeneralPage
  {
    internal ShowExample_Page(DesPatternView ViewParams) : base(ViewParams)
    {
      // impostazione attributi principali per ViewParams e refresh view
      ViewParams.Buttons_ColorScheme = ViewConsoleConstants.BUTTON_EXAMPLE_COLORSCHEME;
      ViewParams.Title_ColorScheme = ViewConsoleConstants.TITLE_EXAMPLE_COLORSCHEME;
      ViewParams.Txt_ColorScheme = ViewConsoleConstants.TEXT_EXAMPLE_COLORSCHEME;
      ViewParams.Win_ColorScheme = ViewConsoleConstants.WIN_EXAMPLE_COLORSCHEME;
      // impostazione del page type per i parametri che sono ancora stati letti come default 
      ViewParams.PageType = Constants.PAGE_TYPE.EXAMPLE;
      base.viewBagBase = ViewParams;
      // reimpostazione dei valori per la screen 
      ResetPage();
      // impostazione del titolo + descrizione per il design pattern corrente
      base.SetTitleLabel(ViewParams.DesignPatternName);
      base.SetLabelDescriptionVisibility(true);
      string codeToShow = ServiceLocator.GetContextSelectorService.GetPageCode_TEST();
      base.SetLabelDescriptionExample(ViewParams.DesignPatternDescription);
      base.SetDescriptionText(
        codeToShow);
      // impostazione buttons avanti e indietro per il contesto corrente 
      base.Btn_Next_Activation(ViewParams.HasNextPage);
      base.Btn_Prev_Activation(ViewParams.HasPrevPage);
      // eventuale attivazione del button di demo (se mi trovo all'ultima pagina)
      base.Btn_Demo_Activation(ViewParams.HasDemoPage);
      // impostazione eventuale contesto successivo di descrizioni 
      Btn_ForwardDescr_Activation(ViewParams.ForwardDescriptionPage);
      // impostazione dei parametri per riconoscere la pagina velocemente 
      base.DesignPatternID = ViewParams.Design_PatternID;
      base.PageType = Constants.PAGE_TYPE.EXAMPLE;
      base.PageContextEnum = ViewParams.DesignPatternContextEnum;
      
    }
  }
}
