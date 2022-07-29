using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DesignPatterns.Utils.Constants;

namespace DesignPatterns.Utils
{
  /// <summary>
  /// Servizi di conversione per casi particolari di implementazione 
  /// </summary>
  public class ExtraConverters
  {
    /// <summary>
    /// Permette di ottenere la lista delle diverse stringhe che sono state markate in un certo modo all'interno del campo db 
    /// serve alla grafica per capire quali linee evidenziare all'interno di un determinato contesto di visualizzazione 
    /// </summary>
    /// <param name="markedLinesString"></param>
    /// <returns></returns>
    public List<int[]> GetMarkedLines(string markedLinesString)
    {
      // lista in restituzione 
      List<int[]> currLinesToMark = new List<int[]>();
      try
      {
        // split iniziale della lista 
        List<string> splittedList = markedLinesString.Split(',').ToList();
        foreach(string splittedLines in splittedList)
        {
          // caso in cui abbia un range di linee da marcare 
          if(splittedLines.Trim().IndexOf("-") > 0)
          {
            string[] currNumbersRange = splittedLines.Trim().Split('-').ToArray();
            // array con dimensione diversa da 2: continuo
            if (currNumbersRange.Length != 2)
              continue;
            // numero uno: deve essere diverso da null
            if (String.IsNullOrEmpty(currNumbersRange[0].Trim()))
              continue;
            // numero 2: deve essere diverso da null
            if (String.IsNullOrEmpty(currNumbersRange[1].Trim()))
              continue;
            // provo a convertire per i 2 numeri
            int num1 = 0;
            int num2 = 1;
            // numero 1 non corrisponde ad un numero 
            if (!int.TryParse(currNumbersRange[0].Trim(), out num1))
              continue;
            // numero 2 non corrisponde ad un numver 
            if (!int.TryParse(currNumbersRange[1].Trim(), out num2))
              continue;
            // se numero 2 piu piccolo continuo
            if (num2 < num1)
              continue;
            // creazione dell'array finale -> il mark va dalla riga numero 1 alla riga numero 2
            int[] currRange = { num1, num2 };
            currLinesToMark.Add(currRange);
          }
          // caso in cui la linea sia unica 
          else
          {
            int num = 0;
            if (!int.TryParse(splittedLines.Trim(), out num)) // non ho la conversione da stringa a numero 
              continue;
            int[] currNum = { num };
            currLinesToMark.Add(currNum);
          }
        }
        // ritorno la lista preparata 
        return currLinesToMark;
      }
      // eventuale segnalazione di macnata conversione per la linea corrente (questo non è bloccante)
      catch(Exception e)
      {
        // TODO: eventuale mark per l'eccezione corrente in qualche modo (ad esempio su log da configurare)
        return new List<int[]>();
      }
    }


    /// <summary>
    /// Verifico che la riga corrente sia da marcare di un determinato colore o meno per il caso in analisi
    /// </summary>
    /// <param name="currLine"></param>
    /// <param name="currListLines"></param>
    /// <returns></returns>
    public bool CheckLineToMark(int currLine, List<int[]> currListLines)
    {
      // separazione delle righe per le currLines che hanno una sola entry da quelle che ne hanno 2
      List<int[]> onlyOneEntryLine = currListLines.Where(x => x.Length == 1).ToList();
      List<int[]> rangeLines = currListLines.Where(x => x.Length == 2).ToList();

      // verifica di presenza della riga corrente all'interno delle entry che hanno una sola posizione 
      if (onlyOneEntryLine.Where(x => x[0] == currLine).Count() > 0) return true;
      // verifica di presenza della riga corrente nel range indicato 
      if (rangeLines.Where(x => x[0] <= currLine && x[1] >= currLine).Count() > 0) return true;
      // per tutti gli altri casi ritorn false (non ho trovato la linea come da marcare di un determinato colore 
      return false;
    }


    /// <summary>
    /// Permette di ottenere la stringa completa di codice a partire dalla visualizzazione a livello di lista di tutte le stringhe 
    /// relative alla creazione del testo attuale 
    /// </summary>
    /// <param name="currTxtLines"></param>
    /// <returns></returns>
    public string GetTextCodeFromList(List<string> currTxtLines)
    {
      string finalTxt = String.Empty;
      foreach (string currString in currTxtLines)
        finalTxt += currString + Environment.NewLine;

      return finalTxt;
    }


    /// <summary>
    /// Preparazione del nome del pattern che deve essere passato alla procedura di demo o di esempio 
    /// come parametro di programma 
    /// </summary>
    /// <param name="patternName"></param>
    /// <returns></returns>
    public string PreparePatternNameForParams(string patternName)
    {
      // nessuna necessita di preparazione 
      if (patternName.IndexOf(" ") == -1)
        return patternName;

      patternName = patternName.Replace(" ", "_");
      return patternName;
    }


    /// <summary>
    /// Preparazione inversa per il pattern corrente dopo che è stato ottenuto come parametro per la procedura corrente 
    /// </summary>
    /// <param name="patternChangedName"></param>
    /// <returns></returns>
    public string RevertPatternNameAsInputParameter(string patternChangedName)
    {
      if (patternChangedName.IndexOf("_") == -1)
        return patternChangedName;

      patternChangedName = patternChangedName.Replace("_", " ");
      return patternChangedName;
    }


    /// <summary>
    /// Ottengo la modalità di accesso database per l'istanza corrente 
    /// questa determina la modalità di recupero delle informazioni disponibili
    /// NB: questa configurazione è bloccante nel caso in cui impostata sbagliata 
    /// </summary>
    /// <param name="instance"></param>
    /// <returns></returns>
    public DB_TYPE GetDBTypeCurrInstance(string instance)
    {
      // configurazione per un database di tipo access 
      if (instance.ToLower() == DB_TYPE.ACCESS.ToString().ToLower())
        return DB_TYPE.ACCESS;

      // configurazione per un database di tipo sql server 
      if (instance.ToLower() == DB_TYPE.SQL_SERVER.ToString().ToLower())
        return DB_TYPE.SQL_SERVER;

      return DB_TYPE.NOT_DEFINED;
    }
  }
}
