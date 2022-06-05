using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Utils
{
    public class Configurations
    {
        /// <summary>
        /// Lettura delle configurazioni di progetto attuale dal file di configurazione o combinando i diversi percorsi disponibili 
        /// </summary>
        public void ReadConfigurations()
        {
            // impostazione relativa al database access di provenienza descrizioni diversi design patterns
            CreateConnString_Access();

            // load delle liste iniziali di configurazione 
            LoadInitialListsDB();
        }


        /// <summary>
        /// Lettura della stringa di connessione per il database access dal quale vengono prese le informazioni sui design patterns
        /// </summary>
        private void CreateConnString_Access()
        {
            // impostazione della stringa di connessione per il database attuale 
            Constants.SET_DBACCESS_CONNECTION(
                Path.Combine(Environment.CurrentDirectory, Constants.DB_ACCESS_RELATIVEPATH, Constants.DB_ACCESS_NAME)
                );
        }


        /// <summary>
        /// Load iniziale delle diverse liste che sono necessarie per il popolamento dei dati da db 
        /// </summary>
        private void LoadInitialListsDB()
        {
            // load delle diverse tipologie per i design patterns all'interno del contesto di applicazione attuale 
            //MemLists.DesignPatterns_Types = ServiceLocator.GetAccessDBService.GetDesignPatternTypes();
        }
    }
}
