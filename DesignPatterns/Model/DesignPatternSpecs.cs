using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;
using static DesignPatterns.Utils.Constants;

namespace DesignPatterns.Model
{
    /// <summary>
    /// Specifiche di implementazione per il design pattern corrente 
    /// </summary>
    public class DesignPatternSpecs
    {

        /// <summary>
        /// Descrizione recuperata dal db per il design pattern attuale 
        /// </summary>
        protected DesignPattern _designPatternCurrDescription = null;


        /// <summary>
        /// Descrizioni paginate per il design pattern corrente 
        /// </summary>
        public Dictionary<int, string> GetDesignPatternDescriptions { get; protected set; }


        /// <summary>
        /// Esempi paginati per il design pattern corrente 
        /// </summary>
        public Dictionary<int, string> GetDesignPatternExamples { get; protected set; }


        /// <summary>
        /// Esempio per il design pattern corrente 
        /// </summary>
        public string GetDesignPatternExample { get; protected set; }
        

        /// <summary>
        /// Costruttore non si puo richiamare
        /// </summary>
        protected DesignPatternSpecs()
        {
            // recupero specifiche principali per il design pattern corrente 
            GetDesignPatternsObject();
        }


        /// <summary>
        /// Permette di recuperare le specifiche per il design pattern corrente a partire dal nome che viene attribuito per questo design pattern
        /// </summary>
        protected void GetDesignPatternsObject()
        {
            // recupero parametri descrittivi per il desgin pattern attuale 
            //_designPatternCurrDescription = ServiceLocator.GetAccessDBService.GetDescriptionCurrDesignPattern(DesignPatternName);

            // popolamento delle descrizioni per ogni pagina disponibile 
            PopulateDictionaryPage_Description();

            // popolamento degli esempi per ogni pagina disponibile 
            PopulateDictionaryPage_Example();
        }


        /// <summary>
        /// Popolamento con i valori relativi alle descrizioni per ogni pagina presente per il design pattern attuale 
        /// </summary>
        private void PopulateDictionaryPage_Description()
        {
            GetDesignPatternDescriptions = new Dictionary<int, string>();

            // popolamento con main description e esempio 
            //GetDesignPatternDescriptions[1] = _designPatternCurrDescription.Description;
        }


        /// <summary>
        /// Popolamento con i valori relativi agli esempi per ogni pagina presente il desgin pattern attuale, segue con la stessa enumerazione per il dizionario per il quale 
        /// c'è stato lo stesso popolamento relativo alle descrizioni per il design pattern
        /// </summary>
        private void PopulateDictionaryPage_Example()
        {


            GetDesignPatternExamples = new Dictionary<int, string>();

            // popolamento con main description e esempio 
            //GetDesignPatternExamples[1] = _designPatternCurrDescription.Example;


        }

    }
}
