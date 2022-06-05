using DesignPatterns.ViewConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;

namespace DesignPatterns
{
  class Program
  {

        /// <summary>
        /// Selezione del contesto di top per l'applicazione corrente 
        /// </summary>
        private static Toplevel _applicationTop;

        



        static void Main(string[] args)
    {

            Application.Init();
            _applicationTop = Application.Top;

            // lettura delle configurazioni iniziali di programma 
            ServiceLocator.GetConfigurationsService.ReadConfigurations();

            // 
            //string designPatternSingleton = ServiceLocator.GetDesignPatternsService.GetSingletonService.DesignPatternName.ToString();

            GeneralPage currPageDefault = new GeneralPage();
            _applicationTop.Add(currPageDefault.TopMenu, currPageDefault.WindowTitle, currPageDefault.MainMenu);

            Application.Run();
        }
  }
}
