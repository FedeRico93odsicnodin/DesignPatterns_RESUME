using DesignPatterns.Access_DB;
using DesignPatterns.DesignPatterns;
using DesignPatterns.Utils;
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
    }
}
