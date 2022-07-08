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
    /// Impostazione del testo per la descrizione corrente
    /// </summary>
    /// <param name="colorScheme"></param>
    private void CreateDescriptionText(ColorScheme colorScheme)
    {
      if (_descriptionView == null)
        _descriptionView = new TextView()
        {
          Width = Dim.Fill() - 4,
          Height = Dim.Fill() - 4,
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
          Y = 4,
          Text = Resource.NEXT_BTN_TXT,
          ColorScheme = colorScheme,
          Visible = true
        };
        _mainWindow.Add(_nextButton);
      }
      else
        _nextButton.ColorScheme = colorScheme;
      if (_prevButton == null)
      {
        _prevButton = new Button()
        {
          X = 13,
          Y = 5,
          Text = Resource.PREV_BTN_TXT,
          ColorScheme = colorScheme,
          Visible = true,
        };
        _mainWindow.Add(_prevButton);
      }
      else
        _prevButton.ColorScheme = colorScheme;
      if (_mainMenuButton == null)
      {
        _mainMenuButton = new Button()
        {
          X = 2,
          Y = 2,
          Text = Resource.PREV_BTN_TXT,
          ColorScheme = colorScheme,
          Visible = true,
        };
        _mainWindow.Add(_mainMenuButton);
      }
      else
        _mainMenuButton.ColorScheme = colorScheme;
      // eventuali button di esempio / demo 
      if(_showExamplePage == null)
      {
        _showExamplePage = new Button()
        {
          X = 13,
          Y = 20,
          Text = Resource.EXAMPLE_BTN_TXT,
          ColorScheme = colorScheme,
          Visible = false,
        };
        _mainWindow.Add(_showExamplePage);
      }
      else 
        _showExamplePage.ColorScheme = colorScheme;
      if (_showDemoPage == null)
      {
        _showDemoPage = new Button()
        {
          X = 13,
          Y = 20,
          Text = Resource.DEMO_BTN_TXT,
          ColorScheme = colorScheme,
          Visible = false,
        };
        _mainWindow.Add(_showDemoPage);
      }
      else
        _showDemoPage.ColorScheme = colorScheme;

    }

    #region MODIFICATORI DI VISIBILITA' PER I BUTTONS

    protected void Btn_Main_Activation(bool activation)
    {
      _mainMenuButton.Visible = activation;
    }

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
    /// </summary>
    /// <param name="pageTitle"></param>
    /// <param name="titleScheme"></param>
    /// <param name="winScheme"></param>
    /// <param name="btnScheme"></param>
    protected void SetPage(
      ColorScheme titleScheme, 
      ColorScheme winScheme, 
      ColorScheme btnScheme,
      ColorScheme txtColorScheme
      )
    {
      CreateTitleLabel(titleScheme);
      SetWindow(winScheme);
      SetButtons(btnScheme);
      CreateDescriptionText(txtColorScheme);
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

  }
}
