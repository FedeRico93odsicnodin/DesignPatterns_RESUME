using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;

namespace DesignPatterns.DesignPatterns.Behavioural.Memento
{
  /// <summary>
  /// This is a console test application for testing the memento pattern
  /// </summary>
  public class MementoTest
  {
    #region TEXT CONSTANTS 

    /// <summary>
    /// Title for the window
    /// </summary>
    private const string PAGE_TITLE = "Memento Design Pattern Test";

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
      FrameView container = new FrameView()
      {
        Width = Dim.Fill() - 2,
        Height = Dim.Fill() - 5,
        X = 1,
        Y = 1,
        ColorScheme = Colors.Menu
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
      // actions for clearing the text of the instructions and starting with the pattern
      _someText.MouseClick += (Terminal.Gui.View.MouseEventArgs currAction) => { ClearTextToWrite(); };
      _someText.KeyPress += (Terminal.Gui.View.KeyEventEventArgs currAction) => { ClearTextToWrite(); };
      _mainWindow.Add(_someText);
      // initialization of the different buttons
      _buttonSave = new Button()
      {
        X = Pos.Right(_mainWindow) - 50,
        Y = Pos.Bottom(_someText) + 2,
        Text = BUTTON_SAVE_TXT,  
        ColorScheme = Colors.Menu,
      };
      _buttonSave.Clicked += () => ButtonSave_MementoAction();
      _mainWindow.Add(_buttonSave); 
      _buttonUndo = new Button()
      {
        X = Pos.Right(_buttonSave) + 2,
        Y = Pos.Bottom(_someText) + 2,
        Text = BUTTON_UNDO_TXT, 
        ColorScheme = Colors.Menu,
      };
      _buttonUndo.Clicked += () => ButtonUndo_MementoAction();
      _mainWindow.Add(_buttonUndo); 
      _buttonRedo = new Button()
      {
        X = Pos.Right(_buttonUndo) + 2,
        Y = Pos.Bottom(_someText) + 2,
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
      // TODO: implementation for this action 
    }


    /// <summary>
    /// Action on button undo 
    /// </summary>
    private void ButtonUndo_MementoAction()
    {
      // TODO: implementation 
    }


    /// <summary>
    /// Action on button redo
    /// </summary>
    private void ButtonRedo_MementoAction()
    {
      // TODO: implementation 
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
    }

    #endregion


    #endregion
  }
}
