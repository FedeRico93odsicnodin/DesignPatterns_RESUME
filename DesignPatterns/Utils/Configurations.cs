using DesignPatterns.Model;
using DesignPatterns.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static DesignPatterns.Utils.Constants;

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
          // indicazione di caricamento avvenuto correttamente da db 
          bool parametersLoaded = false;

          // metodi validi nel caso in cui sia in presenza di un database Access
          if(Constants.ACCESS_DB_MODE == DB_TYPE.ACCESS)
          {
            // impostazione relativa al database access di provenienza descrizioni diversi design patterns
            CreateConnString_Access();
            // load delle liste iniziali di configurazione 
            LoadInitialListsDB(reduced);
            parametersLoaded = true; // parametri correttamente caricati 
          }
          // TODO: eventuale implementazione per altri tipi di sorgente 


          // se non sono riuscito a caricare tutti i parametri genero una eccezione 
          if (!parametersLoaded)
          {
            string generatedException = String.Format(Resource.EXCEPTION_CONFIG_PARAMNOTLOADED, Constants.ACCESS_DB_MODE.ToString());
            throw new Exception(generatedException);
          }
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
          string currPathAccess = String.Empty;
          // percorso relativo rispetto alla solution corrente 
          if (Constants.IS_ACCESS_REL_PATH)
            currPathAccess = Path.Combine(Environment.CurrentDirectory, Constants.DB_ACCESS_PATH, Constants.DB_ACCESS_NAME);
          // percorso assoluto 
          else
            currPathAccess = Constants.DB_ACCESS_PATH + Constants.DB_ACCESS_NAME;

          // impostazione della stringa di connessione per il database attuale 
          Constants.SET_DBACCESS_CONNECTION(
              currPathAccess
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
    /// Recupero degli steps per la visualizzazione della DEMO per il design pattern corrente 
    /// </summary>
    internal void LoadDesignPatternDEMOSteps(int desPatternID)
    {
      bool parametersLoaded = false;

      // recupero dei parametri per una configurazione access 
      if(Constants.ACCESS_DB_MODE == DB_TYPE.ACCESS)
      {
        // impostazione degli esempi di demo con il codice relativo al design pattern corrente 
        MemLists.DesignPattern_DEMOStep = ServiceLocator.GetAccessDBService.GetDesignPatternDEMOSTEPS(desPatternID);
        parametersLoaded = true;
      }
      // TODO: eventuale implementazione per altre modalità di accesso 


      // se non sono riuscito a caricare tutti i parametri genero una eccezione 
      if (!parametersLoaded)
      {
        string generatedException = String.Format(Resource.EXCEPTION_CONFIG_PARAMNOTLOADED, Constants.ACCESS_DB_MODE.ToString());
        throw new Exception(generatedException);
      }
    }


    /// <summary>
    /// Permette il recupero dei soli esempi tra cui si deve ricercare per l'esempio corrente 
    /// questa è l'unica attività di backend necessaria per la visualizzazione dell'esempio corrente 
    /// ed è necessaria per l'eventuale recupero delle righe da marcare all'interno del file in visualizzazione 
    /// </summary>
    internal void LoadExamplesFromDB()
    {
      bool parametersLoaded = false;
      // recupero dei parametri per una configurazione access 
      if (Constants.ACCESS_DB_MODE == DB_TYPE.ACCESS)
      {       
        // impostazione relativa al database access di provenienza descrizioni diversi design patterns
        CreateConnString_Access();
        // recupero di tutti gli esempi disponibili per i design patterns correnti 
        MemLists.DesignPatternsExamples = ServiceLocator.GetAccessDBService.GetDesignPatternsExamples();
        parametersLoaded = true;
      }
      // TODO: eventuale implementazione per altre modalità di accesso 


      // se non sono riuscito a caricare tutti i parametri genero una eccezione 
      if (!parametersLoaded)
      {
        string generatedException = String.Format(Resource.EXCEPTION_CONFIG_PARAMNOTLOADED, Constants.ACCESS_DB_MODE.ToString());
        throw new Exception(generatedException);
      }
    }


    /// <summary>
    /// Creazione delle diverse pagine di cui eseguire il display all'interno del contesto console 
    /// in base ai diversi elementi recuperati dalla base dati corrente
    /// </summary>
    private void LoadViewConsolePagesFromDBElements()
    {
      // impostazione dimensione per schermo corrente
      SetWinConsoleDimensions();

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


    #region DIMENSIONI WINDOWS CONSOLE 

    /// <summary>
    /// Set dei parametri relativi alla dimensione corrente per 
    /// la win screen
    /// </summary>
    internal void SetWinConsoleDimensions()
    {
      Constants.WIN_SCREEN_WIDTH = Console.WindowWidth;
      Constants.WIN_SCREEN_HEIGHT = Console.WindowHeight;
    }

    [DllImport("kernel32.dll")]
    private static extern IntPtr GetStdHandle(int handle);
    /// <summary>
    /// Impostazioni di full screen per la finestra attuale nel caso in cui apriamo una main window
    /// </summary>
    internal void SetFullScreenMode()
    {
      // impostazione full screen per la finestra corrente 
      IntPtr hConsole = GetStdHandle(-11);
      SetConsoleDisplayMode(hConsole, 1, out COORD b1);
    }

    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern bool SetConsoleDisplayMode(IntPtr ConsoleOutput, uint Flags, out COORD NewScreenBufferDimensions);

    [StructLayout(LayoutKind.Sequential)]
    private struct COORD
    {
      public short X;
      public short Y;

      private COORD(short X, short Y)
      {
        this.X = X;
        this.Y = Y;
      }
    }

    #endregion


    #region LETTURA DEI PARAMETRI DAL FILE APP CONFIG PRIMA DELL'AVVIO DELL'APPLICAZIONE 

    /// <summary>
    /// Lettura delle configurazioni iniziali dal file di configurazione per l'importazione dei parametri di base per l'applicazione corrente 
    /// </summary>
    public void ReadConfigFile()
    {
      // modalità di accesso a database
      string accessDBMode = System.Configuration.ConfigurationManager.AppSettings["AccessDBMode"];
      DB_TYPE currDB = ServiceLocator.GetExtraConvertersService.GetDBTypeCurrInstance(accessDBMode);
      // se non trovo nessuna modalità di accesso allora devo generare eccezione 
      if (currDB == DB_TYPE.NOT_DEFINED)
        throw new Exception(Resource.EXCEPTION_CONFIG_DBNOTDEFINED);

      // impostazione della tipologia di accesso corrente 
      Constants.ACCESS_DB_MODE = currDB;

      // impostazioni necessarie solamente per un database di tipo access 
      if(Constants.ACCESS_DB_MODE == DB_TYPE.ACCESS)
      {
        // impostazione del percorso relativo o assouluto per il datbaase di tipo access 
        string isAccessRelativePath = System.Configuration.ConfigurationManager.AppSettings["isAccessRelativePath"];
        if (isAccessRelativePath.ToLower() != "true" && isAccessRelativePath.ToLower() != "false")
          throw new Exception(Resource.EXCEPTION_CONFIG_PATHTYPENOTDEFINED);
        // impostazione della proprieta di percorso relativo 
        Constants.IS_ACCESS_REL_PATH = (isAccessRelativePath == "true") ? true : false;

        // lettura del percorso 
        string databasePath = System.Configuration.ConfigurationManager.AppSettings["AccessDBPath"].Trim();
        // impostazione slash finale 
        if (!databasePath.EndsWith("\\"))
          databasePath = databasePath += "\\";
        // impostazione del path per il database access 
        Constants.DB_ACCESS_PATH = databasePath;

        // lettura del nome 
        string databaseName = System.Configuration.ConfigurationManager.AppSettings["AccessDBName"].Trim();
        // impostazione slash finale 
        // impostazione del path per il database access 
        Constants.DB_ACCESS_NAME = databaseName;
      }
      
    }



    #endregion


  }
}
