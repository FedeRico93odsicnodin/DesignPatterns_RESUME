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
        /// <summary>
        /// Selezione variabili per le tipologie di design patterns disponibili per il contesto corrente 
        /// </summary>
        internal static string GETDESIGNTYPE_DESCRIPTIONS_QUERY = @"SELECT ID, DesignPattern_Type FROM DesignType";
    }
}
