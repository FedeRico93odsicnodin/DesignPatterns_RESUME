﻿using System;
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
        internal const string DB_ACCESS_NAME = "Design_Patterns.accdb";


        /// <summary>
        /// Percorso relativo alla folder rispetto al progetto nel quale il file access si trova 
        /// </summary>
        internal const string DB_ACCESS_RELATIVEPATH = "Access_DB\\";


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
        /// Enumeratore rispetto al nome per il design pattern corrente 
        /// </summary>
        public enum DESIGN_PATTERN_ENUM
        {
            Singleton = 0,
        }


        #endregion
    }
}
