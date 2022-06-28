using DesignPatterns.Model;
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
            // creazione dei diversi contesti di pagina console attuali
            LoadViewConsolePagesFromDBElements();
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
            // load per la lista relativa a tutti i design patterns disponibili
            MemLists.DesignPatterns = ServiceLocator.GetAccessDBService.GetDesignPatternsFromAccessDB();
            // load per la lista relativa a tutte le descrizioni per i design patterns disponibili
            MemLists.DesignPatterns_Descriptions = ServiceLocator.GetAccessDBService.GetDesignPatternsDescriptions();
            // load di tutte le tipologie per i design patterns correnti 
            MemLists.DesignPatterns_Types = ServiceLocator.GetAccessDBService.GetDesignPatternsTypes();
            // load di tutte le descrizioni per le tipologie di design patterns correnti 
            MemLists.DesignTypesDescriptions = ServiceLocator.GetAccessDBService.GetDesignPatternTypeDescriptions();
        }


    /// <summary>
    /// Creazione delle diverse pagine di cui eseguire il display all'interno del contesto console 
    /// in base ai diversi elementi recuperati dalla base dati corrente
    /// </summary>
    private void LoadViewConsolePagesFromDBElements()
    {
      // creazione della pagina di partenza per l'interfaccia console corrente
      ServiceLocator.GetContextSelectorService.PrepareMainPageContext();

      // creazione delle diverse pagine di contesto per le descrizioni attuali
      foreach (DesignTypeDescription currDesTypeDescription in MemLists.DesignTypesDescriptions)
        ServiceLocator.GetContextSelectorService.PrepareDesignTypePageCurrDescription(currDesTypeDescription);

      // creazione delle pagine di descrizione per i design patterns e il contesto attuale 
      foreach (DesignPatternDescription currDesPatternDescription in MemLists.DesignPatterns_Descriptions)
        ServiceLocator.GetContextSelectorService.PrepareDesignPatternPageCurrDescription(currDesPatternDescription);
    }

    }
}
