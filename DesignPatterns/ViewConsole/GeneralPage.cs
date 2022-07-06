using DesignPatterns.Model.ViewModel;
using DesignPatterns.Properties;
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
  internal abstract class GeneralPage
  {
    #region IDENTIFICATIVI PER LA PAGINA CORRENTE 

    /// <summary>
    /// Finestra principale: la imposto per o
    /// </summary>
    private Window _mainMenu { get; set; }


    /// <summary>
    /// Titolo per la finestra corrente 
    /// </summary>
    private Label _windowTitle { get; set; }


    /// <summary>
    /// Descrizione per la pagina corrente
    /// </summary>
    private TextView _descriptionView { get; set; }


    /// <summary>
    /// Menu relativo alla pagina corrente 
    /// </summary>
    private MenuBar _topMenu { get; set; }


    /// <summary>
    /// Button per la pagina successiva 
    /// </summary>
    private Button _nextButton { get; set; }


    /// <summary>
    /// Button per la pagina precedente 
    /// </summary>
    private Button _prevButton { get; set; }


    /// <summary>
    /// Button per la pagina di main menu 
    /// </summary>
    private Button _mainMenuButton { get; set; }

    #endregion


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
    private void SetTitleLabel(ColorScheme colorScheme)
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
    /// Impostazione del testo per la descrizione corrente
    /// </summary>
    /// <param name="colorScheme"></param>
    private void SetDescriptionText(ColorScheme colorScheme)
    {
      if (_descriptionView == null)
        _descriptionView = new TextView()
        {
          Width = Dim.Fill() - 4,
          Height = Dim.Fill() - 4,
          X = 2,
          Y = 2,
          ColorScheme = colorScheme
        };
      else
        _descriptionView.ColorScheme = colorScheme; // cambio solo lo stile 
    }


    /// <summary>
    /// Impostazione della window per il contesto corrente
    /// </summary>
    /// <param name="colorScheme"></param>
    private void SetWindow(ColorScheme colorScheme)
    {
      if (_mainMenu == null)
        _mainMenu = new Window()
        {
          X = 0,
          Y = 2,
          Width = Dim.Fill(),
          Height = Dim.Fill(),
          ColorScheme = colorScheme
        };
      else
        _mainMenu.ColorScheme = colorScheme;

    }

    /// <summary>
    /// Permette l'impostazione dei buttons per l'interfaccia attuale 
    /// </summary>
    /// <param name="colorScheme"></param>
    private void SetButtons(ColorScheme colorScheme)
    {
      if (_nextButton == null)
        _nextButton = new Button()
        {
          X = 13,
          Y = 13,
          Text = Resource.NEXT_BTN_TXT,
          ColorScheme = colorScheme
        };
      else
        _nextButton.ColorScheme = colorScheme;
      if (_prevButton == null)
        _prevButton = new Button()
        {
          X = 13,
          Y = 5,
          Text = Resource.PREV_BTN_TXT,
          ColorScheme = colorScheme
        };
      else
        _prevButton.ColorScheme = colorScheme;
      if (_mainMenuButton == null)
        _mainMenuButton = new Button()
        {
          X = 2,
          Y = 2,
          Text = Resource.PREV_BTN_TXT,
          ColorScheme = colorScheme
        };
      else
        _mainMenuButton.ColorScheme = colorScheme;
    }

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
    private void SetPage(
      ColorScheme titleScheme, 
      ColorScheme winScheme, 
      ColorScheme btnScheme,
      ColorScheme txtColorScheme
      )
    {
      SetTitleLabel(titleScheme);
      SetWindow(winScheme);
      SetButtons(btnScheme);
      SetDescriptionText(txtColorScheme);
    }

    /// <summary>
    /// Set degli attributi relativi al name e alla descrizione per il design pattern corrente
    /// </summary>
    /// <param name="designPatternName"></param>
    /// <param name="designPatternDescription"></param>
    private void SetDesignPatternDescription(string designPatternName, string designPatternDescription)
    {
      _windowTitle.Text = designPatternName;
      _descriptionView.Text = designPatternDescription;
    }


    /// <summary>
    /// Identificatori per la pagina corrente
    /// </summary>
    /// <param name="IDDesignPattern"></param>
    /// <param name="IDDesignPatternDescription"></param>
    /// <param name="pageType"></param>
    /// <param name="pageEnumContext"></param>
    private void SetPageIdentifiers(
      int IDDesignPattern, 
      int IDDesignPatternDescription, 
      PAGE_TYPE pageType, 
      int pageEnumContext)
    {
      DesignPatternID = IDDesignPattern;
      DescriptionPatternID = IDDesignPatternDescription;
      PageType = pageType;
      PageContextEnum = pageEnumContext;
    }

    #endregion


    #region COSTRUTTORE + PARAMETRI DA CUSTOMIZZARE PER LE SOTTOCLASSI

    /// <summary>
    /// Costruttore: in base alla specializzazione eseguita viene specializzata 
    /// la costruzione della pagina attuale 
    /// </summary>
    /// <param name="viewParams"></param>
    protected GeneralPage()
    {
      // impostazione statica per il menu relativo al contesto corrente
      InitTopMenu();
      // impostazione per la finestra principale
      SetPage(ViewParams.Title_ColorScheme, ViewParams.Win_ColorScheme, ViewParams.Buttons_ColorScheme, ViewParams.Txt_ColorScheme);
      // impostazione dei valori per il nome e la descrizione da leggere sulla pagina corrente
      SetDesignPatternDescription(ViewParams.DesignPatternName, ViewParams.DesignPatternDescription);
      // impostazione per gli attributi identificativi della pagina rispetto al design pattern attuale 
      SetPageIdentifiers(ViewParams.Design_PatternID, ViewParams.DesignPatternDescriptionID, ViewParams.PageType, ViewParams.DesignPatternContextEnum);
    }

    /// <summary>
    /// Parametri relativi all'istanza attuale per l'interfaccia 
    /// </summary>
    protected DesPatternView ViewParams { get { return DefineParamValues(); } }

    
    /// <summary>
    /// Impostazione dei parametri per la finestra corrente da parte della sottoclasse
    /// </summary>
    /// <returns></returns>
    protected abstract DesPatternView DefineParamValues();
    
    #endregion

  }
}
