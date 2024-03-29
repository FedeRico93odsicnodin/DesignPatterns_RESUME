﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatterns.Model;
using DesignPatterns.Model.ViewModel;

namespace DesignPatterns.ViewConsole
{
  /// <summary>
  /// Pagina per la visualizzazione del codice sotto una particolare descrizione per il design pattern particolare 
  /// </summary>
  internal class ShowCode_Page : GeneralPage
  {
    internal ShowCode_Page(DesPatternView ViewParams) : base(ViewParams)
    {
    }
  }
}
