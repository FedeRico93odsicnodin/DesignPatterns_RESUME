using DesignPatterns.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;

namespace DesignPatterns.ViewConsole.ConsolePageServices
{
  /// <summary>
  /// Costanti per il progetto e per la view relativa alla console 
  /// </summary>
  internal static class ViewConsoleConstants
  {

    #region PARAMETRI STANDARD 

    private static ColorScheme TITLE_DEF_COLORSCHEME { get { return Colors.Dialog; } }

    private static ColorScheme TEXT_DEF_COLORSCHEME { get { return Colors.Menu; } }

    private static ColorScheme BUTTON_DEF_COLORSCHEME { get { return Colors.Dialog; } }

    private static ColorScheme WIN_DEF_COLORSCHEME { get { return Colors.Base; } }

    private static string TITLE_DEFAULT = "IN PROGRESS TITLE";

    private static string TEXT_DESCRIPTION_DEFAULT = "THIS PAGE IN IS PROGRESS";

    private static string BTN_TXT_DEFAULT = "IN PROGRESS";

    internal static DesPatternView GetDefaultViewBagValues()
    {
      return new DesPatternView()
      {
        Win_ColorScheme = WIN_DEF_COLORSCHEME,
        Buttons_ColorScheme = BUTTON_DEF_COLORSCHEME,
        Title_ColorScheme = TITLE_DEF_COLORSCHEME,
        Txt_ColorScheme = TEXT_DEF_COLORSCHEME,
        DesignPatternName = TEXT_DESCRIPTION_DEFAULT,
        PageType = Utils.Constants.PAGE_TYPE.DEFAULT,
        DesignPatternDescription = TEXT_DESCRIPTION_DEFAULT
      };
    }

    #endregion


    #region PARAMETRI RELATIVI ALLA PAGINA DI DESCRIZIONE 

    internal static ColorScheme TITLE_DESCR_COLORSCHEME { get { return Colors.Dialog; } }

    internal static ColorScheme TEXT_DESCR_COLORSCHEME { get { return Colors.Menu; } }

    internal static ColorScheme BUTTON_DESCR_COLORSCHEME { get { return Colors.Dialog; } }

    internal static ColorScheme WIN_DESCR_COLORSCHEME { get { return Colors.Base; } }

    #endregion


    #region PARAMETRI DESCRITTIVI PER LA PAGINA PRINCIPALE

    internal static ColorScheme TITLE_MAIN_COLORSCHEME { get { return Colors.Dialog; } }

    internal static ColorScheme TEXT_MAIN_COLORSCHEME { get { return Colors.Menu; } }

    internal static ColorScheme BUTTON_MAIN_COLORSCHEME { get { return Colors.Dialog; } }

    internal static ColorScheme WIN_MAIN_COLORSCHEME { get { return Colors.Base; } }

    internal static ColorScheme TAB_MAIN_COLORSCHEME { get { return Colors.TopLevel; } }

    #endregion

    /// <summary>
    /// Identificazione di un elemento che non è stato trovato per corrispondenza con chiave fk
    /// all'interno della base dati di partenza 
    /// </summary>
    internal static string NOTFOUND_DESCRIPTION = "NOT FOUND FK";
    
  }
}
