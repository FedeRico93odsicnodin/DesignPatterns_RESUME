using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Utils
{
  /// <summary>
  /// In questa classe sono esposti tutti i servizi per l'esecuzione multipla degli esempi
  /// questa esecuzione si appoggia sempre sul progetto attuale ma avviato in una seconda configurazione che permette 
  /// l'effettivo lancio dell'applicazione 
  /// </summary>
  internal class ParallelExe
  {
    /// <summary>
    /// Metodo di esempio trovato al seguente link: 
    /// https://stackoverflow.com/questions/37592483/execute-another-exe-from-an-application-with-parameters-as-admin
    /// questo metodo deve servirmi per lanciare di nuovo l'applicazione con una seconda configurazione che mi devo trovare 
    /// </summary>
    /// <param name="exeName"></param>
    /// <param name="parameters"></param>
    /// <returns></returns>
    public int RunProcessAsAdmin(string exeName, string parameters)
    {
      try
      {
        System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
        startInfo.UseShellExecute = true;
        startInfo.FileName = exeName; // l'eseguibile è nello stesso percorso dell'eseguibile originale 
        startInfo.Verb = "runas";
        //MLHIDE
        startInfo.Arguments = parameters;
        startInfo.ErrorDialog = true;
        Process process = System.Diagnostics.Process.Start(startInfo);
        process.WaitForExit();
        return process.ExitCode;
      }
      catch (Win32Exception ex)
      {
        switch (ex.NativeErrorCode)
        {
          case 1223:
            return ex.NativeErrorCode;
          default:
            return 0;
        }

      }
      catch (Exception ex)
      {
        //WriteLog(ex);
        return 0;
      }
    }

    /* per aspettare il termine esecuzione dovrebbe bastare : 
     var process = Process.Start(...);
      process.WaitForExit();
      pero conviene anche disattivare la finestra principale nel mentre
     
     */


      /// <summary>
      /// Permette di ottenere i parametri relativi al launch della seconda istanza di programma per il layer di demo 
      /// per il design pattern corrente 
      /// </summary>
      /// <param name="desPatternID"></param>
      /// <param name="desPatternName"></param>
      /// <returns></returns>
    internal string GetDesPatternDemoPresentationExeParams(int desPatternID, string desPatternName)
    {
      // ritorno direttamente la stringa che deve essere passata come parametro per il design pattern attuale 
      return Constants.PROGRAM_MODES.CODE_DEMO.ToString() + " " + desPatternID + " " + desPatternName;
    }
  }
}
