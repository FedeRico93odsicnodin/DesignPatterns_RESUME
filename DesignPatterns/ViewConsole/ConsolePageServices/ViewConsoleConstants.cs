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
    #region PARAMETRI CONSTANTI PER LA PAGINA DI VISUALIZZAZIONE DELLE DESCRIZIONI

    internal static ColorScheme TITLE_DESCR_COLORSCHEME { get { return Colors.Dialog; } }

    internal static ColorScheme TEXT_DESCR_COLORSCHEME { get { return Colors.Menu; } }

    internal static ColorScheme BUTTON_DESCR_COLORSCHEME { get { return Colors.Dialog; } }

    internal static ColorScheme WIN_DESCR_COLORSCHEME { get { return Colors.Base; } }

    #endregion
  }
}
