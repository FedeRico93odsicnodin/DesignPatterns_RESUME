using DesignPatterns.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Utils
{
    /// <summary>
    /// Constanti di progetto 
    /// </summary>
    public static class Constants
    {

        #region DB ACCESS CONNECTION 

        /// <summary>
        /// Nome per il file Access da cui vengono lette le informazioni
        /// NB per come il progetto viene configurato questo file deve essere sempre costante 
        /// </summary>
        internal static string DB_ACCESS_NAME = "Design_Patterns.accdb";


        /// <summary>
        /// Percorso relativo alla folder rispetto al progetto nel quale il file access si trova 
        /// </summary>
        internal static string DB_ACCESS_PATH = "Access_DB\\";


        /// <summary>
        /// Parte costante per la connessione relativa al database access
        /// </summary>
        private const string ACCESS_CONN_CONSTPART = "Provider=Microsoft.ACE.OleDB.12.0;Data Source={0}";


        /// <summary>
        /// Connessione database per il caso relativo ad access, questo percorso viene ricreato in base al percorso che si sceglie per la lettura delle informazioni 
        /// </summary>
        private static string DB_ACCESS_CONNECTION = String.Empty;


        /// <summary>
        /// Set della connessione con il percorso relativo al file db access
        /// </summary>
        /// <param name="accessDBPath"></param>
        public static void SET_DBACCESS_CONNECTION(string accessDBPath)
        {
            DB_ACCESS_CONNECTION = String.Format(ACCESS_CONN_CONSTPART, accessDBPath);
        }


    /// <summary>
    /// Questa informazione per stabilire se il percorso corrente per il database di tipo access sia 
    /// assoluto: direct location in una folder 
    /// relativo: cioe ricondotto alla solution su cui è avviato il progetto 
    /// </summary>
    public static bool IS_ACCESS_REL_PATH = false;


        /// <summary>
        /// Ritorno la connessione al database access in utilizzo corrente 
        /// </summary>
        /// <returns></returns>
        public static string GET_DBACCESS_CONNECTION()
        {
            return DB_ACCESS_CONNECTION;
        }

        #endregion


        #region ENUMERATORI DESIGN PATTERNS

        /// <summary>
        /// Lista dei possibili design patterns disponibili 
        /// </summary>
        public static List<DesignPattern> AVAILABLE_DESIGN_PATTERNS;


        /// <summary>
        /// Lista dei possibili patterns disponibili
        /// </summary>
        public static List<DesignType> AVAILABLE_TYPES;
    
        
        /// <summary>
        /// Tipo di pagina di cui eseguire il display 
        /// </summary>
        public enum PAGE_TYPE
        {
          DEFAULT = 0,
          DESCRIPTION = 1, 
          EXAMPLE = 2,
          DEMO = 3,
          MAIN = 4 // pagina principale di descrizione delle tipologie 
        }

    #endregion

      /// <summary>
      /// Identificatore per la pagina corrente
      /// </summary>
      private static int _PAGEID = 0;

      
      /// <summary>
      /// Getter per identificatore di pagina 
      /// </summary>
      internal static int GETPAGEID
      {
        get
        {
          _PAGEID++;
          return _PAGEID;
        }
      }


    /// <summary>
    /// Percorso Pagina di esempio per il contesto corrente e da andare ad inserire insieme alla descrizione 
    /// </summary>
    internal static string CODEEXAMPLE_RELATIVEPATH = "DesignPatterns\\Creational\\";


    /// <summary>
    /// File di esempio da cui leggere le diverse righe di codice per il contesto corrente 
    /// </summary>
    internal static string CODEEXAMPLE_FILE = "SingletonService.cs";


    #region MODALITA' DISPONIBILI PER IL PROGRAMMA CORRENTE

    /// <summary>
    /// Modalità di avviamento per il programma corrente: nel caso in cui viene avviato il layer di presentazione (default)
    /// viene avviata l'interfaccia di presentazione di tutti i design patterns 
    /// nel caso in cui viene avviata la demo devono essere passati anche i parametri relativi al design pattern corrispondente per la demo corrente
    /// per questo caso viene invocato un recupero ridotto dei parametri necessari per la presentazione 
    /// </summary>
    internal enum PROGRAM_MODES
    {
      PRESENTATION = 1,
      CODE_DEMO = 2,
      WRONG_EXAMPLE = 3
    }


    /// <summary>
    /// Run corrente per l'applicazione: di default viene impostato il layer di presentazione di tutti i design patterns 
    /// </summary>
    internal static PROGRAM_MODES PROGRAM_CURR_MODE = PROGRAM_MODES.PRESENTATION;


    /// <summary>
    /// Nome eseguibile che viene lanciato nelle 2 modalità in base al contesto di esecuzione corrente 
    /// </summary>
    internal static string EXENAME = "DesignPatterns.exe";


    /// <summary>
    /// ID per il design pattern di cui si è lanciato il tool in modalità di demo 
    /// </summary>
    internal static int DESPATTERN_DEMO_ID = 0;


    /// <summary>
    /// Nome per il design pattern che è stato lanciato per la modalità di demo 
    /// </summary>
    internal static string DESPATTERN_DEMO_DESCRIPTION = String.Empty;

    #endregion



    #region PARAMETRI RELATIVI AL SET DELLA WINDOW SIZE CORRENTE

    internal static int WIN_SCREEN_WIDTH = 0;


    internal static int WIN_SCREEN_HEIGHT = 0;

    #endregion


    #region PARAMETRI DI ACCESSO A DB 

    /// <summary>
    /// indicazione della tipologia di database che viene utilizzato per il contesto corrente 
    /// </summary>
    public enum DB_TYPE
    {
      NOT_DEFINED,
      ACCESS,
      SQL_SERVER 
    };

    /// <summary>
    /// Modalita di accesso corrente alle informazioni
    /// </summary>
    public static DB_TYPE ACCESS_DB_MODE = DB_TYPE.NOT_DEFINED;

    #endregion

  }
}
