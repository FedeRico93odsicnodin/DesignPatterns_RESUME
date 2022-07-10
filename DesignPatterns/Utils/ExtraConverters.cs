using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
  }
}
