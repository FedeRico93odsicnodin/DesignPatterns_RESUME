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

    private static ColorScheme TITLE_DESCR_COLORSCHEME { get { return Colors.Dialog; } }

    private static ColorScheme TEXT_DESCR_COLORSCHEME { get { return Colors.Menu; } }

    private static ColorScheme BUTTON_DESCR_COLORSCHEME { get { return Colors.Dialog; } }

    private static ColorScheme WIN_DESCR_COLORSCHEME { get { return Colors.Base; } }

    private static string TITLE_DEFAULT = "IN PROGRESS TITLE";

    private static string TEXT_DESCRIPTION_DEFAULT = "THIS PAGE IN IS PROGRESS";

    private static string BTN_TXT_DEFAULT = "IN PROGRESS";

    internal static DesPatternView GetDefaultViewBagValues()
    {
      return new DesPatternView()
      {
        Win_ColorScheme = WIN_DESCR_COLORSCHEME,
        Buttons_ColorScheme = BUTTON_DESCR_COLORSCHEME,
        Title_ColorScheme = TITLE_DESCR_COLORSCHEME,
        Txt_ColorScheme = TEXT_DESCR_COLORSCHEME,
        DesignPatternName = TEXT_DESCRIPTION_DEFAULT,
        PageType = Utils.Constants.PAGE_TYPE.DEFAULT,
        DesignPatternDescription = TEXT_DESCRIPTION_DEFAULT
      };
    }
    
  }
}
