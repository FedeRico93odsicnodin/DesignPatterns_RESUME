using DesignPatterns.Model.ViewModel;
using DesignPatterns.Properties;
using DesignPatterns.ViewConsole.ConsolePageServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;
using static DesignPatterns.Utils.Constants;

namespace DesignPatterns.ViewConsole
{
  /// <summary>
  /// Pagina principale che viene implemntata diversamente a seconda del contesto di visualizzazione 
  /// </summary>
  internal class GeneralPage
  {

    #region IDENTIFICATIVI PER LA PAGINA CORRENTE 

    /// <summary>
    /// Finestra principale: la imposto per o
    /// </summary>
    private Window _mainWindow { get; set; }
    
    #region ELEMENTI RELATIVI ALLA PAGINA PRINCIPALE

    private TabView _tabTypologies { get; set; }

    /// <summary>
    /// Indicazione di aver inizializzato il tab view di test e che devo eliminare il tab di test che avevo inserito 
    /// </summary>
    bool _isTabViewTest = true;
    
    private Dictionary<int, TabView.Tab> _designTypesEnsables { get; set; }

    #endregion


    /// <summary>
    /// Eventuale menu da aggiungere al contesto di finestra attuale 
    /// </summary>
    internal Window MainWindow { get { return _mainWindow; } }


    /// <summary>
    /// Titolo per la finestra corrente 
    /// </summary>
    private Label _windowTitle { get; set; }


    internal Label WindowTitle { get { return _windowTitle; } }


    /// <summary>
    /// Descrizione per la pagina corrente
    /// </summary>
    private TextView _descriptionView { get; set; }


    /// <summary>
    /// Menu relativo alla pagina corrente 
    /// </summary>
    private MenuBar _topMenu { get; set; }


    internal MenuBar TopMenu { get { return _topMenu; } }


    /// <summary>
    /// Button per la pagina successiva 
    /// </summary>
    private Button _nextButton { get; set; }


    /// <summary>
    /// Button per la pagina precedente 
    /// </summary>
    private Button _prevButton { get; set; }


    /// <summary>
    /// Button per mostrare la pagina di esempio per il contesto corrente 
    /// </summary>
    private Button _showExamplePage { get; set; }


    /// <summary>
    /// Button per mostrare la pagina di demo per il contesto corrente 
    /// </summary>
    private Button _showDemoPage { get; set; }


    /// <summary>
    /// Button per la pagina di main menu 
    /// </summary>
    private Button _mainMenuButton { get; set; }


    /// <summary>
    /// Ritorno al contesto di visualizzazione delle descrizioni per il design pattern attuale 
    /// dopo aver visualizzato un certo numero di pagine di esempio per il contesto attuale 
    /// </summary>
    private Button _forwardDescrButton { get; set; }


    /// <summary>
    /// Questa label viene posizionata sopra il txt view principale ma di fatto è attiva solo per la pagina di esempio 
    /// viene impostata la descrizione per la label e nel blocco di testo mostrato il codice 
    /// </summary>
    private Label _labelDescriptionExample { get; set; }
    
    #endregion



    /// <summary>
    /// Impostazione per il view bag corrente di pagina 
    /// </summary>
    protected DesPatternView viewBagBase { get; set; }


    #region IDENTIFICATIVI PER IL DESIGN PATTERN CORRENTE 

    /// <summary>
    /// Identificativo per la pagina corrente 
    /// </summary>
    public int GlobalPageID { get; protected set; }


    /// <summary>
    /// Valore per il design pattern corrente 
    /// </summary>
    public string DesignPatternName { get; protected set; }


    /// <summary>
    /// ID per il design pattern sul quale viene renderizzata la pagina 
    /// </summary>
    public int DesignPatternID { get; protected set; }


    /// <summary>
    /// Tipo di pagina su cui si stanno visualizzando per le informazioni correnti
    /// </summary>
    public PAGE_TYPE PageType { get; protected set; }


    /// <summary>
    /// Enumerativo della descrizione per il design pattern attuale 
    /// </summary>
    public int DescriptionPatternID { get; protected set; }


    /// <summary>
    /// Descrizione applicata alla pagina corrente
    /// </summary>
    public string DesignPatternDescription { get; protected set; }


    /// <summary>
    /// ID tipologia di appartenenza per il design pattern attuale 
    /// </summary>
    public int DesignTypeID { get; protected set; }


    /// <summary>
    /// Ordine della pagina per il contesto corrente
    /// </summary>
    public int PageContextEnum { get; protected set; }

    #endregion
    

    /// <summary>
    /// Permette l'impostazione del label title e del color per il title 
    /// nel contesto correntemente in utilizzo 
    /// </summary>
    /// <param name="winTitle"></param>
    /// <param name="colorScheme"></param>
    private void CreateTitleLabel(ColorScheme colorScheme)
    {
      // inizializzazione della label principale 
      if (_windowTitle == null)
        _windowTitle = new Label()
        {
          TextAlignment = TextAlignment.Centered,
          Width = Dim.Fill() - 1,
          Height = Dim.Fill(),
          X = 1,
          Y = 1,
          ColorScheme = colorScheme
        };
      else
        _windowTitle.ColorScheme = colorScheme; // cambiamento del solo stile 
    }

    /// <summary>
    /// Set etichetta per il titolo: questo può corrispondere con un nome del design pattern o con una tipologia 
    /// particolare di design patterns
    /// </summary>
    /// <param name="titleLabel"></param>

    protected void SetTitleLabel(string titleLabel)
    {
      _windowTitle.Text = titleLabel;
    }


    /// <summary>
    /// Impostazione della label di testo nel caso in cui stia visualizzando una pagina di esempio 
    /// </summary>
    /// <param name="colorScheme"></param>
    private void CreateLabelDescriptionExample()
    {
      if (_labelDescriptionExample == null)
      {
        _labelDescriptionExample = new Label()
        {
          Width = Dim.Fill() - 4,
          Height = Dim.Fill() - 10,
          X = 2,
          Y = 2,
          ColorScheme = ViewConsoleConstants.LABEL_EXAMPLE_DESCRIPTION_COLORSCHEME,
          Visible = false
        };
      }
      else
        _labelDescriptionExample.ColorScheme = ViewConsoleConstants.LABEL_EXAMPLE_DESCRIPTION_COLORSCHEME;
      _mainWindow.Add(_labelDescriptionExample);
    }


    /// <summary>
    /// Permette di visualizzare la label relativa alla descrizione per la pagina di esempio
    /// </summary>
    /// <param name="visibility"></param>
    protected void SetLabelDescriptionVisibility(bool visibility)
    {
      _labelDescriptionExample.Visible = visibility;
    }


    /// <summary>
    /// Permette di impostare il valore per la descrizione della pagina di esempio corrente 
    /// Assicurarsi che questo metodo sia invocato prima della creazione del blocco di testo successivo 
    /// </summary>
    /// <param name="exampleDescr"></param>
    protected void SetLabelDescriptionExample(string exampleDescr)
    {
      _labelDescriptionExample.Text = exampleDescr;
      // impostazione della dimensione da attribuire alla label
      int numLines = exampleDescr.Split('\n').Length;
      _labelDescriptionExample.Height = numLines;
      // impostazione della posizione di partenza del blocco di esempio
      _descriptionView.Y = Pos.Bottom(_labelDescriptionExample) + 1;
    }


    /// <summary>
    /// Impostazione del testo per la descrizione corrente
    /// </summary>
    /// <param name="colorScheme"></param>
    private void CreateDescriptionText(ColorScheme colorScheme)
    {
      // testo di descrizione 
      if (_descriptionView == null)
        _descriptionView = new TextView()
        {
          Width = Dim.Fill() - 4,
          Height = Dim.Fill() - 10,
          X = 2,
          Y = 2,
          ColorScheme = colorScheme,
          Visible = true
        };
      else
        _descriptionView.ColorScheme = colorScheme; // cambio solo lo stile 
      _mainWindow.Add(_descriptionView);
    }
    
    /// <summary>
    /// Impostazione del testo principale per la pagina corrente
    /// </summary>
    /// <param name="descriptionText"></param>
    protected void SetDescriptionText(string descriptionText)
    {
      _descriptionView.Text = descriptionText;
      // impostazione della dimensione da attribuire al textblock 
      int numLines = descriptionText.Split('\n').Length;
      _descriptionView.Height = numLines + 2;
      // ricalcolo delle posizioni per tutti i buttons coinvolti
      _nextButton.Y = Pos.Bottom(_descriptionView) + 1;
      _prevButton.Y = Pos.Bottom(_descriptionView) + 1;
      _mainMenuButton.Y = Pos.Bottom(_descriptionView) + 1;
      _showDemoPage.Y = Pos.Bottom(_descriptionView) + 1;
      _showExamplePage.Y = Pos.Bottom(_descriptionView) + 1;
      _forwardDescrButton.Y = Pos.Bottom(_descriptionView) + 1;
    }
    

    /// <summary>
    /// Impostazione della window per il contesto corrente
    /// </summary>
    /// <param name="colorScheme"></param>
    private void SetWindow(ColorScheme colorScheme)
    {
      if (_mainWindow == null)
        _mainWindow = new Window()
        {
          X = 0,
          Y = 2,
          Width = Dim.Fill(),
          Height = Dim.Fill(),
          ColorScheme = colorScheme
        };
      else
        _mainWindow.ColorScheme = colorScheme;

    }

    /// <summary>
    /// Permette l'impostazione dei buttons per l'interfaccia attuale 
    /// </summary>
    /// <param name="colorScheme"></param>
    private void SetButtons(ColorScheme colorScheme)
    {
      if (_nextButton == null)
      {
        _nextButton = new Button()
        {
          X = 4,
          Y = Pos.Bottom(_mainWindow) + 2,
          Text = Resource.NEXT_BTN_TXT,
          ColorScheme = colorScheme,
          Visible = true
        };
        // impostazione dell'azione di visualizzazione pagina successiva 
        _nextButton.Clicked += () => GoToNextPage(viewBagBase.Design_PatternID, viewBagBase.DesignPatternContextEnum, viewBagBase.PageType);
        _mainWindow.Add(_nextButton);
      }
      else
        _nextButton.ColorScheme = colorScheme;
      if (_prevButton == null)
      {
        _prevButton = new Button()
        {
          X = 14,
          Y = Pos.Bottom(_mainWindow) - 2,
          Text = Resource.PREV_BTN_TXT,
          ColorScheme = DecidePrevButtonColor(colorScheme),
          Visible = true,
        };
        // impostazione dell'azione di visualizzazione pagina precedente 
        _prevButton.Clicked += () => GoToPrevPage(viewBagBase.Design_PatternID, viewBagBase.DesignPatternContextEnum);
        _mainWindow.Add(_prevButton);
      }
      else
        _prevButton.ColorScheme = DecidePrevButtonColor(colorScheme);
      if (_mainMenuButton == null)
      {
        _mainMenuButton = new Button()
        {
          X = 24,
          Y = Pos.Bottom(_mainWindow) - 2,
          Text = Resource.MAIN_BTN_TXT,
          ColorScheme =
          colorScheme,
          Visible = true,
        };
        // impostazione dell'azione indipendentemente dal contesto che si sta analizzando 
        _mainMenuButton.Clicked += () => ServiceLocator.GetContextSelectorService.LoadMainPage();
        _mainWindow.Add(_mainMenuButton);
      }
      else
        _mainMenuButton.ColorScheme = colorScheme;
      // eventuali button di esempio -> questo button deve andare in sostituzione al button di next per la lettura delle descrizioni correnti 
      if (_showExamplePage == null)
      {
        _showExamplePage = new Button()
        {
          X = 4,
          Y = Pos.Bottom(_mainWindow) - 2,
          Text = Resource.EXAMPLE_BTN_TXT,
          ColorScheme = ViewConsoleConstants.BUTTON_EXAMPLE_COLORSCHEME, // colore specifico per la visualizzazione di questo tipo di button
          Visible = false,
        };
        // impostazione dell'azione di switch all'esempio rispetto alle descrizioni precedenti 
        _showExamplePage.Clicked += () => ShowExamplePage(viewBagBase.Design_PatternID, viewBagBase.DesignPatternContextEnum);
        _mainWindow.Add(_showExamplePage);
      }
      else 
        _showExamplePage.ColorScheme = ViewConsoleConstants.BUTTON_EXAMPLE_COLORSCHEME;
      if (_showDemoPage == null)
      {
        _showDemoPage = new Button()
        {
          X = 34,
          Y = Pos.Bottom(_mainWindow) - 2,
          Text = Resource.DEMO_BTN_TXT,
          ColorScheme = colorScheme,
          Visible = false,
        };
        _mainWindow.Add(_showDemoPage);
      }
      else
        _showDemoPage.ColorScheme = colorScheme;
      // impostazione button di forward description page 
      if(_forwardDescrButton == null)
      {
        _forwardDescrButton = new Button()
        {
          X = 4,
          Y = Pos.Bottom(_mainWindow) - 2,
          Text = Resource.DSCR_BTN_TXT, // impostazione della label di visualizzazione descrizione 
          ColorScheme = ViewConsoleConstants.BUTTON_DESCR_COLORSCHEME,
          Visible = false
        };
        // impostazione dell'azione di visualizzazione pagina successiva 
        _forwardDescrButton.Clicked += () => ForwardDescriptionPage(viewBagBase.Design_PatternID, viewBagBase.DesignPatternContextEnum);
        _mainWindow.Add(_forwardDescrButton);
      }

    }

    #region MODIFICATORI DI VISIBILITA' PER I BUTTONS
    
    protected void Btn_Next_Activation(bool activation)
    {
      _nextButton.Visible = activation;
    }

    protected void Btn_Prev_Activation(bool activation)
    {
      _prevButton.Visible = activation;
    }

    protected void Btn_Example_Activation(bool activation)
    {
      _showExamplePage.Visible = activation;
    }

    protected void Btn_Demo_Activation(bool activation)
    {
      _showDemoPage.Visible = activation;
    }

    protected void Btn_ForwardDescr_Activation(bool activation)
    {
      _forwardDescrButton.Visible = activation;
    }

    #endregion

    /// <summary>
    /// Impostazione del menu corrente: questa proprieta non si puo cambiare 
    /// </summary>
    private void InitTopMenu()
    {
      var menu = new MenuBar();
      menu.Width = Dim.Fill();
      menu.Height = 50;
      menu.ColorScheme = Colors.TopLevel;
      _topMenu = menu;
    }


    #region CUSTOM PER PAGINA CORRENTE

    /// <summary>
    /// Set dei parametri per la pagina principale in visualizzazione 
    /// questo metodo viene utilizzato dal costruttore di default 
    /// </summary>
    /// <param name="pageTitle"></param>
    /// <param name="titleScheme"></param>
    /// <param name="winScheme"></param>
    /// <param name="btnScheme"></param>
    private void SetPage(
      ColorScheme titleScheme, 
      ColorScheme winScheme, 
      ColorScheme btnScheme,
      ColorScheme txtColorScheme
      )
    {
      CreateTitleLabel(titleScheme);
      SetWindow(winScheme);
      SetButtons(btnScheme);
      CreateLabelDescriptionExample(); // creazione della label di visualizzazione descrizione (visibile solo per gli esempi)
      CreateDescriptionText(txtColorScheme);
      
    }


    /// <summary>
    /// Metodo utilizzato per il reset degli stili da una pagina che eredita e che ha bisogno di una particolare visualizzazione 
    /// per il suo contesto 
    /// </summary>
    protected void ResetPage()
    {
      SetPage(viewBagBase.Title_ColorScheme, viewBagBase.Win_ColorScheme, viewBagBase.Buttons_ColorScheme, viewBagBase.Txt_ColorScheme);
    }
    
    #endregion


    #region COSTRUTTORE + PARAMETRI DA CUSTOMIZZARE PER LE SOTTOCLASSI

    /// <summary>
    /// Costruttore: in base alla specializzazione eseguita viene specializzata 
    /// la costruzione della pagina attuale 
    /// </summary>
    /// <param name="viewParams"></param>
    internal GeneralPage(DesPatternView ViewParams)
    {
      // viewbag corrente per la pagina 
      viewBagBase = ViewParams;
      // impostazione statica per il menu relativo al contesto corrente
      InitTopMenu();
      // impostazione per la finestra principale
      SetPage(ViewParams.Title_ColorScheme, ViewParams.Win_ColorScheme, ViewParams.Buttons_ColorScheme, ViewParams.Txt_ColorScheme);
    }


    /// <summary>
    /// Se non passo nessuna proprietà ottengo i valori di default per il mio viewbag di console 
    /// </summary>
    internal GeneralPage()
    {
      // recupero delle impostazioni di default per la view corrente
      viewBagBase = ViewConsoleConstants.GetDefaultViewBagValues();
      // impostazione statica per il menu relativo al contesto corrente
      InitTopMenu();
      // impostazione per la finestra principale
      SetPage(viewBagBase.Title_ColorScheme, viewBagBase.Win_ColorScheme, viewBagBase.Buttons_ColorScheme, viewBagBase.Txt_ColorScheme);
    }

    #endregion


    #region SET DEI PARAMETRI PRINCIPALI DI PAGINA 
    
    protected void InitMainTabs(ColorScheme colorScheme)
    {
      _descriptionView.Visible = false; // devo disattivare la visualizzazione per il testo principale
      // inizializzazione dei tabs principali e aggiunta di valori di default per il caso corrente 
      _tabTypologies = new TabView()
      {
        Width = Dim.Fill() - 4,
        Height = Dim.Fill() - 4,
        X = 2,
        Y = 2,
        ColorScheme = colorScheme,
        Visible = true
      };
    }


    /// <summary>
    /// Aggiunta del tab alla visualizzazione: se è presente il tab di test questo viene eliminato 
    /// </summary>
    /// <param name="currTabType"></param>
    protected void AddTab(TabView.Tab currTabType)
    {
      
      // inserimento per il tab corrente 
      _tabTypologies.AddTab(currTabType, _isTabViewTest);
      _mainWindow.Add(_tabTypologies);
      _isTabViewTest = false;
    }

    #endregion


    #region AZIONI DI PREV E NEXT 

    /// <summary>
    /// Permette di eseguire il go to alla pagina successiva nel contesto corrente di analisi di un design pattern
    /// questo potrebbe essere dovuto alla presenza di piu pagine per il design pattern corrente e per le quali 
    /// si ceerca il typePageID successivo 
    /// </summary>
    /// <param name="desPatternID"></param>
    /// <param name="typePageID"></param>
    /// <param name="currPageType"></param>
    private void GoToNextPage(int desPatternID, int typePageID, PAGE_TYPE currPageType)
    {
      // richiamo il metodo del context selector 
      ServiceLocator.GetContextSelectorService.GoToNEXTContextPage(desPatternID, typePageID, currPageType);
    }


    /// <summary>
    /// Vado alla pagina precedente applicando la stessa logica del metodo precedente 
    /// </summary>
    /// <param name="desPatternID"></param>
    /// <param name="typePageID"></param>
    private void GoToPrevPage(int desPatternID, int typePageID)
    {
      // richiamo il metodo del context selector 
      ServiceLocator.GetContextSelectorService.GoToPREVContextPage(desPatternID, typePageID);
    }

    #endregion


    #region AZIONE RELATIVA ALLA VISUALIZZAZIONE PER LA PAGINA DI ESEMPIO 

    /// <summary>
    /// Azione relativa alla visualizzazione della pagina di esempio per il contesto corrente 
    /// </summary>
    /// <param name="desPatternID"></param>
    /// <param name="typePageID"></param>
    /// <param name="currPageType"></param>
    private void ShowExamplePage(int desPatternID, int typePageID)
    {
      // richiamo del metodo del context selector 
      ServiceLocator.GetContextSelectorService.GoToExampleNextPage(desPatternID, typePageID);
    }


    /// <summary>
    /// Ritorno al contesto di visualizzazione delle descrizioni dopo aver visualizzato le pagine di esempio 
    /// per il contesto corrente 
    /// </summary>
    /// <param name="desPatternID"></param>
    /// <param name="typePageID"></param>
    private void ForwardDescriptionPage(int desPatternID, int typePageID)
    {
      // richiamo del metodo del context selector 
      ServiceLocator.GetContextSelectorService.GoToDescriptionNextPage(desPatternID, typePageID);
    }

    #endregion


    /// <summary>
    /// Permette di stabilire quale colorazione applicare al button per tornare alla pagina precedente
    /// (gestita al di fuori del contesto )
    /// </summary>
    /// <returns></returns>
    private ColorScheme DecidePrevButtonColor(ColorScheme currColorScheme)
    {
      // pagina corrente di esempio e pagina precedente di descrizione -> ritorno il colore della pagina di descrizione 
      if (viewBagBase.PageType == PAGE_TYPE.EXAMPLE && viewBagBase.PrevPage_Type == PAGE_TYPE.DESCRIPTION)
        return ViewConsoleConstants.BUTTON_DESCR_COLORSCHEME;
      // pagina corrente di descrizione e pagina precedente di esempio -> ritorno il colore della pagina di esempio
      if (viewBagBase.PageType == PAGE_TYPE.DESCRIPTION && viewBagBase.PrevPage_Type == PAGE_TYPE.EXAMPLE)
        return ViewConsoleConstants.BUTTON_EXAMPLE_COLORSCHEME;

      return currColorScheme;
    }
  }
}
