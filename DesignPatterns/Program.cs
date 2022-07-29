using DesignPatterns.Model;
using DesignPatterns.Properties;
using DesignPatterns.Utils;
using DesignPatterns.ViewConsole;
using DesignPatterns.ViewConsole.ConsolePageServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;
using static DesignPatterns.Utils.Configurations;

namespace DesignPatterns
{
  class Program
  {
    /// <summary>
    /// args: se non viene passato nessun parametro viene attivata di default la modalità di visualizzazione design patterns 
    /// altrimenti viene abilitatata la modalità 
    /// </summary>
    /// <param name="args"></param>
    static void Main(string[] args)
    {
      try
      {
        // lettura delle configurazioni iniziali dal file di configurazione 
        ServiceLocator.GetConfigurationsService.ReadConfigFile();
        // verifica per la modalità corrente di programma 
        int idAttribute = 0;
        string prop_1 = String.Empty;
        string prop_2 = String.Empty;
        // recupero modalità di esecuzione per il programma corrente 
        Utils.Constants.PROGRAM_CURR_MODE = ServiceLocator.GetConfigurationsService.GetProgramCurrExeType(args, out idAttribute, out prop_1, out prop_2);
        if (Utils.Constants.PROGRAM_CURR_MODE
          // modalita di presentazione per l'esecuzione corrente 
          == Utils.Constants.PROGRAM_MODES.PRESENTATION)
        {
          // impostazione del full screen mode 
          ServiceLocator.GetConfigurationsService.SetFullScreenMode();

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
          prop_1 = ServiceLocator.GetExtraConvertersService.RevertPatternNameAsInputParameter(prop_1); // riconverto gli spazi vuoti per il nome del pattern corrente 
          Utils.Constants.DESPATTERN_DEMO_ID = idAttribute;
          Utils.Constants.DESPATTERN_DEMO_DESCRIPTION = prop_1;

          // lettura delle configurazioni iniziali ridotte di programma (db)
          ServiceLocator.GetConfigurationsService.LoadDBParams(true);

          // lettura degli steps di demo per il design pattern corrente 
          ServiceLocator.GetConfigurationsService.LoadDesignPatternDEMOSteps(idAttribute);

          // verifica validità per il design pattern corrente (deve essere presente nella lista dei design pattern recuperati ed essere configurata la live demo)
          ServiceLocator.GetDesignPatternsService.StartLiveDemo(idAttribute, prop_1);
        }
        // programma chiamato nella fase di visualizzazione di un esempio scorretto per la classe corrente 
        else if(Utils.Constants.PROGRAM_CURR_MODE == Utils.Constants.PROGRAM_MODES.WRONG_EXAMPLE)
        {
          // carico tutti gli esempi dal DB 
          ServiceLocator.GetConfigurationsService.LoadExamplesFromDB();

          // verifico la presenza per l'esempio corrente e recupero l'oggetto che sto ricercando 
          DesignPatterns_Examples exampleFound = null;
          if (ServiceLocator.GetPrintExampleService.CheckWrongExamplePresence(idAttribute, prop_1, prop_2,
            out exampleFound))
          {
            // print dell'esempio per il caso corrente 
            ServiceLocator.GetPrintExampleService.PrintWrongExample_CONSOLE(exampleFound);
          }
          // print del messaggio standard di not found per il contesto corrente 
          else
            ServiceLocator.GetPrintExampleService.PrintWrongExample_NOTFOUNDMsg();
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
