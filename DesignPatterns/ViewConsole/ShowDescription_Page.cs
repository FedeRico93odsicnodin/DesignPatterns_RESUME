using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.ViewConsole
{


    /// <summary>
    /// Pagina per la visualizzazione particolare del design pattern in considerazione 
    /// </summary>
    internal class ShowDescription_Page
    {
        #region IDENTIFICATIVI PER LA PAGINA CORRENTE / SUCCESSIVA

        /// <summary>
        /// Identificativo per l'eventuale ID per la pagina successiva, se non esiste nessuna pagina successiva 
        /// allora viene tenuto a 0
        /// </summary>
        public int IDNextPage { get; private set; }


        /// <summary>
        /// Identificativo per l'eventuale ID per la pagina precedente, se non esiste nessuna pagina precedente 
        /// allora viene tenuto a 0
        /// </summary>
        public int IDPrevPage { get; private set; }


        /// <summary>
        /// Identicativo per la pagina di codice, se nessuna pagina di codire è presente allora viene tenuto a 0
        /// </summary>
        public int IDPageCode { get; private set; }


        /// <summary>
        /// Identificativo per l'eventuale pagina di esempio per il pattern corrente 
        /// </summary>
        public int IDExample { get; private set; }

        #endregion
    }
}
