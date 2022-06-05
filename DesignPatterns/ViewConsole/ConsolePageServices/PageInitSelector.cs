using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.ViewConsole.ConsolePageServices
{
    /// <summary>
    /// Servizio per l'inizializzazione di nuove pagine e per la selezione in base alla logica in implementazione corrente 
    /// Queste pagine vengono richieste in base alla implementazione e alla decisione che si esegue all'interno del main 
    /// </summary>
    internal class PageInitSelector
    {
        /// <summary>
        /// Costruzione della pagina relativa al design pattern corrente 
        /// questa pagina prende direttamente l'ID per la tipologia di design pattern
        /// </summary>
        internal void ConstructPatternType_DescriptionPage(
            int IDType,
            string DesignPatternName,
            string DesignPatternDescription
            )
        {

        }
    }

    
}
