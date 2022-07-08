using DesignPatterns.ViewConsole;
using DesignPatterns.ViewConsole.ConsolePageServices;
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




        static void Main(string[] args)
    {

            // inizializzazione dei contesti nei quali eseguire le diverse pagine 
            Application.Init();
            ViewConsoleConstants.ApplicationTop = Application.Top;

            // lettura delle configurazioni iniziali di programma 
            ServiceLocator.GetConfigurationsService.ReadConfigurations();

            // inserimento della pagina principale per il contesto corrente 
            ServiceLocator.GetContextSelectorService.LoadMainPage();
      
            // avvio applicazione console corrente 
            Application.Run();
    }
  }
}
