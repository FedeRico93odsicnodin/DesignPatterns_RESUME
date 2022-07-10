using DesignPatterns.Properties;
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
    public static object Constansts { get; private set; }




    /// <summary>
    /// args: se non viene passato nessun parametro viene attivata di default la modalità di visualizzazione design patterns 
    /// altrimenti viene abilitatata la modalità 
    /// </summary>
    /// <param name="args"></param>
    static void Main(string[] args)
    {

      try
      {
        // verifica per la modalità corrente di programma 
        int idDesPattern = 0;
        string nameDesPattern = String.Empty;
        // recupero modalità di esecuzione per il programma corrente 
        Utils.Constants.PROGRAM_CURR_MODE = ServiceLocator.GetConfigurationsService.GetProgramCurrExeType(args, out idDesPattern, out nameDesPattern);
        if (Utils.Constants.PROGRAM_CURR_MODE
          // modalita di presentazione per l'esecuzione corrente 
          == Utils.Constants.PROGRAM_MODES.PRESENTATION)
        {
          // inizializzazione dei contesti nei quali eseguire le diverse pagine 
          Application.Init();
          ViewConsoleConstants.ApplicationTop = Application.Top;

          // lettura delle configurazioni iniziali di programma (db)
          ServiceLocator.GetConfigurationsService.LoadDBParams();

          // impostazione delle pagine di programma 
          ServiceLocator.GetConfigurationsService.MakeViewsPresentationLayer();

          // inserimento della pagina principale per il contesto corrente 
          ServiceLocator.GetContextSelectorService.LoadMainPage();

          // avvio applicazione console corrente 
          Application.Run();
        }
        // lancio il programma per la modalità demo per il contesto corrente e i parametri specificati per il design pattern 
        // di cui si vuole visualizzare la demo 
        else if (Utils.Constants.PROGRAM_CURR_MODE == Utils.Constants.PROGRAM_MODES.CODE_DEMO)
        {
          // impostazione dei parametri constanti per ID e Nome design pattern demo attuale 
          Utils.Constants.DESPATTERN_DEMO_ID = idDesPattern;
          Utils.Constants.DESPATTERN_DEMO_DESCRIPTION = nameDesPattern;

          // lettura delle configurazioni iniziali ridotte di programma (db)
          ServiceLocator.GetConfigurationsService.LoadDBParams(true);

          // verifica validità per il design pattern corrente (deve essere presente nella lista dei design pattern recuperati ed essere configurata la live demo)
          ServiceLocator.GetDesignPatternsService.StartLiveDemo(idDesPattern, nameDesPattern);
        }
        // ECCEZIONE: non ho trovato nessuna modalità utile per il programma corrente 
        else
          throw new Exception(Resource.EXCEPTION_MAIN_NOMODEAPP);
 
      }
      catch(Exception e)
      {
        // display eccezione per il caso corrente 
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(
          ServiceLocator.GetConfigurationsService.PrepareMsgException(e.Message, e.StackTrace)
          );
        Console.ReadKey();
      }


    }
  }
}
