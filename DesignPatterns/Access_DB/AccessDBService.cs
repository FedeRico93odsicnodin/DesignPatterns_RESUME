using DesignPatterns.Model;
using DesignPatterns.Utils;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DesignPatterns.Utils.Constants;

namespace DesignPatterns.Access_DB
{
    /// <summary>
    /// Tutti i servizi di connessione relativi all'utilizzo del db per il recupero delle informazioni sui design patterns disponibili 
    /// </summary>
    internal class AccessDBService
    {

    /// <summary>
    /// Getter design patterns da DB Access
    /// </summary>
    /// <returns></returns>
      public List<DesignPattern> GetDesignPatternsFromAccessDB()
    {
      List<DesignPattern> currDesignPatterns = new List<DesignPattern>();

      using (OleDbConnection con = new OleDbConnection(Constants.GET_DBACCESS_CONNECTION()))
      {
        con.Open();
        using (OleDbCommand cmd = new OleDbCommand(QueryStrings.GETDESIGNPATTERNS_QUERY(), con))
        {
          using (OleDbDataReader reader = cmd.ExecuteReader())
          {
            while (reader.Read())
            {
              int id = (int)reader["ID"];
              string desc = (string)reader["DesignPattern"];
              int idType = (int)reader["DesignType_ID"];
              bool hasExample = (bool)reader["HasExample"];
              // aggiunta per il design pattern corrente
              currDesignPatterns.Add(new DesignPattern()
              {
                ID = id,
                Name = desc,
                DesignType_ID = idType,
                HasExample = hasExample
              });
            }
          }
        }
        con.Close();
      }

      return currDesignPatterns;
    }


    /// <summary>
    /// Tutte le descrizioni applicate per i design patterns attuali
    /// </summary>
    /// <returns></returns>
    public List<DesignPatternDescription> GetDesignPatternsDescriptions()
    {
      List<DesignPatternDescription> currDesignPatternsDescriptions = new List<DesignPatternDescription>();

      using (OleDbConnection con = new OleDbConnection(Constants.GET_DBACCESS_CONNECTION()))
      {
        con.Open();
        using (OleDbCommand cmd = new OleDbCommand(QueryStrings.GETDESIGNPATTERNSDESCRIPTION_QUERY(), con))
        {
          using (OleDbDataReader reader = cmd.ExecuteReader())
          {
            while (reader.Read())
            {
              int id = (int)reader["ID"];
              int id_DesignPattern = (int)reader["ID_DesignPattern"];
              string desc = (reader["Description"] != DBNull.Value) ? 
                (string)reader["Description"] : String.Empty;
              string classRelativePath = (reader["Class_RelativePath"] != DBNull.Value) ? 
                (string)reader["Class_RelativePath"] : String.Empty;
              int idVisualActionType = (int)reader["ID_VisualActionType"];
              bool hasCode = (bool)reader["HasCode"];
              int idVis = (reader["ID_Vis"] != DBNull.Value) ? (int)reader["ID_Vis"] : id;
              if (idVis == 0)
                idVis = id;
              // aggiunta per il design pattern corrente
              currDesignPatternsDescriptions.Add(new DesignPatternDescription()
              {
                ID = id,
                ID_DesignPattern = id_DesignPattern,
                Description = desc,
                Class_RelativePath = classRelativePath,
                ID_VisualActionType = idVisualActionType,
                HasCode = hasCode,
                ID_Vis = idVis
              });
            }
          }
        }
        con.Close();
      }

      return currDesignPatternsDescriptions;
    }


    /// <summary>
    /// Recupero di tutti i tipi per i design patterns attuali
    /// </summary>
    /// <returns></returns>
    public List<DesignType> GetDesignPatternsTypes()
    {
      List<DesignType> currDesignPatternsTypes = new List<DesignType>();

      using (OleDbConnection con = new OleDbConnection(Constants.GET_DBACCESS_CONNECTION()))
      {
        con.Open();
        using (OleDbCommand cmd = new OleDbCommand(QueryStrings.GETDESIGNTYPES_QUERY(), con))
        {
          using (OleDbDataReader reader = cmd.ExecuteReader())
          {
            while (reader.Read())
            {
              int id = (int)reader["ID"];
              string desc = (string)reader["DesignPattern_Type"];
              // aggiunta per il design pattern corrente
              currDesignPatternsTypes.Add(new DesignType()
              {
                ID = id,
                Name = desc
              });
            }
          }
        }
        con.Close();
      }

      return currDesignPatternsTypes;
    }


    /// <summary>
    /// Tutte le descrizioni per le diverse tipologie di design pattern disponibili
    /// </summary>
    /// <returns></returns>
    public List<DesignTypeDescription> GetDesignPatternTypeDescriptions()
    {
      List<DesignTypeDescription> currDesignTypeDescriptions = new List<DesignTypeDescription>();

      using (OleDbConnection con = new OleDbConnection(Constants.GET_DBACCESS_CONNECTION()))
      {
        con.Open();
        using (OleDbCommand cmd = new OleDbCommand(QueryStrings.GETDESIGNTYPESDESCRIPTIONS_QUERY(), con))
        {
          using (OleDbDataReader reader = cmd.ExecuteReader())
          {
            while (reader.Read())
            {
              int id = (int)reader["ID"];
              string desc = (string)reader["Descrizione"];
              int idType = (int)reader["ID_Type"];
              // aggiunta per il design pattern corrente
              currDesignTypeDescriptions.Add(new DesignTypeDescription()
              {
                ID = id,
                Description = desc,
                IDType = idType
              });
            }
          }
        }
        con.Close();
      }

      return currDesignTypeDescriptions;
    }
    
    }
}
