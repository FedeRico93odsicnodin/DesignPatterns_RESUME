using DesignPatterns.Model;
using DesignPatterns.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.ViewConsole.ConsolePageServices
{
  /// <summary>
  /// Servizio per il print in console dei diversi esempi a disposizione 
  /// NB: questo servizio deve essere distinto tra il print relativo alla semplice console e quella che utilizza Gui
  /// </summary>
  internal class PrintExampleService
  {
    /// <summary>
    /// Permette di stabilire se l'esempio corrente è presente all'interno della base dati di partenza 
    /// in questo caso sto verificando per la presenza di un esempio sbagliato da mostrare a video
    /// </summary>
    /// <param name="exampleID"></param>
    /// <param name="classRelativePath"></param>
    /// <param name="className"></param>
    /// <param name="foundExample"></param>
    /// <returns></returns>
    internal bool CheckWrongExamplePresence(
      int exampleID, 
      string classRelativePath, 
      string className,
      out DesignPatterns_Examples foundExample)
    {
      foundExample = MemLists.DesignPatternsExamples.Where(x => x.ID == exampleID &&
      x.RelativePath_Example == classRelativePath && x.Name_Example == className).FirstOrDefault();
      if (foundExample == null)
        return false;
      return true;
    }


    /// <summary>
    /// Permette il print dell'esempio sulla normalissima console 
    /// </summary>
    /// <param name="foundExample"></param>
    internal void PrintWrongExample_CONSOLE(DesignPatterns_Examples foundExample)
    {
      // TODO: implementazione del print example su console in base alla colorazione attribuita (attribuirla nelle costanti di view)
    }


    /// <summary>
    /// Permette di disegnare il messaggio relativo al non aver trovato correttamente il file di esempio sbagliato per la pagina corrente 
    /// </summary>
    internal void PrintWrongExample_NOTFOUNDMsg()
    {
      // TODO: implementazione con il messaggio standard 
    }
  }
}
