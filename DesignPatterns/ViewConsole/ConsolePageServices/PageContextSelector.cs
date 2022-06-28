using DesignPatterns.Model;
using DesignPatterns.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DesignPatterns.Utils.Constants;

namespace DesignPatterns.ViewConsole.ConsolePageServices
{
  /// <summary>
  /// Decisione della specializzazione di pagina in base alla descrizione per il design
  /// pattern che viene prelevata + ritorno della pagina corrente in base al contesto selezionato 
  /// </summary>
  internal class PageContextSelector
  {
    internal void PreparePageCurrDescription(DesignPatternDescription pageDescription)
    {
      // inizializzazione lista di pagine nel caso siano a empty 
      if (MemLists.AllPagesViewConsole == null)
        MemLists.AllPagesViewConsole = new List<GeneralPage>();

      GeneralPage currPage = null;

      // classificazione della diversa specializzazione di pagina in base all'ID per l'action type
      switch(pageDescription.IDActionType)
      {
        // pagina di descrizione 
        case 1:
          {
            // inizializzazione per la pagina di descrizione corrente
            currPage = new ShowDescription_Page(pageDescription);
            break;
          }
        // pagina di esempio 
        case 2:
          {
            // inizializzazione per la pagina di codice corrente
            currPage = new ShowCode_Page(pageDescription);
            break;
          }
        // pagina di demo 
        case 3:
          {
            // inizializzazione per la pagina di demo corrente
            currPage = new ShowExample_Page(pageDescription);
            break;
          }
      }

      // aggiunta istanza di pagina a tutte le pagine disponibili solo se ne ho trovato una specializzazione
      if(currPage != null)
        MemLists.AllPagesViewConsole.Add(currPage);
    }


    /// <summary>
    /// Metodo per il recupero di una singola pagina per la descrizione di un tipo
    /// particolare di pattern
    /// </summary>
    /// <param name="pageType"></param>
    /// <param name="EntityID"></param>
    /// <returns></returns>
    internal GeneralPage GetPage(PAGE_TYPE pageType, int EntityID)
    {
      // questo metodo va bene solo per il recupero di una eventuale pagina relativa alla descrizione 
      // per un particolare tipo di design pattern
      if (pageType != PAGE_TYPE.DESIGNTYPE)
        return null;

      // TODO: return oggetto relativo alla pagina di descrizione per ila tipologia di design pattern
      return null;
    }
  }


}
