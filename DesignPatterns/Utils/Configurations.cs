using DesignPatterns.Model;
using DesignPatterns.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Utils
{
    public class Configurations
    {

    /// <summary>
    /// Verifica della modalità in cui il programma deve essere lanciato per il caso corrente 
    /// Le diverse proprieta e ID vengono specificate a seconda della casistica in cui il programma viene effettivamente aperto 
    /// </summary>
    /// <param name="args"></param>
    /// <param name="entityID"></param>
    /// <param name="prop1"></param>
    /// <returns></returns>
        internal Constants.PROGRAM_MODES GetProgramCurrExeType(string[] args, 
          out int entityID, 
          out string prop1,
          out string prop2)
    {
      // modo di default 
      Constants.PROGRAM_MODES currModeDefault = Constants.PROGRAM_MODES.PRESENTATION;
      // inizializzazione parametri out 
      entityID = 0;
      prop1 = String.Empty;
      prop2 = String.Empty;
      // impostazione per il caso di demo 
      if (args[0] == Constants.PROGRAM_MODES.CODE_DEMO.ToString())
        currModeDefault = Constants.PROGRAM_MODES.CODE_DEMO;
      else if (args[0] == Constants.PROGRAM_MODES.WRONG_EXAMPLE.ToString())
        currModeDefault = Constants.PROGRAM_MODES.WRONG_EXAMPLE;

      #region ATTRIBUTI EXTRA DA RECUPERARE PER IL CASO CORRENTE 

      // se mi trovo nel caso di demo devo anche valorizzare gli attributi relativi al design pattern
      if(currModeDefault == Constants.PROGRAM_MODES.CODE_DEMO)
      {
        int.TryParse(args[1], out entityID); // conversione per l'ID del design pattern attuale 
        prop1 = args[2];
      }
      // sto visualizzando un wrong example di cui devo recuperare la classe e lavorare sul display in diversi colori 
      else if(currModeDefault == Constants.PROGRAM_MODES.WRONG_EXAMPLE)
      {
        int.TryParse(args[1], out entityID); // conversione dell'ID per l'esempio corrente 
        prop1 = args[2]; // questa proprieta coincide con il relative path nel quale andare a trovare la classe corrispodente 
        prop2 = args[3]; // nome della classe corrispondente 
      }

      #endregion

      return currModeDefault;
    }



        /// <summary>
        /// Lettura delle configurazioni di progetto attuale dal file di configurazione o combinando i diversi percorsi disponibili 
        /// il parametro reduce mi dice se devo eseguire un recupero solo per le liste dei design patterns per eventualmente lavorare su
        /// una presentazione demo del design pattern particolare 
        /// </summary>
        public void LoadDBParams(bool reduced = false)
        {
            // impostazione relativa al database access di provenienza descrizioni diversi design patterns
            CreateConnString_Access();
            // load delle liste iniziali di configurazione 
            LoadInitialListsDB(reduced);
            
        }

    /// <summary>
    /// Invocato dopo il caricamento nelle liste principali e nel caso in cui la configurazione sia relativa 
    /// alla presentazione 
    /// </summary>
        internal void MakeViewsPresentationLayer()
        {
          // creazione dei diversi contesti di pagina console attuali
          LoadViewConsolePagesFromDBElements();
        }


        /// <summary>
        /// Lettura della stringa di connessione per il database access dal quale vengono prese le informazioni sui design patterns
        /// </summary>
        private void CreateConnString_Access()
        {
            // impostazione della stringa di connessione per il database attuale 
            Constants.SET_DBACCESS_CONNECTION(
                Path.Combine(Environment.CurrentDirectory, Constants.DB_ACCESS_RELATIVEPATH, Constants.DB_ACCESS_NAME)
                );
        }


        /// <summary>
        /// Load iniziale delle diverse liste che sono necessarie per il popolamento dei dati da db 
        /// Il parametro reduced mi dice se devo effettuare eventualmente il recupero dei soli design patterns per il caso corrente 
        /// </summary>
        private void LoadInitialListsDB(bool reduced = false)
        {
            // load per la lista relativa a tutti i design patterns disponibili
            MemLists.DesignPatterns = ServiceLocator.GetAccessDBService.GetDesignPatternsFromAccessDB();
            // nessuna necessità di recupero di eventuali altre liste per il caso corrente   
            if (reduced)
              return;

            // load per la lista relativa a tutte le descrizioni per i design patterns disponibili
            MemLists.DesignPatterns_Descriptions = ServiceLocator.GetAccessDBService.GetDesignPatternsDescriptions();
            // load di tutte le tipologie per i design patterns correnti 
            MemLists.DesignPatterns_Types = ServiceLocator.GetAccessDBService.GetDesignPatternsTypes();
            // load di tutte le descrizioni per le tipologie di design patterns correnti 
            MemLists.DesignTypesDescriptions = ServiceLocator.GetAccessDBService.GetDesignPatternTypeDescriptions();
      // recupero di tutti gli esempi disponibili per i design patterns correnti 
      MemLists.DesignPatternsExamples = ServiceLocator.GetAccessDBService.GetDesignPatternsExamples();
        }


    /// <summary>
    /// Permette il recupero dei soli esempi tra cui si deve ricercare per l'esempio corrente 
    /// questa è l'unica attività di backend necessaria per la visualizzazione dell'esempio corrente 
    /// ed è necessaria per l'eventuale recupero delle righe da marcare all'interno del file in visualizzazione 
    /// </summary>
    internal void LoadExamplesFromDB()
    {
      // impostazione relativa al database access di provenienza descrizioni diversi design patterns
      CreateConnString_Access();
      // recupero di tutti gli esempi disponibili per i design patterns correnti 
      MemLists.DesignPatternsExamples = ServiceLocator.GetAccessDBService.GetDesignPatternsExamples();
    }


    /// <summary>
    /// Creazione delle diverse pagine di cui eseguire il display all'interno del contesto console 
    /// in base ai diversi elementi recuperati dalla base dati corrente
    /// </summary>
    private void LoadViewConsolePagesFromDBElements()
    {
      // creazione della pagina di partenza per l'interfaccia console corrente
      ServiceLocator.GetContextSelectorService.PrepareMainPageContext();

      // creazione delle diverse pagine di contesto per le descrizioni attuali
      foreach (DesignTypeDescription currDesTypeDescription in MemLists.DesignTypesDescriptions)
        ServiceLocator.GetContextSelectorService.PrepareDesignTypePageCurrDescription(currDesTypeDescription);

      // creazione delle pagine di descrizione per i design patterns e il contesto attuale 
      foreach (DesignPatternDescription currDesPatternDescription in MemLists.DesignPatterns_Descriptions)
        ServiceLocator.GetContextSelectorService.PrepareDesignPatternPageCurrDescription(currDesPatternDescription);
    }


    #region PREPARAZIONE PER L'ECCEZIONE CORRENTE 

    /// <summary>
    /// Preparazione del messaggio relativo alla verifica di una particolare eccezione all'interno del codice corrente 
    /// </summary>
    /// <param name="exceptionMsg"></param>
    /// <param name="exceptionStackTrace"></param>
    /// <returns></returns>
    public string PrepareMsgException(string exceptionMsg, string exceptionStackTrace)
    {
      return String.Format(
        Resource.EXCEPTION_MAIN_DISPLAY,
        exceptionMsg,
        exceptionStackTrace
        );
    }
    
    #endregion




  }
}
