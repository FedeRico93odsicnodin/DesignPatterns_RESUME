using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Model.ViewModel
{
  /// <summary>
  /// Qui inserisco: id e nome della tipologia per il design pattern che voglio passare alla tab del view
  /// + un dizionario di tutti i design pattern collegati nel quale sono riportati il nome e l'ID principale con cui andare allo specifico
  /// design pattern corrente
  /// </summary>
  internal class PatterTypesView
  {
    internal string DesignTypeName { get; set; }

    internal string DesignTypeID { get; set; }

    internal string DesignTypeDescription { get; set; }

    internal Dictionary<int, string> DesignPatternList { get; set; }
  }
}
