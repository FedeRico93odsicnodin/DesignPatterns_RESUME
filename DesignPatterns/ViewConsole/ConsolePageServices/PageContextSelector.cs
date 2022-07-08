using DesignPatterns.Model;
using DesignPatterns.Model.ViewModel;
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
      // inizializzazione lista di pagine nel caso siano a empty 
      if (MemLists.AllPagesViewConsole == null)
        MemLists.AllPagesViewConsole = new List<GeneralPage>();
      // creazione del viewbag per il contesto di main 
      Main_Page currMainPage = new Main_Page(GetMainParameters());
      // inserimento della pagina all'interno del contesto 
      MemLists.AllPagesViewConsole.Add(currMainPage);
    }


    /// <summary>
    /// Recupero di tutti i parametri di cui eseguire il display nella view corrente 
    /// </summary>
    /// <returns></returns>
    private DesPatternView GetMainParameters()
    {
      DesPatternView currMainParameters = new DesPatternView();
      // iterazione per ongi tipologia di design pattern ritrovata 
      List<PatternTypesView> currPatTypesView = new List<PatternTypesView>();
      foreach(DesignType currDesType in MemLists.DesignPatterns_Types)
      {
        PatternTypesView typeView = new PatternTypesView();
        typeView.DesignTypeID = currDesType.ID;
        typeView.DesignTypeName = currDesType.Name;
        typeView.DesignTypeDescription = MemLists.DesignTypesDescriptions.Where(x => x.IDType == currDesType.ID).FirstOrDefault().Description;
        typeView.DesignPatternList =
          MemLists.DesignPatterns.Where(x => x.DesignType_ID == currDesType.ID).ToDictionary(x => x.ID, x => x.Name);
        currPatTypesView.Add(typeView);
      }
      currMainParameters.DesignTypesList = currPatTypesView;
      return currMainParameters;
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
    /// <param name="desPatDescription"></param>
    internal void PrepareDesignPatternPageCurrDescription(DesignPatternDescription desPatDescription)
    {
      // inizializzazione lista di pagine nel caso siano a empty 
      if (MemLists.AllPagesViewConsole == null)
        MemLists.AllPagesViewConsole = new List<GeneralPage>();

      GeneralPage currPage = new GeneralPage();

      // classificazione della diversa specializzazione di pagina in base all'ID per l'action type
      switch(desPatDescription.ID_VisualActionType)
      {
        // pagina di descrizione 
        case 1:
          {
            // inizializzazione per la pagina di descrizione corrente
            currPage = new ShowDescription_Page(PrepareViewParams(desPatDescription, PAGE_TYPE.DESCRIPTION));
            break;
          }
        // pagina di esempio 
        case 2:
          {
            // inizializzazione per la pagina di codice corrente
            currPage = new ShowCode_Page(PrepareViewParams(desPatDescription, PAGE_TYPE.EXAMPLE));
            break;
          }
        // pagina di demo 
        case 3:
          {
            // inizializzazione per la pagina di demo corrente
            currPage = new ShowExample_Page(PrepareViewParams(desPatDescription, PAGE_TYPE.DEMO));
            break;
          }
      }

      // aggiunta istanza di pagina a tutte le pagine disponibili solo se ne ho trovato una specializzazione
      if(currPage != null)
        MemLists.AllPagesViewConsole.Add(currPage);
    }


    /// <summary>
    /// Permette di preparare i parametri per l'interfaccia provenienti dal contesto di recupero descrizioni dal database
    /// </summary>
    /// <param name="desPatDescription"></param>
    /// <param name="identifiedType"></param>
    /// <returns></returns>
    private DesPatternView PrepareViewParams(DesignPatternDescription desPatDescription, PAGE_TYPE identifiedType)
    {
      // parto dal caso di default e riempo con i parametri che mi occorrono
      DesPatternView currViewBagConsole = ViewConsoleConstants.GetDefaultViewBagValues();
      currViewBagConsole.DesignPatternDescription = desPatDescription.Description;
      currViewBagConsole.DesignPatternDescriptionID = desPatDescription.ID;
      currViewBagConsole.Design_PatternID = desPatDescription.ID_DesignPattern;
      // ricerca del nome per il design pattern tra gli elementi di partenza 
      currViewBagConsole.DesignPatternName =
        (MemLists.DesignPatterns.Where(x => x.ID == desPatDescription.ID_DesignPattern).FirstOrDefault() != null) ?
        MemLists.DesignPatterns.Where(x => x.ID == desPatDescription.ID_DesignPattern).FirstOrDefault().Name : ViewConsoleConstants.NOTFOUND_DESCRIPTION;
      // verifica di presenza pagine precedente / successiva
      if (CheckNextPagePresence(identifiedType, desPatDescription.ID, desPatDescription.ID, desPatDescription.ID_DesignPattern))
        currViewBagConsole.HasNextPage = true;
      if (CheckPrevPagePresence(identifiedType, desPatDescription.ID, desPatDescription.ID, desPatDescription.ID_DesignPattern))
        currViewBagConsole.HasPrevPage = true;
      // impostazione per l'eventuale pagina di esempio da mostrare per il contesto corrente 
      currViewBagConsole.HasExamplePage = VerifyExamplePagePresence(identifiedType, desPatDescription.ID, desPatDescription.ID, desPatDescription.ID_DesignPattern);
      return currViewBagConsole;
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
      bool verifyNextPage = (MemLists.DesignPatterns_Descriptions.Where(
        x => x.ID_VisualActionType == (int)pageType &&
        x.ID_DesignPattern == EntityPatternID &&
        (x.ID > EntityID || x.ID_VisualActionType > ContextID)
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
      bool verifyPrevPage = (MemLists.DesignPatterns_Descriptions.Where(
        x => x.ID_VisualActionType == (int)pageType &&
        x.ID_DesignPattern == EntityPatternID &&
        (x.ID < EntityID || x.ID_VisualActionType < ContextID)
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
      return (MemLists.DesignPatterns_Descriptions.Where(
        x => x.ID_VisualActionType == (int)PAGE_TYPE.EXAMPLE &&
        x.ID_DesignPattern == EntityPatternID
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


    #region SWITCH NEL CONTESTO GRAFICO 

    /// <summary>
    /// Recupero della prima pagina di descrizione per il design pattern corrente: questo si usa quando si
    /// arriva per la prima volta alla definizione per questo design pattern 
    /// </summary>
    /// <param name="idDesPattern"></param>
    internal void ChangePageContext_DesPatternDescription(int idDesPattern)
    {
      // TODO: implementazione della dinamica di selezione della pagina 
    }


    /// <summary>
    /// Chiamato ogni volta che si torna alla pagina principale o si apre per la prima volta 
    /// </summary>
    internal void LoadMainPage()
    {
      ViewConsoleConstants.ApplicationTop.RemoveAll(); // rimozione degli elementi dal contesto principale 
      // recupero della pagina principale dall'insieme di tutte le pagine disponibili
      Main_Page currMainPage = (Main_Page)MemLists.AllPagesViewConsole.Where(
        x => x.PageType == PAGE_TYPE.MAIN
        ).FirstOrDefault();
      // inserimento del contesto per la pagina principale 
      ViewConsoleConstants.ApplicationTop.Add(
        currMainPage.TopMenu, currMainPage.WindowTitle, currMainPage.MainWindow
        );
    }


    #endregion

  }


}
