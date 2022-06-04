using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Access_DB
{
    /// <summary>
    /// Query esecuzione per la procedura corrente 
    /// </summary>
    internal static class QueryStrings
    {
        #region RECUPERO DESCRIZIONI PER LE TIPOLOGIE DI DESIGN PATTERN

        /// <summary>
        /// Selezione variabili per le tipologie di design patterns disponibili per il contesto corrente 
        /// </summary>
        internal static string GETDESIGNTYPE_DESCRIPTIONS_QUERY = @"SELECT ID, DesignPattern_Type FROM DesignType";

        #endregion


        #region RECUPERO OGGETTO PER DESIGN PATTERN SPECIFICO 

        /// <summary>
        /// Query di selezione della specifica descrizione per il design pattern corrente 
        /// </summary>
        private static string _DESIGNPATTERNDESCRIPTION_QUERY = @"SELECT ID, DesignPattern, DesignType_ID, Description, Example FROM DesignPatterns_Description WHERE DesignPattern = '{0}' ORDER BY ID DESC";


        /// <summary>
        /// Getter per lo specifico oggetto di descrizione relativo al design pattern di cui viene passato il nome corrente 
        /// </summary>
        /// <param name="designPatternName"></param>
        /// <returns></returns>
        internal static string GETDESIGNPATTERNDESCRIPTION_QUERY(string designPatternName)
        {
            return String.Format(_DESIGNPATTERNDESCRIPTION_QUERY, designPatternName);
        }


        #endregion

    }
}
