using DesignPatterns.Access_DB;
using DesignPatterns.DesignPatterns;
using DesignPatterns.Utils;
using DesignPatterns.ViewConsole.ConsolePageServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    /// <summary>
    /// Locazione dei servizi per i diversi componenti applicativi attuali 
    /// </summary>
    internal static class ServiceLocator
    {
        #region LOAD SERVIZI DB ACCESS 

        /// <summary>
        /// Servizi database per il programma corrente (DB Access)
        /// </summary>
        private static AccessDBService _accessDBService;


        internal static AccessDBService GetAccessDBService
        {
            get
            {
                if (_accessDBService == null)
                    _accessDBService = new AccessDBService();

                return _accessDBService;
            }
        }

        #endregion


        #region LETTURA DELLE CONFIGURAZIONI INIZIALI 

        /// <summary>
        /// Lettura delle configurazioni iniziali piu conversioni di programma 
        /// </summary>
        private static Configurations _configurationsService;


        public static Configurations GetConfigurationsService
        {
            get
            {
                if (_configurationsService == null)
                    _configurationsService = new Configurations();

                return _configurationsService;
            }
        }

        #endregion


        #region DESIGN PATTERNS SPECIFICATIONS 

        private static DesignPatternsService _designPatternsService;


        public static DesignPatternsService GetDesignPatternsService
        {
            get
            {
                if (_designPatternsService == null)
                    _designPatternsService = new DesignPatternsService();

                return _designPatternsService;
            }
        }

    #endregion


    #region SERVIZIO DI PAGE SELECTOR E CREATOR

    private static PageContextSelector _getContextSelectorService;
    

    internal static PageContextSelector GetContextSelectorService
    {
      get
      {
        if (_getContextSelectorService == null)
          _getContextSelectorService = new PageContextSelector();

        return _getContextSelectorService;
      }
    }

    #endregion


    #region SERVIZIO RELATIVO A LAUNCH DELLA DEMO PER IL DESIGN PATTERN SELEZIONATO 

    private static ParallelExe _parallelExeService;


    internal static ParallelExe GetParallelExeService
    {
      get
      {
        if (_parallelExeService == null)
          _parallelExeService = new ParallelExe();

        return _parallelExeService;
      }
  
    }


    #endregion


    #region SERVIZI DI PREPARAZIONE EXTRA 

    private static ExtraConverters _extraConvertersService;

    internal static ExtraConverters GetExtraConvertersService
    {
      get
      {
        if (_extraConvertersService == null)
          _extraConvertersService = new ExtraConverters();

        return _extraConvertersService;
      }
    }

    #endregion
  }
}
