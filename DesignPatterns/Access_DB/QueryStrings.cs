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

    #endregion


    #region QUERIES PER IL RECUPERO DI TUTTE LE ISTANZE PER GLI ELEMENTI DB

    /// <summary>
    /// Getter per la query per il recupero di tutti i design patterns per il contesto attuale 
    /// </summary>
    private static string _GETDESIGNPATTERNS_QUERY = "SELECT ID, DesignPattern, DesignType_ID, HasExample FROM DesignPatterns";
    
    internal static string GETDESIGNPATTERNS_QUERY()
    {
      return _GETDESIGNPATTERNS_QUERY;
    }


    /// <summary>
    /// Getter per la query di recupero delle descrizioni per i design patterns attuali
    /// </summary>
    private static string _GETDESIGNPATTERNSDESCRIPTION_QUERY = @"SELECT 
                                                                          ID, 
                                                                          ID_DesignPattern, 
                                                                          Description, 
                                                                          ID_VisualActionType, 
                                                                          HasCode, 
                                                                          HasWrongCode,
                                                                          ExampleID,
                                                                          WrongID,
                                                                          ID_Vis FROM DesignPatterns_Descriptions";

    internal static string GETDESIGNPATTERNSDESCRIPTION_QUERY()
    {
      return _GETDESIGNPATTERNSDESCRIPTION_QUERY;
    }


    /// <summary>
    /// Selezione variabili per le tipologie di design patterns disponibili per il contesto corrente 
    /// </summary>
    private static string _GETDESIGNTYPES_QUERY = @"SELECT ID, DesignPattern_Type FROM DesignType";

    internal static string GETDESIGNTYPES_QUERY()
    {
      return _GETDESIGNTYPES_QUERY;
    }


    /// <summary>
    /// Getter query per le descrizioni applicate alle diverse tipologie di design patterns per il contesto corrente
    /// </summary>
    private static string _GETDESIGNTYPESDESCRIPTIONS_QUERY = @"SELECT ID, Descrizione, ID_Type FROM DesignTypes_Descriptions";

    internal static string GETDESIGNTYPESDESCRIPTIONS_QUERY()
    {
      return _GETDESIGNTYPESDESCRIPTIONS_QUERY;
    }

    #endregion


    #region QUERY PER IL RECUPERO DEGLI ESEMPI LEGATI AI DESIGN PATTERNS ATTUALI

    /// <summary>
    /// Query di recupero per gli esempi legati ai design patterns attuali
    /// </summary>
    private static string _GETDESPATTERNEXAMPLES_QUERY = @"SELECT ID, RelativePath_Example, Name_Example, IsWrong, MarkedLines FROM Designpatterns_Examples";

    internal static string GETDESPATTERNEXAMPLES_QUERY()
    {
      return _GETDESPATTERNEXAMPLES_QUERY;
    }

    #endregion

  }
}
