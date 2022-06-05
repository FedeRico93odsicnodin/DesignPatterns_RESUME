using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;

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
        public Window MainMenu { get; protected set; } 


        /// <summary>
        /// Titolo per la finestra corrente 
        /// </summary>
        public Label WindowTitle { get; protected set; }


        /// <summary>
        /// Menu relativo alla pagina corrente 
        /// </summary>
        public MenuBar TopMenu { get; protected set; }

        #endregion


        #region IDENTIFICATIVI PER IL DESIGN PATTERN CORRENTE 

        /// <summary>
        /// Valore per il design pattern corrente 
        /// </summary>
        public string DesignPatternName { get; protected set; }


        /// <summary>
        /// Identificativo per la pagina corrente 
        /// </summary>
        public int IDPage { get; protected set; }
        
        #endregion


        /// <summary>
        /// Costruttore in base agli elementi che vengono passati all'interno dei diversi contesti durante la costruzione della pagina 
        /// </summary>
        internal GeneralPage()
        {
            SetWindowDefault();
            SetLabelTitle("default");
            InitTopMenu();
        }


        /// <summary>
        /// Impostazione titolo per la finestra corrente 
        /// </summary>
        /// <param name="winTitle"></param>
        protected void SetLabelTitle(string winTitle)
        {
            // inizializzazione della label principale 
            WindowTitle = new Label()
            {
                Text = winTitle,
                TextAlignment = TextAlignment.Centered,
                Width = Dim.Fill() - 1,
                Height = Dim.Fill(),
                X = 1,
                Y = 1,

                ColorScheme = Colors.Dialog
            };
        }


        /// <summary>
        /// Impostazione finestra di default per il contesto corrente 
        /// </summary>
        protected void SetWindowDefault()
        {
            MainMenu = new Window()
            {
                X = 0,
                Y = 2,
                Width = Dim.Fill(),
                Height = Dim.Fill(),
                ColorScheme = Colors.Menu

            };
        }


        /// <summary>
        /// Impostazione del menu per la finestra corrente 
        /// </summary>
        protected void InitTopMenu()
        {
            var menu = new MenuBar();
            menu.Width = Dim.Fill();
            menu.Height = 50;
            menu.ColorScheme = Colors.TopLevel;

            TopMenu = menu;
        }


    }
}
