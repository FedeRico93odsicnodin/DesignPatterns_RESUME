﻿using System;
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
    /// Impostazione dei valori per la descrizione e per il nome per il design pattern corrente 
    /// in base all'individuazione di pagine extra viene eventualmente eseguito il display dei buttons di pagina 
    /// </summary>
    /// <param name="ViewParams"></param>
    internal ShowDescription_Page(DesPatternView ViewParams) : base(ViewParams)
    {
      // impostazione attributi principali per ViewParams e refresh view
      ViewParams.Buttons_ColorScheme = ViewConsoleConstants.BUTTON_DESCR_COLORSCHEME;
      ViewParams.Title_ColorScheme = ViewConsoleConstants.TITLE_DESCR_COLORSCHEME;
      ViewParams.Txt_ColorScheme = ViewConsoleConstants.TEXT_DESCR_COLORSCHEME;
      ViewParams.Win_ColorScheme = ViewConsoleConstants.WIN_DESCR_COLORSCHEME;
      // impostazione del page type per i parametri che sono ancora stati letti come default 
      ViewParams.PageType = Constants.PAGE_TYPE.DESCRIPTION;
      base.viewBagBase = ViewParams;
      // re impostazione dei valori per la screen 
      ResetPage();
      // impostazione del titolo + descrizione per il design pattern corrente
      base.SetTitleLabel(ViewParams.DesignPatternName);
      base.SetDescriptionText(ViewParams.DesignPatternDescription);
      // impostazione buttons avanti e indietro per il contesto corrente 
      base.Btn_Next_Activation(ViewParams.HasNextPage);
      base.Btn_Prev_Activation(ViewParams.HasPrevPage);
      // eventuale attivazione del button di demo (se mi trovo all'ultima pagina)
      base.Btn_Demo_Activation(ViewParams.HasDemoPage);
      // eventuale attivazione del button di esempio (se mi trovo sull'ultima pagina)
      base.Btn_Example_Activation(ViewParams.HasExamplePage);
      // impostazione dei parametri per riconoscere la pagina velocemente 
      base.DesignPatternID = ViewParams.Design_PatternID;
      base.PageType = Constants.PAGE_TYPE.DESCRIPTION;
      base.PageContextEnum = ViewParams.DesignPatternContextEnum;
    }


    
  }
}
