using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;
using static DesignPatterns.Utils.Constants;

namespace DesignPatterns.Model.ViewModel
{
  /// <summary>
  /// Tutti gli attributi per la customizzazione del design pattern attuale 
  /// a livello di view
  /// </summary>
  internal class DesPatternView
  {
    /// <summary>
    /// Colore principale per la window corrente
    /// </summary>
    internal ColorScheme Win_ColorScheme { get; set; }


    /// <summary>
    /// Colore principale per la window relativa ai buttons
    /// </summary>
    internal ColorScheme Buttons_ColorScheme { get; set; }


    /// <summary>
    /// Colore principale per il title finestra 
    /// </summary>
    internal ColorScheme Title_ColorScheme { get; set; }


    /// <summary>
    /// Colore per il testo e per le descrizioni da applicare al contesto corrente
    /// </summary>
    internal ColorScheme Txt_ColorScheme { get; set; }


    /// <summary>
    /// Impostazione della colorazione per i tab nel caso di schermata principale
    /// </summary>
    internal ColorScheme Tab_ColorScheme { get; set; }
    

    /// <summary>
    /// ID per il design pattern attuale 
    /// </summary>
    internal int Design_PatternID { get; set; }


    /// <summary>
    /// Nome per il design pattern attuale 
    /// </summary>
    internal string DesignPatternName { get; set; }


    /// <summary>
    /// Tipologia per la pagina corrente
    /// </summary>
    internal PAGE_TYPE PageType { get; set; }


    /// <summary>
    /// ID per la descrizione design pattern attuale 
    /// </summary>
    internal int DesignPatternDescriptionID { get; set; }


    /// <summary>
    /// Descrizione per il design pattern attuale applicato alla pagina 
    /// </summary>
    internal string DesignPatternDescription { get; set; }


    /// <summary>
    /// Enumeratore per il contesto di creazione corrente per il design pattern corrente
    /// </summary>
    internal int DesignPatternContextEnum { get; set; }

    #region PARAMETRI IDENTIFICATORI PER LA PAGINA CORRENTE

    /// <summary>
    /// Indicazione di pagina successiva per il contenuto attuale 
    /// riferimento al contesto relativo alla stessa tipologia di pagina 
    /// </summary>
    internal bool HasNextPage { get; set; }


    /// <summary>
    /// Indicazione di pagina precedente per il contenuto attuale 
    /// riferimento al contesto relativa alla stessa tipologia di pagina 
    /// </summary>
    internal bool HasPrevPage { get; set; }


    /// <summary>
    /// Indicazione di contesto di visualizzazione button di Esempio per una descrizione 
    /// forward rispetto a delle pagine di esempio
    /// </summary>
    internal bool HasExamplePage { get; set; }


    #region JUMP BACK O FORWARD RISPETTO ALLA PAGINA DI ESEMPIO 

    /// <summary>
    /// Indicazione di rientro all'indietro rispetto ad una pagina di descrizione dalla quale 
    /// era stato effettuato il salto alla pagina di esempio per il contesto corrente 
    /// </summary>
    internal bool BackDescriptionPage { get; set; }


    /// <summary>
    /// Ritorno alla pagina di contesto relativa alle descrizioni una volta visualizzate tutte le pagine di esempio per il contesto corrente 
    /// </summary>
    internal bool ForwardDescriptionPage { get; set; }

    #endregion


    /// <summary>
    /// Indicazione di contesto relativa alla presenza della pagina di demo (devo aprire un nuovo programma)
    /// </summary>
    internal bool HasDemoPage { get; set; }

    #endregion


    #region PARAMETRI PER LA PAGINA PRINCIPALE

    internal List<PatternTypesView> DesignTypesList { get; set; }

    #endregion


    #region INDICAZIONI TIPOLOGIA PAGINA PRECEDENTE SUCCESSIVA 

    internal PAGE_TYPE PrevPage_Type { get; set; }


    internal PAGE_TYPE NextPage_Type { get; set; }

    #endregion


    #region VALORIZZAZIONE CON ID CODE E ANTICODE 


    internal bool HasCode { get; set; }


    internal bool HasWrongCode { get; set; }


    internal int CodeClassID { get; set; }


    internal int WrongCodeClassID { get; set; }

    #endregion


    #region LISTE UTILIZZATE PER LA RENDERIZZAZIONE DELL'ESEMPIO CORRENTE 

    /// <summary>
    /// Linee di testo che devono essere renderizzate per l'esempio corrente 
    /// </summary>
    internal List<string> ListCompleteText { get; set; }


    /// <summary>
    /// Linee relative al caso corrente che devono essere evidenziate a seconda del caso 
    /// </summary>
    internal List<int[]> MarkedPositionsLines { get; set; }

    #endregion
  }
}
