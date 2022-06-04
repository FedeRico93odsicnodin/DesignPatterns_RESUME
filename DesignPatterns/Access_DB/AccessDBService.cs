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
        /// Recupero di tutte le descrizioni disponibili per i design patterns e le loro tipologie 
        /// </summary>
        /// <returns></returns>
        internal List<DesignType> GetDesignPatternTypes()
        {
                List<DesignType> currTypes = new List<DesignType>();

                using (OleDbConnection con = new OleDbConnection(Constants.GET_DBACCESS_CONNECTION()))
                {
                    con.Open();
                    using (OleDbCommand cmd = new OleDbCommand(QueryStrings.GETDESIGNTYPE_DESCRIPTIONS_QUERY, con))
                    {
                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = (int)reader["ID"];
                                string desc = (string)reader["DesignPattern_Type"];

                                currTypes.Add(new DesignType()
                                {
                                    ID = id,
                                    DesignPattern_Type = desc

                                });
                            }
                        }
                    }
                }


                return currTypes;
           
        }


        /// <summary>
        /// Recupero per la descrizione per il design pattern corrente: questa descrizione è ricercata in base al valore per l'enumeratore correntemente passato 
        /// </summary>
        /// <param name="currDesignPattern"></param>
        /// <returns></returns>
        internal DesignPatterns_Description GetDescriptionCurrDesignPattern(DESIGN_PATTERN_ENUM currDesignPattern)
        {
            DesignPatterns_Description currDesignPattern_obj = null;

            using (OleDbConnection con = new OleDbConnection(Constants.GET_DBACCESS_CONNECTION()))
            {
                con.Open();
                using (OleDbCommand cmd = new OleDbCommand(QueryStrings.GETDESIGNPATTERNDESCRIPTION_QUERY(currDesignPattern.ToString()), con))
                {
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        // lettura ultimo valore per il design pattern corrente 
                        if (reader.Read())
                        {
                            currDesignPattern_obj = new DesignPatterns_Description()
                            {
                                ID = (int)reader["ID"],
                                DesignPattern = (string)reader["DesignPattern"],
                                DesignType_ID = (int)reader["DesignType_ID"],
                                Description = (string)reader["Description"],
                                Example = (string)reader["Example"]
                            };
                        }
                    }
                }
            }


            return currDesignPattern_obj;
        }
    }
}
