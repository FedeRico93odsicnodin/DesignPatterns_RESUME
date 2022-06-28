using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Model
{
  /// <summary>
  /// Descrizione per il design pattern attuale 
  /// </summary>
  public class DesignPatternDescription
  {
    public int ID { get; set; }

    public string Description { get; set; }

    public int IDPattern { get; set; }

    public int ContextEnum { get; set; }
  }
}
