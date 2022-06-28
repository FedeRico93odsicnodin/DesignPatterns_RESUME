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
    #region COSTRUZIONE DELLE PAGINE DI CONTESTO APPLICAZIONE CORRENTE

    /// <summary>
    /// Preparazione della pagina principale di contesto con gli elementi statici di contesto per il caso corrente
    /// </summary>
    internal void PrepareMainPageContext()
    {
      // TODO: implementazione metodo per la creazione della pagina principale di contesto per il caso corrente
    }


    /// <summary>
    /// Creazione della pagina di contesto per la descrizione di una tipologia particolare di design pattern
    /// </summary>
    /// <param name="designTypeDescription"></param>
    internal void PrepareDesignTypePageCurrDescription(DesignTypeDescription designTypeDescription)
    {
      // TODO: implementazione della modalità di creazione per la pagina di design type description
    }


    /// <summary>
    /// Creazione di una pagina di contesto relativa al design pattern corrente in base all'elemento recuperato
    /// dalla base dati corrente
    /// </summary>
    /// <param name="pageDescription"></param>
    internal void PrepareDesignPatternPageCurrDescription(DesignPatternDescription pageDescription)
    {
      // inizializzazione lista di pagine nel caso siano a empty 
      if (MemLists.AllPagesViewConsole == null)
        MemLists.AllPagesViewConsole = new List<GeneralPage>();

      GeneralPage currPage = null;

      // classificazione della diversa specializzazione di pagina in base all'ID per l'action type
      switch(pageDescription.ID_VisualActionType)
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

    #endregion


    #region RECUPERO DELLA PAGINA CORRENTE

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

      // ritorno la pagina relativa al display descrizione per la tipologia di design pattern selezionata
      GeneralPage currContentPage = MemLists.AllPagesViewConsole.Where(
        x => x.DesignTypeID == EntityID &&
        x.PageType == pageType
        ).FirstOrDefault();

      return currContentPage;
    }


    /// <summary>
    /// Ritorno la pagina attuale in base alla enumerazione eseguita per il design pattern attuale 
    /// per la descrizione del design pattern o per l'identificativo di contesto con il riferimento alla tipologia attuale 
    /// per la descrizione (quindi una pagina di demo di descrizione o di esempio)
    /// </summary>
    /// <param name="pageType"></param>
    /// <param name="EntityID"></param>
    /// <param name="ContextID"></param>
    /// <param name="EntityPatternID"></param>
    /// <returns></returns>
    internal GeneralPage GetPage(PAGE_TYPE pageType, int EntityID, int ContextID, int EntityPatternID)
    {
      // provo a recuperare la pagina con l'enumerazione "piu fiscale"
      GeneralPage currContentPage = MemLists.AllPagesViewConsole.Where(
        x => x.PageType == pageType &&
        x.DescriptionPatternID == EntityID &&
        x.PageContextEnum == ContextID &&
        x.DesignPatternID == EntityPatternID
        ).FirstOrDefault();
      // se non trovo nessun risultato allora provo con una enumerazione diversa
      if(currContentPage == null)
      {
        currContentPage = MemLists.AllPagesViewConsole.Where(
          x => x.PageType == pageType &&
          x.DescriptionPatternID == EntityID &&
          x.PageContextEnum == EntityID && // da costruzione l'ID per il contesto deve essere uguale a quello della entità
          x.DesignPatternID == EntityPatternID
          ).FirstOrDefault();
      }
      // in ogni caso ritorno la pagina corrente (da verificare dopo che non sia nulla)
      return currContentPage;
    }

    #endregion


    #region VERIFICA DI PRESENZA PAGINA SUCCESSIVA / PRECEDENTE 

    /// <summary>
    /// Verifica della presenza di una pagina successiva per lo stesso contesto
    /// </summary>
    /// <param name="pageType"></param>
    /// <param name="EntityID"></param>
    /// <param name="ContextID"></param>
    /// <param name="EntityPatternID"></param>
    /// <returns></returns>
    internal bool CheckNextPagePresence(PAGE_TYPE pageType, int EntityID, int ContextID, int EntityPatternID)
    {
      // verifica di presenza di una pagina che abbia entity ID o contesto di pagina maggiori
      bool verifyNextPage = (MemLists.AllPagesViewConsole.Where(
        x => x.PageType == pageType &&
        x.DesignPatternID == EntityPatternID &&
        (x.DescriptionPatternID > EntityID || x.PageContextEnum > ContextID)
        ).Count() > 0);

      return verifyNextPage;
    }


    /// <summary>
    /// Verifica della presenza per la pagina precedente
    /// </summary>
    /// <param name="pageType"></param>
    /// <param name="EntityID"></param>
    /// <param name="ContextID"></param>
    /// <param name="EntityPatternID"></param>
    /// <returns></returns>
    internal bool CheckPrevPagePresence(PAGE_TYPE pageType, int EntityID, int ContextID, int EntityPatternID)
    {
      // verifica di presenza di una pagina che abbia entity ID o contesto di pagina minori
      bool verifyPrevPage = (MemLists.AllPagesViewConsole.Where(
        x => x.PageType == pageType &&
        x.DesignPatternID == EntityPatternID &&
        (x.DescriptionPatternID < EntityID || x.PageContextEnum < ContextID)
        ).Count() > 0);

      return verifyPrevPage;
    }

    #endregion


    #region VERIFICATORI DI PAGINA DI ESEMPIO 

    /// <summary>
    /// Verifica della pagina di esempio dopo aver eseguito lo scroll di tutte le pagine di descrizione 
    /// per il design pattern corrente
    /// </summary>
    /// <param name="pageType"></param>
    /// <param name="EntityID"></param>
    /// <param name="ContextID"></param>
    /// <param name="EntityPatternID"></param>
    /// <returns></returns>
    internal bool VerifyExamplePagePresence(PAGE_TYPE pageType, int EntityID, int ContextID, int EntityPatternID)
    {
      // se la pagina corrente è diversa da una pagina di descrizione allora ritorno false
      if (pageType != PAGE_TYPE.DESCRIPTION)
        return false;

      // verifico se la pagina corrente è l'ultima pagina di descrizione per il design pattern corrente
      // e se è associato un esempio a questo design pattern
      if (!CheckNextPagePresence(pageType, EntityID, ContextID, EntityPatternID))
        return false;

      // ritorno per la presenza di una pagina di esempio per il design pattern corrente
      return (MemLists.AllPagesViewConsole.Where(
        x => x.PageType == PAGE_TYPE.EXAMPLE &&
        x.DesignPatternID == EntityPatternID
        ).Count() > 0);
    }


    /// <summary>
    /// Ritorno per la presenza di una pagina di DEMO per il contesto e il design pattern corrente
    /// </summary>
    /// <param name="pageType"></param>
    /// <param name="EntityID"></param>
    /// <param name="ContextID"></param>
    /// <param name="EntityPatternID"></param>
    /// <returns></returns>
    internal bool VerifyDEMOPagePresence(PAGE_TYPE pageType, int EntityID, int ContextID, int EntityPatternID)
    {
      // se la pagina corrente non è una pagina di esempio allora ritorno false
      if (pageType != PAGE_TYPE.EXAMPLE)
        return false;

      // verifico se la pagina corrente è l'ultima pagina di esempio per il design pattern corrente
      // e se è associato un demo a questo design pattern
      if (!CheckNextPagePresence(pageType, EntityID, ContextID, EntityPatternID))
        return false;

      // ritorno per la presenza di una pagina di esempio per il design pattern corrente
      return (MemLists.AllPagesViewConsole.Where(
        x => x.PageType == PAGE_TYPE.DEMO &&
        x.DesignPatternID == EntityPatternID
        ).Count() > 0);
    }

    #endregion


  }


}
