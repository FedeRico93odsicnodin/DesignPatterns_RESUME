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
        #region PARAMETRI DI INPUT 

        /// <summary>
        /// Proprieta di input corrispondente ad un ID per il design pattern corrente 
        /// </summary>
        private static int _idAttribute = 0;


        /// <summary>
        /// Proprieta di input per il nome design pattern corrispondente 
        /// </summary>
        private static string _prop_1 = String.Empty;


        /// <summary>
        /// Proprieta di input per la classe corrispondente all'esempio sbagliato corrente 
        /// </summary>
        private static string _prop_2 = String.Empty;


        #endregion



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
        _idAttribute = 0;
        _prop_1 = String.Empty;
        _prop_2 = String.Empty;

                // se non ho passato nessun input devo avviare la modalità di presentazione 
                if (args == null)
                    RunPresentationMode();

                else if(args.Length == 0)
                    RunPresentationMode();

                // ricavo i parametri di input per il caso corrente 
                else
                {
                    // recupero modalità di esecuzione per il programma corrente 
                    Utils.Constants.PROGRAM_CURR_MODE = ServiceLocator.GetConfigurationsService.GetProgramCurrExeType(args, out _idAttribute, out _prop_1, out _prop_2);
                    if (Utils.Constants.PROGRAM_CURR_MODE
                      // modalita di presentazione per l'esecuzione corrente 
                      == Utils.Constants.PROGRAM_MODES.PRESENTATION)
                        RunPresentationMode(); // avvio della modalita di presentazione 

                    // lancio il programma per la modalità demo per il contesto corrente e i parametri specificati per il design pattern 
                    // di cui si vuole visualizzare la demo 
                    else if (Utils.Constants.PROGRAM_CURR_MODE == Utils.Constants.PROGRAM_MODES.CODE_DEMO)
                        RunDemoMode();
                    
                    // programma chiamato nella fase di visualizzazione di un esempio scorretto per la classe corrente 
                    else if (Utils.Constants.PROGRAM_CURR_MODE == Utils.Constants.PROGRAM_MODES.WRONG_EXAMPLE)
                        RunWrongExampleMode();

                    // ECCEZIONE: non ho trovato nessuna modalità utile per il programma corrente 
                    else
                        throw new Exception(Resource.EXCEPTION_MAIN_NOMODEAPP);
                }


       
 
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


        #region SUDDIVISIONE DELLE DIVERSE MODALITA' DI AVVIO PER L'APPLICAZIONE 

        /// <summary>
        /// Permette di avviare l'applicazione in un contesto normale di presentazione 
        /// quindi sia nel caso la stringa di input sia correttamente parametrizzata, sia con doppio click per 
        /// l'applicazione exe corrente 
        /// </summary>
        private static void RunPresentationMode()
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

        /// <summary>
        /// Avvio della modalita di demo per il caso corrente 
        /// </summary>
        private static void RunDemoMode()
        {
            // impostazione dei parametri constanti per ID e Nome design pattern demo attuale 
            _prop_1 = ServiceLocator.GetExtraConvertersService.RevertPatternNameAsInputParameter(_prop_1); // riconverto gli spazi vuoti per il nome del pattern corrente 
            Utils.Constants.DESPATTERN_DEMO_ID = _idAttribute;
            Utils.Constants.DESPATTERN_DEMO_DESCRIPTION = _prop_1;

            // lettura delle configurazioni iniziali ridotte di programma (db)
            ServiceLocator.GetConfigurationsService.LoadDBParams(true);

            // lettura degli steps di demo per il design pattern corrente 
            ServiceLocator.GetConfigurationsService.LoadDesignPatternDEMOSteps(_idAttribute);

            // verifica validità per il design pattern corrente (deve essere presente nella lista dei design pattern recuperati ed essere configurata la live demo)
            ServiceLocator.GetDesignPatternsService.StartLiveDemo(_idAttribute, _prop_1);
        }

        /// <summary>
        /// Avvio modalita per esempio sbagliato di codice per il caso corrente 
        /// </summary>
        private static void RunWrongExampleMode()
        {
            // carico tutti gli esempi dal DB 
            ServiceLocator.GetConfigurationsService.LoadExamplesFromDB();

            // verifico la presenza per l'esempio corrente e recupero l'oggetto che sto ricercando 
            DesignPatterns_Examples exampleFound = null;
            if (ServiceLocator.GetPrintExampleService.CheckWrongExamplePresence(_idAttribute, _prop_1, _prop_2,
              out exampleFound))
            {
                // print dell'esempio per il caso corrente 
                ServiceLocator.GetPrintExampleService.PrintWrongExample_CONSOLE(exampleFound);
            }
            // print del messaggio standard di not found per il contesto corrente 
            else
                ServiceLocator.GetPrintExampleService.PrintWrongExample_NOTFOUNDMsg();
        }


        #endregion

    }
}
