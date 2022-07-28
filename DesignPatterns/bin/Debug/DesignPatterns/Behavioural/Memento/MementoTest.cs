using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Terminal.Gui;

namespace DesignPatterns.DesignPatterns.Behavioural.Memento
{
  /// <summary>
  /// This is a console test application for testing the memento pattern
  /// </summary>
  public class MementoTest
  {
    #region MEMENTO ELEMENTS 

    /// <summary>
    /// Storing the different memento objects 
    /// </summary>
    private Caretaker _caretaker = new Caretaker();

    /// <summary>
    /// Getting rid of the Memento object 
    /// </summary>
    private Originator _originator = new Originator();

    #endregion
    
    #region TEXT CONSTANTS 

    /// <summary>
    /// Title for the window
    /// </summary>
    private const string PAGE_TITLE = "Memento Design Pattern Test";
    
    /// <summary>
    /// Alert message for displaying console events 
    /// </summary>
    private const string CONSOLE_EVENT_MSG = "Showing console events";

    #region BUTTONS TEXTS 

    private const string BUTTON_SAVE_TXT = "Save";

    private const string BUTTON_UNDO_TXT = "Undo";

    private const string BUTTON_REDO_TXT = "Redo";

    #endregion

    /// <summary>
    /// Instruction for the page usage 
    /// </summary>
    private const string PAGE_INSTRUCTIONS =
      @"MEMENTO DEMO INSTRUCTION: 
Write some text, when you fill ready press 'Save' to save it.
The text will not disappear, but you can enrich the text.
Press save how many times you want and concerning the other 2 buttons:
- Undo: if you want to come back to the previous wirtten state (the previous state)
- Redo: if you want to go forward in the written states.
When there are no backward or forward statements either, those buttons are disabled respectively";

    #endregion

    /// <summary>
    /// Index for the current displayed page
    /// </summary>
    private int _indexPage = -1;

    
    /// <summary>
    /// Top of the application using terminal GUI
    /// </summary>
    internal static Toplevel ApplicationTop;

    #region PAGE ELEMENTS 

    private Window _mainWindow { get; set; }
    
    internal Window MainWindow { get { return _mainWindow; } }
    
    private Label _windowTitle { get; set; }

    internal Label WindowTitle { get { return _windowTitle; } }
    
    private MenuBar _topMenu { get; set; }
    
    internal MenuBar TopMenu { get { return _topMenu; } }

    private TextView _someText;
    internal TextView SomeText { get { return _someText; } }
    
    /// <summary>
    /// Saving the current state 
    /// </summary>
    private Button _buttonSave { get; set; }
    internal Button ButtonSave { get { return _buttonSave; } }

    /// <summary>
    /// Button with the Undo action (coming back to the previous state)
    /// </summary>
    private Button _buttonUndo { get; set; }
    internal Button ButtonUndo { get { return _buttonUndo; } }

    /// <summary>
    /// Button with the Redo action (going forward to the next state)
    /// </summary>
    private Button _buttonRedo { get; set; }
    internal Button ButtonRedo { get { return _buttonRedo; } }

    /// <summary>
    /// Tells me if the instructions have been read
    /// </summary>
    private bool _instructionsRead = false;

    private Label _consoleLabel { get; set; }

    internal Label ConsoleLabel { get { return _consoleLabel; } }


    /// <summary>
    /// The memento which is currently displayed 
    /// </summary>
    private Memento _currMemento = null;

    /// <summary>
    /// Text block focused: it will be disabled after each command action 
    /// </summary>
    private bool _isSomeTextFocused = true;

    #endregion


    #region CONSTRUCTOR: RENDERING THE PAGE USING TERMINAL GUI

    public MementoTest()
    {
      // application context initialization
      Application.Init();
      InitComponents(); // intialization of the form component 
      ApplicationTop = Application.Top;
      ApplicationTop.Add(
       TopMenu, WindowTitle, MainWindow
       );
      CheckButtonsValidity();
      // avvio applicazione console corrente 
      Application.Run();
    }


    /// <summary>
    /// Initialization of the main graphical components 
    /// </summary>
    private void InitComponents()
    {
      // initialization of the MAIN WINDOW
      if (_mainWindow == null)
        _mainWindow = new Window()
        {
          X = 0,
          Y = 2,
          Width = Dim.Fill(),
          Height = Dim.Fill(),
          ColorScheme = Colors.Base
        };
      // intialization of the main label
      _windowTitle = new Label()
      {
        TextAlignment = TextAlignment.Centered,
        Width = Dim.Fill() - 1,
        Height = Dim.Fill(),
        X = 1,
        Y = 1,
        ColorScheme = Colors.TopLevel,
        Text = PAGE_TITLE
      };
      // initialization of the text field for editing the text 
      _someText = new TextView()
      {
        Width = Dim.Fill() - 2,
        Height = Dim.Fill() - 5,
        X = 1,
        Y = 1,
        ColorScheme = Colors.TopLevel,
        Text = PAGE_INSTRUCTIONS, // fixing the instruction when opeing the form 
      };
      // adding the console view for displaying the messages by the Originator 
      _consoleLabel = new Label()
      {
        Width = Dim.Fill() - 20,
        Height = 1,
        X = 1,
        Y = Pos.Bottom(_someText) + 1,
        ColorScheme = Colors.Error,
        Text = CONSOLE_EVENT_MSG
      };
      _mainWindow.Add(_consoleLabel);
      // actions for clearing the text of the instructions and starting with the pattern
      _someText.MouseClick += (Terminal.Gui.View.MouseEventArgs currAction) => 
      {
        ClearTextToWrite();
        CheckButtonSaveValidityMouseEvent();
        // focused text 
        _isSomeTextFocused = true;
      };
      _someText.KeyPress += (Terminal.Gui.View.KeyEventEventArgs currAction) => 
      {
        CheckButtonSaveValidityByKeyPressed(currAction.KeyEvent.Key.ToString());
        ClearTextToWrite();
      };
      _someText.KeyDown += (Terminal.Gui.View.KeyEventEventArgs currAction) => 
      {
        CheckButtonSaveValidityByKeyPressed(currAction.KeyEvent.Key.ToString());
        CheckButtonsValidity();
      };
      _mainWindow.Add(_someText);
      // initialization of the different buttons
      _buttonSave = new Button()
      {
        X = Pos.Right(_mainWindow) - 33,
        Y = Pos.Bottom(_someText) + 3,
        Text = BUTTON_SAVE_TXT,  
        ColorScheme = Colors.Menu,
        Enabled = false
      };
      _buttonSave.Clicked += () => ButtonSave_MementoAction();
      _mainWindow.Add(_buttonSave); 
      _buttonUndo = new Button()
      {
        X = Pos.Right(_buttonSave) + 2,
        Y = Pos.Bottom(_someText) + 3,
        Text = BUTTON_UNDO_TXT, 
        ColorScheme = Colors.Menu,
      };
      _buttonUndo.Clicked += () => ButtonUndo_MementoAction();
      _mainWindow.Add(_buttonUndo); 
      _buttonRedo = new Button()
      {
        X = Pos.Right(_buttonUndo) + 2,
        Y = Pos.Bottom(_someText) + 3,
        Text = BUTTON_REDO_TXT, 
        ColorScheme = Colors.Menu,
      };
      _buttonRedo.Clicked += () => ButtonRedo_MementoAction();
      _mainWindow.Add(_buttonRedo); 
    }

    #region BUTTONS ACTIONS 

    /// <summary>
    /// Action on button save 
    /// </summary>
    private void ButtonSave_MementoAction()
    {
      // setting for the current article by the originator 
      _originator.Set(_someText.Text.ToString());
      // new instance for the memento 
      Memento currArticle = _originator.StoreInMemento();
      // creating a new memento object 
      if (_indexPage == _caretaker.GetLastIndex())
      {
        // saving the memento to the Arraylist
        _caretaker.AddMemento(currArticle);
        // incrementing the index for the page 
        _indexPage++;
      }
      // index less than the last element: I'm modifying a previous memento
      else
      {
        // modifying the memento 
        _caretaker.SetMemento(_indexPage, currArticle);
      }

      // current memento for the page 
      _currMemento = currArticle;
      // setting the console message 
      _consoleLabel.Text = _originator.Message;
      // text not focused anymore
      _isSomeTextFocused = false;
      // update the state of buttons 
      CheckButtonsValidity();
    }


    /// <summary>
    /// Action on button undo 
    /// </summary>
    private void ButtonUndo_MementoAction()
    {
      // decrementing index button 
      _indexPage--;
      // getting the previous memento
      Memento currArticle = _caretaker.GetMemento(_indexPage);
      // inserting the text of the previous memento in the page 
      _someText.Text = _originator.RestoreFromMemento(currArticle);
      // setting the console message 
      _consoleLabel.Text = _originator.Message;
      // current memento for the page 
      _currMemento = currArticle;
      // text not focused anymore
      _isSomeTextFocused = false;
      CheckButtonsValidity();
    }


    /// <summary>
    /// Action on button redo
    /// </summary>
    private void ButtonRedo_MementoAction()
    {
      // incrementing index button 
      _indexPage++;
      // getting the next memento 
      Memento currArticle = _caretaker.GetMemento(_indexPage);
      // inserting the text of the next memento in the page 
      _someText.Text = _originator.RestoreFromMemento(currArticle);
      // setting the console message 
      _consoleLabel.Text = _originator.Message;
      // current memento for the page 
      _currMemento = currArticle;
      // text not focused anymore
      _isSomeTextFocused = false;
      CheckButtonsValidity();
    }

    /// <summary>
    /// When instructions are read the reader is ready to clear the text in console 
    /// for writing other text and starting with the demo 
    /// </summary>
    private void ClearTextToWrite()
    {
      // not effective action
      if (_instructionsRead)
        return;

      // resetting the text 
      _someText.Text = "";

      // setting the instruction read 
      _instructionsRead = true;

      // updating button visibility 
      CheckButtonsValidity();
    }


    /// <summary>
    /// Checking if the current character is an alphanumeric character or not 
    /// </summary>
    /// <param name="keyPressed"></param>
    private void CheckButtonSaveValidityByKeyPressed(string keyPressed)
    {
      // text view has to be focused 
      if (!_isSomeTextFocused)
        return;

      if (keyPressed == "Backspace" && _someText.Text.Length == 1)
        _buttonSave.Enabled = false;
      else if (Regex.IsMatch(keyPressed, "^[a-zA-Z0-9]*$") && keyPressed.Length == 1)
      {
        if(_currMemento != null)
          if (_currMemento.GetSavedArticle() == _someText.Text.ToString() + keyPressed)
            _buttonSave.Enabled = false;
          else
            _buttonSave.Enabled = true;
        else
          _buttonSave.Enabled = true;
      }
        
      else if (_currMemento != null)
        if (_someText.Text == _currMemento.GetSavedArticle())
          _buttonSave.Enabled = false;
    }
    

    /// <summary>
    /// Mouse event save button event 
    /// </summary>
    private void CheckButtonSaveValidityMouseEvent()
    {
      // button save: instructions not read
      if (!_instructionsRead || _someText.Text == "")
        _buttonSave.Enabled = false;
      else if (_currMemento != null)
        if (_someText.Text.ToString() == _currMemento.GetSavedArticle())
          _buttonSave.Enabled = false;
        else
          _buttonSave.Enabled = true;
    }


    /// <summary>
    /// Verify Buttons which are enabled or disabled for the current case
    /// </summary>
    private void CheckButtonsValidity()
    {
      if(_currMemento != null)
        if (_currMemento.GetSavedArticle() == _someText.Text.ToString())
          _buttonSave.Enabled = false;

      _buttonRedo.Enabled = true;
      _buttonUndo.Enabled = true;
      // disabling both buttons 
      if (_indexPage == -1)
      {
        _buttonRedo.Enabled = false;
        _buttonUndo.Enabled = false;
      }
      // disasbling the button undo
      else if(_indexPage == 0)
      {
        _buttonUndo.Enabled = false;
        if (_caretaker.GetLastIndex() == 0)
          _buttonRedo.Enabled = false;
      }
      // disabling the button redo
      else if (_indexPage == _caretaker.GetLastIndex())
        _buttonRedo.Enabled = false;
      
    }

    #endregion


    #endregion
  }
}
