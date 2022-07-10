using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Model
{
  public class DesignPatterns_Examples
  {
    public int ID { get; set; }
    
    public string RelativePath_Example { get; set; }

    public string Name_Example { get; set; }

    public bool IsWrong { get; set; }

    /// <summary>
    /// Scomposizione della stringa relativa alle linee di esempio che devono essere marcate in un certo modo 
    /// </summary>
    public List<int[]> MarkedLines { get; set; }
  }
}
