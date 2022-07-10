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
    /// </summary>
    /// <param name="args"></param>
    /// <param name="desPatternID"></param>
    /// <param name="desPatternDescription"></param>
    /// <returns></returns>
        internal Constants.PROGRAM_MODES GetProgramCurrExeType(string[] args, out int desPatternID, out string desPatternDescription)
    {
      // modo di default 
      Constants.PROGRAM_MODES currModeDefault = Constants.PROGRAM_MODES.PRESENTATION;
      // inizializzazione parametri out 
      desPatternID = 0;
      desPatternDescription = String.Empty;
      // impostazione per il caso di demo 
      if (args[0] == Constants.PROGRAM_MODES.CODE_DEMO.ToString())
        currModeDefault = Constants.PROGRAM_MODES.CODE_DEMO;
      // se mi trovo nel caso di demo devo anche valorizzare gli attributi relativi al design pattern
      if(currModeDefault == Constants.PROGRAM_MODES.CODE_DEMO)
      {
        int.TryParse(args[1], out desPatternID); // conversione per l'ID del design pattern attuale 
        desPatternDescription = args[2];
      }
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
