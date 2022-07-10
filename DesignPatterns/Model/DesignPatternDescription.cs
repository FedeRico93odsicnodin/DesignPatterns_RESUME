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
    
    public int ID_DesignPattern { get; set; }

    public string Description { get; set; }
    
    public bool HasCode { get; set; }

    public bool HasWrongCode { get; set; }

    public int ID_VisualActionType { get; set; }

    public int ID_Vis { get; set; }

    public int ExampleID { get; set; }

    public int WrongID { get; set; }

  }
}
