using DesignPatterns.Model.ViewModel;
using DesignPatterns.Properties;
using DesignPatterns.Utils;
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
    private Label _descriptionView { get; set; }


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
    /// Impostazione del button per vedere l'esempio contrario che non va bene: con questa azione viene aperta 
    /// la finestra che mostra il codice relativo alla classe che viene utilizzata come counterexample per il caso corrente 
    /// </summary>
    private Button _wrongExampleButton { get; set; }


    /// <summary>
    /// Questa label viene posizionata sopra il txt view principale ma di fatto è attiva solo per la pagina di esempio 
    /// viene impostata la descrizione per la label e nel blocco di testo mostrato il codice 
    /// </summary>
    private Label _labelDescriptionExample { get; set; }


    /// <summary>
    /// Scrollview contenente il set di testo finale 
    /// </summary>
    private ScrollView _scrollViewContainer { get; set; }

    #endregion


    #region COSTANTI DI VISUALIZZAZIONE CONTENUTO PAGINA 

    /// <summary>
    /// Posizione relativa alla linea dove sono presenti tutti i buttons di pagina (in testa alla pagina corrente)
    /// </summary>
    private int Y_BUTTON_LINE = 1;


    /// <summary>
    /// Posizione in Y relativa al posizionamento iniziale per il contenuto di pagina corrente
    /// </summary>
    private int Y_CONTENT_START = 3;
    
    
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
    /// Ordine della pagina per il contesto corrente
    /// </summary>
    public int PageContextEnum { get; protected set; }

    #endregion


    #region VARIABILI PER LA PARTENZA CONTENUTO CORRENTE 

    private int StartingContent_Y { get; set; }

    #endregion


    #region BUTTON EXIT E RESIZE

    /// <summary>
    /// Azione di exit attiva su tutte le pagine: questa azione deve essere sempre attiva in quanto 
    /// la pagina è in fullscreen mode 
    /// </summary>
    private Button _btnExit { get; set; }


    /// <summary>
    /// Azione di resize attiva su tutte le pagine: questa azione deve essere sempre attiva in quanto 
    /// la pagina è in fullscreen mode 
    /// </summary>
    private Button _btnResize { get; set; }


    /// <summary>
    /// Colore di base per i comandi statici e sempre attivi sulla pagina corrente 
    /// </summary>
    private ColorScheme COLORSCHEME_BASE = Colors.TopLevel;
    
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
          Y = Y_CONTENT_START,
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
      //_descriptionView.Y = Pos.Bottom(_labelDescriptionExample) + 1;
      // salvataggio della variabile per la partenza del contenuto corrente 
      StartingContent_Y = numLines;
    }


    /// <summary>
    /// Ottengo la scrollbarview per posizionare il testo nel contesto corrente 
    /// questo sia che adotti una singola label (il metodo direttamente qui sotto) sia che venga adottata una lista 
    /// in visualizzazione evidenziata per tutto il testo corrente 
    /// NB: la grandezza finale del testo che viene scrollato deve essere passato come input per evitare di avere dei tagli 
    /// </summary>
    /// <param name="finalHeight"></param>
    /// <returns></returns>
    private ScrollView GetTextDescriptionContainer(int finalHeight)
    {
      int finalPosY = (_labelDescriptionExample.Visible == false) ? Y_CONTENT_START : StartingContent_Y + 7;
      var scrollView = new ScrollView(new Rect(2, finalPosY,
        Constants.WIN_SCREEN_WIDTH - 6,
        Constants.WIN_SCREEN_HEIGHT - 10))
      {
        ContentSize = new Size(Constants.WIN_SCREEN_WIDTH - 7, finalHeight + 1),
        //ContentOffset = new Point (0, 0),
        ShowVerticalScrollIndicator = true,
        ShowHorizontalScrollIndicator = false,
        
      };
      return scrollView;
    }


    /// <summary>
    /// Impostazione del testo per la descrizione corrente
    /// questo testo utilizza una sola label per la sua combinazione finale 
    /// </summary>
    /// <param name="colorScheme"></param>
    private void CreateDescriptionText(ColorScheme colorScheme)
    {

      // testo di descrizione 
      if (_descriptionView == null)
        _descriptionView = new Label()
        {
          Width = Dim.Fill() - 10,
          Height = Dim.Fill() - 10,
          X = 0,
          Y = 0,
          ColorScheme = colorScheme,
          Visible = true
        };
      else
        _descriptionView.ColorScheme = colorScheme; // cambio solo lo stile 
      // inserimento del testo corrente nel contesto della scrollbar view 
      
    }


    /// <summary>
    /// Definizione alternativa data rispetto alla precedente per il draw del blocco 
    /// se infatti viene trovato l'esempio viene eseguito il draw a blocchi per evidenziare eventualmente la presenza di
    /// aggiunte rispetto alle definizioni iniziali del codice 
    /// NB: questo modo di disgnare i blocchi lo utilizzo solo se effettivamente ci sono delle lines per cui ha senso avedere una evidenziatura 
    /// altrimenti utilizzo l'altro (vedere la pagina di esempio)
    /// </summary>
    /// <param name="sampleLines"></param>
    /// <param name="markedLines"></param>
    protected void DrawTextBlockShowedExample(List<string> sampleLines, List<int[]> markedLines)
    {
      // devo disattivare la description view del contesto precedente 
      _descriptionView.Visible = false;
      // recupero della lista di textview da inserire per il contesto corrente. Punto di partenza: dove avevo disattivato il precedente controllo
      List<Label> currTextViews = ServiceLocator.GetPrintExampleService.GetTextViewCorrectExample(
        sampleLines,
        markedLines,
        0,
        0,
        out int finalLinesCounter);

      _scrollViewContainer = GetTextDescriptionContainer(finalLinesCounter);
      foreach (Label currTxtView in currTextViews)
        _scrollViewContainer.Add(currTxtView);
      _mainWindow.Add(_scrollViewContainer);
    }


    /// <summary>
    /// Impostazione del testo principale per la pagina corrente
    /// </summary>
    /// <param name="descriptionText"></param>
    /// <param name="dimension"></param>
    protected void SetDescriptionText(string descriptionText)
    {
      _descriptionView.Text = descriptionText;
      // impostazione della dimensione da attribuire al textblock 
      int numLines = descriptionText.Split('\n').Length;
      _descriptionView.Height = numLines + 1;
      _scrollViewContainer = GetTextDescriptionContainer(numLines + 1);
      _scrollViewContainer.Add(_descriptionView);
      _mainWindow.Add(_scrollViewContainer);
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
    /// Set dei buttons sempre attivi per la pagina corrente 
    /// questi comprendono il resize e l'uscita dall'applicazione in full screen
    /// NB: questa inizializzazione deve essere eseguita dopo aver effettivamente impostato le dimensioni per la main window
    /// </summary>
    private void SetBaseButtons()
    {
      if (_btnExit == null)
      {
        _btnExit = new Button()
        {
          X = Pos.Right(_mainWindow) - 15,
          Y = 0,
          Text = Resource.EXIT_BTN_TXT,
          ColorScheme = COLORSCHEME_BASE,
          Visible = true
        };
        // impostazione dell'azione di visualizzazione pagina successiva 
        _btnExit.Clicked += () => PerformExit();
        _mainWindow.Add(_btnExit);
      }
      if (_btnResize == null)
      {
        _btnResize = new Button()
        {
          X = Pos.Right(_mainWindow) - 30,
          Y = 0,
          Text = Resource.MINIMIZE_BTN_TXT,
          ColorScheme = COLORSCHEME_BASE,
          Visible = true
        };
        // impostazione dell'azione di visualizzazione pagina successiva 
        _btnResize.Clicked += () => PerformResize();
        _mainWindow.Add(_btnResize);
      }
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
          X = 14,
          Y = Y_BUTTON_LINE,
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
          X = 4,
          Y = Y_BUTTON_LINE,
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
          Y = Y_BUTTON_LINE,
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
          X = 14,
          Y = Y_BUTTON_LINE,
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
          Y = Y_BUTTON_LINE,
          Text = Resource.DEMO_BTN_TXT,
          ColorScheme = colorScheme,
          Visible = false,
        };
        // impostazione azione di inovke parallel esecuzione di una seconda istanza di processo per la visualizzazione della live
        _showDemoPage.Clicked += () => InvokeParallelExeShowLiveDemo(viewBagBase.Design_PatternID, viewBagBase.DesignPatternName);
        _mainWindow.Add(_showDemoPage);
      }
      else
        _showDemoPage.ColorScheme = colorScheme;
      // impostazione button di forward description page 
      if (_forwardDescrButton == null)
      {
        _forwardDescrButton = new Button()
        {
          X = 14,
          Y = Y_BUTTON_LINE,
          Text = Resource.DSCR_BTN_TXT, // impostazione della label di visualizzazione descrizione 
          ColorScheme = ViewConsoleConstants.BUTTON_DESCR_COLORSCHEME,
          Visible = false
        };
        // impostazione dell'azione di visualizzazione pagina successiva 
        _forwardDescrButton.Clicked += () => ForwardDescriptionPage(viewBagBase.Design_PatternID, viewBagBase.DesignPatternContextEnum);
        _mainWindow.Add(_forwardDescrButton);
      }
      else
        _forwardDescrButton.ColorScheme = ViewConsoleConstants.BUTTON_DESCR_COLORSCHEME;
      // impostazione per button del counterexample 
      if (_wrongExampleButton == null)
      {
        _wrongExampleButton = new Button()
        {
          X = 64,
          Y = Y_BUTTON_LINE,
          Text = Resource.WRONG_EXAMPLE_BTN, // impostazione della label di visualizzazione descrizione 
          ColorScheme = colorScheme,
          Visible = false // di default questo button è disattivato: appena viene attivato viene lanciato il programma per il counterexample corrente 
        };
        // impostazione dell'azione di visualizzazione pagina successiva 
        _wrongExampleButton.Clicked += () => InvokeWrongExampleVisualizationCode(viewBagBase.WrongCodeClassID);
        _mainWindow.Add(_wrongExampleButton);
      }
      else
        _wrongExampleButton.ColorScheme = colorScheme;

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

    protected void Btn_WrongExample_Activation(bool activation)
    {
      _wrongExampleButton.Visible = activation;
    }


    protected void Btn_Main_Activation(bool activation)
    {
      _mainMenuButton.Visible = activation;
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
      SetBaseButtons();
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
        Y = Y_CONTENT_START,
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


    /// <summary>
    /// Invoke della seconda istanza di programma per la visualizzazione del live demo per il design pattern attuale 
    /// </summary>
    /// <param name="desPatternID"></param>
    /// <param name="desPatternName"></param>
    private void InvokeParallelExeShowLiveDemo(int desPatternID, string desPatternName)
    {
      // preparazione dei parametri per la seconda applicazione 
      string paramsDEMO = ServiceLocator.GetParallelExeService.GetDesPatternDemoPresentationExeParams(desPatternID, desPatternName);
      // richiamo servizio per launch seconda applicazione 
      ServiceLocator.GetParallelExeService.RunProcessAsAdmin(Constants.EXENAME, paramsDEMO);
    }


    /// <summary>
    /// Recupero di tutti i parametri relativi alla visualizzazione per l'esempio scorretto 
    /// </summary>
    /// <param name="wrongExampleID"></param>
    private void InvokeWrongExampleVisualizationCode(int wrongExampleID)
    {
      // recupero dei parametri per il counterexample attuale 
      string relativePathWrongExample = String.Empty;
      string nameWrongExample = String.Empty;
      if(ServiceLocator.GetContextSelectorService.GetWrongExampleClassRelativePathAndName(wrongExampleID, out relativePathWrongExample, out nameWrongExample))
      {
        // recupero del parametro da passare al programma nella nuova configurazione 
        string showWrongExampleParams = ServiceLocator.GetParallelExeService.GetWrongExamplePagePresentationExeParams(wrongExampleID, relativePathWrongExample, nameWrongExample);
        // richiamo il programma in questa nuova versione 
        ServiceLocator.GetParallelExeService.RunProcessAsAdmin(Constants.EXENAME, showWrongExampleParams);
      }
    }


    #region AZIONI DI EXIT E RESIZE

    /// <summary>
    /// Azione di exit per il contesto corrente 
    /// </summary>
    private void PerformExit()
    {
      // TODO: eventualmente chiedere conferma per l'uscita dall'applicazione corrente 
      // azione di uscita per il contesto corrente 
      ServiceLocator.GetContextSelectorService.ExitFromApplication();
    }


    

    /// <summary>
    /// Azione di resize per il contesto corrente 
    /// </summary>
    private void PerformResize()
    {
      // richiamo azione per il minimize
      ServiceLocator.GetContextSelectorService.MinimizeApplication();
    }

    #endregion



  }
}
