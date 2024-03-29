﻿using DesignPatterns.Model;
using DesignPatterns.Properties;
using DesignPatterns.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;

namespace DesignPatterns.ViewConsole.ConsolePageServices
{
  /// <summary>
  /// Servizio per il print in console dei diversi esempi a disposizione 
  /// NB: questo servizio deve essere distinto tra il print relativo alla semplice console e quella che utilizza Gui
  /// </summary>
  internal class PrintExampleService
  {
    #region PRINTING DELL'ESEMPIO "SBAGLIATO"

    /// <summary>
    /// Permette di stabilire se l'esempio corrente è presente all'interno della base dati di partenza 
    /// in questo caso sto verificando per la presenza di un esempio sbagliato da mostrare a video
    /// </summary>
    /// <param name="exampleID"></param>
    /// <param name="classRelativePath"></param>
    /// <param name="className"></param>
    /// <param name="foundExample"></param>
    /// <returns></returns>
    internal bool CheckWrongExamplePresence(
      int exampleID, 
      string classRelativePath, 
      string className,
      out DesignPatterns_Examples foundExample)
    {
      foundExample = MemLists.DesignPatternsExamples.Where(x => x.ID == exampleID &&
      x.RelativePath_Example == classRelativePath && x.Name_Example == className).FirstOrDefault();
      if (foundExample == null)
        return false;
      return true;
    }


    /// <summary>
    /// Permette il print dell'esempio sulla normalissima console 
    /// </summary>
    /// <param name="foundExample"></param>
    internal void PrintWrongExample_CONSOLE(DesignPatterns_Examples foundExample)
    {
      // recupero delle righe per l'esempio corrente 
      List<string> GetLinesTEST = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, 
        foundExample.RelativePath_Example, 
        foundExample.Name_Example)).ToList();
      // contatore relativo alla riga corrente 
      int counterLine = 1;
      foreach(string lineText in GetLinesTEST)
      {
        // verifica del colore per la riga corrente 
        if(ServiceLocator.GetExtraConvertersService.CheckLineToMark(counterLine, foundExample.MarkedLines))
        {
          // impostazione del colore rosso per segnalare la riga come errata per il contesto corrente 
          Console.ForegroundColor = ConsoleColor.Red;
          Console.WriteLine(lineText);
        }
        else
        {
          // impostazione del colore corretto per la segnalazione di riga appropriata 
          Console.ForegroundColor = ConsoleColor.Cyan;
          Console.WriteLine(lineText);
        }
        // incremento numero per la riga corrente 
        counterLine++;
      }
      // imposto un paio di linee di spazio e imposto la lettura di un tasto per uscire da questa modalità
      Console.WriteLine("\n\n");
      Console.ReadKey();
    }


    /// <summary>
    /// Permette di disegnare il messaggio relativo al non aver trovato correttamente il file di esempio sbagliato per la pagina corrente 
    /// </summary>
    internal void PrintWrongExample_NOTFOUNDMsg()
    {
      Console.WriteLine(Resource.UNAVAILABLE_CODE); // impostazione del messaggio di non disponibilità per il codice corrente 
      // imposto un paio di linee di spazio e imposto la lettura di un tasto per uscire da questa modalità
      Console.WriteLine("\n\n");
      Console.ReadKey();
    }

    #endregion


    #region PRINTING DELL'ESEMPIO CORRETTO 

    /// <summary>
    /// Color scheme per il blocco di creazione corrente (nessuna nuova aggiunta rispetto ad un codice precedente)
    /// </summary>
    private ColorScheme colorSchemeNormalLevel = Colors.TopLevel;


    /// <summary>
    /// ColorScheme per i blocchi che sono stati aggiunti con la descrizione corrente 
    /// </summary>
    private ColorScheme colorSchemeAddedLevel = Colors.Error;


    /// <summary>
    /// Permette la creazione delle linee relative all'esempio corretto accodando diverse definizioni di TextView, 
    /// queste definizioni sono marcate differentemente a seconda delle linee che mi sto trovando a colorare e aggiunte 
    /// per l'esempio corrente 
    /// </summary>
    /// <param name="foundExample"></param>
    /// <param name="startingX"></param>
    /// <param name="startingY"></param>
    /// <returns></returns>
    internal List<Label> GetTextViewCorrectExample(List<string> sampleLines,
      List<int[]> sampleMarkedLines, 
      Pos startingX, 
      Pos startingY, 
      out int FinalLinesCounter)
    {
      // inizializzazione della lista di blocchi 
      List<Label> listBlocks = new List<Label>();
      // linee per l'esempio corrente recuperate da ViewModel
      List<string> GetLinesTEST = sampleLines;
      // contatore relativo alla riga corrente 
      int finalLinesCounter = 1;
      int currBlockLineCounter = 0; // blocco di linee corrente: mi serve per impostare l'altezza del blocco per il caso corrente 
      Label currBlockLine = new Label(); // blocco di linea corrente 
      string currTextBlock = String.Empty; // blocco di linee finale da aggiungere rispetto al contesto corrente 
      foreach (string lineText in GetLinesTEST)
      {
        // CASO 1: distinzione del caso in cui sto partendo (prima linea + definizione del blocco)
        if(lineText == GetLinesTEST.First())
        {
          if(ServiceLocator.GetExtraConvertersService.CheckLineToMark(finalLinesCounter, sampleMarkedLines))
          {
            currBlockLine = new Label()
            {
              Width = Dim.Fill() - 4,
              X = startingX,
              Y = startingY,
              ColorScheme = colorSchemeAddedLevel,
              Visible = true,
            };
            // incremento per il numero di righe correnti 
            currBlockLineCounter++;
            finalLinesCounter++;
            currTextBlock += lineText; // linea di blocco aggiunta per il blocco corrente 
          }
          else
          {
            currBlockLine = new Label()
            {
              Width = Dim.Fill() - 4,
              X = startingX,
              Y = startingY,
              ColorScheme = colorSchemeNormalLevel,
              Visible = true
            };
            // incremento per il numero di righe correnti 
            currBlockLineCounter++;
            finalLinesCounter++;
            currTextBlock += lineText; // linea di blocco aggiunta per il blocco corrente 
          }
        }
        // CASO 2: sto iterando dalla seconda riga in poi
        else
        {
          // CASO 2.1: non ho il cambio per il blocco corrente: continuo ad aggiungere le linee 
          if(
            // ho trovato un'altra linea aggiunta 
            (ServiceLocator.GetExtraConvertersService.CheckLineToMark(finalLinesCounter, sampleMarkedLines)
            && currBlockLine.ColorScheme == colorSchemeAddedLevel) 
            || 
            // ho trovato un'altra linea gia presente 
            (!ServiceLocator.GetExtraConvertersService.CheckLineToMark(finalLinesCounter, sampleMarkedLines)) 
            && currBlockLine.ColorScheme == colorSchemeNormalLevel
            )
          {
            // incremento per il numero di righe correnti 
            currBlockLineCounter++;
            finalLinesCounter++;
            currTextBlock += Environment.NewLine + lineText; // linea di blocco aggiunta per il blocco corrente 
          }
          // CASO 2.2: sto cambiando il blocco: devo aggiungere il blocco precedente al set della lista e passare alla nuova inizializzazione
          // caso nel quale passo ad un blocco di aggiunta 
          else if(ServiceLocator.GetExtraConvertersService.CheckLineToMark(finalLinesCounter, sampleMarkedLines)
            && currBlockLine.ColorScheme == colorSchemeNormalLevel)
          {
            // impostazione testo e altezza blocco corrente 
            currBlockLine.Text = currTextBlock;
            currBlockLine.Height = currBlockLineCounter;
            // inserimento del blocco corrente all'interno della lista 
            listBlocks.Add(currBlockLine);
            // re inizializzazioni per il testo corrente 
            currTextBlock = String.Empty;
            currBlockLineCounter = 1;
            // creazione del nuovo blocco 
            currBlockLine = new Label()
            {
              Width = Dim.Fill() - 4,
              X = startingX, // la X rimane sempre fissa allo startX
              Y = Pos.Bottom(listBlocks.Last()), // per la Y devo considerare il bottom dell'ultimo blocco che è stato aggiunto alla lista e + 1
              ColorScheme = colorSchemeAddedLevel,
              Visible = true,

            };
            // incremento per il numero di righe correnti 
            currBlockLineCounter++;
            finalLinesCounter++;
            currTextBlock += lineText ; // linea di blocco aggiunta per il blocco corrente 
          }
          // CASO 2.2 ma passo ad un blocco di testo gia presente 
          else if(!ServiceLocator.GetExtraConvertersService.CheckLineToMark(finalLinesCounter, sampleMarkedLines)
            && currBlockLine.ColorScheme == colorSchemeAddedLevel)
          {
            // impostazione testo e altezza blocco corrente 
            currBlockLine.Text = currTextBlock;
            currBlockLine.Height = currBlockLineCounter;
            // inserimento del blocco corrente all'interno della lista 
            listBlocks.Add(currBlockLine);
            // re inizializzazioni per il testo corrente 
            currTextBlock = String.Empty;
            currBlockLineCounter = 1;
            // creazione del nuovo blocco 
            currBlockLine = new Label()
            {
              Width = Dim.Fill() - 4,
              X = startingX, // la X rimane sempre fissa allo startX
              Y = Pos.Bottom(listBlocks.Last()), // per la Y devo considerare il bottom dell'ultimo blocco che è stato aggiunto alla lista e + 1
              ColorScheme = colorSchemeNormalLevel,
              Visible = true,
              
            };
            // incremento per il numero di righe correnti 
            currBlockLineCounter++;
            finalLinesCounter++;
            currTextBlock += lineText; // linea di blocco aggiunta per il blocco corrente 
          }

        }
        // aggiunta dell'ultimo blocco
        if(lineText == GetLinesTEST.Last())
        {
          currBlockLine.Text = currTextBlock;
          currBlockLine.Height = currBlockLineCounter;
          // inserimento del blocco corrente all'interno della lista 
          listBlocks.Add(currBlockLine);
        }
        
      }
      FinalLinesCounter = finalLinesCounter;
      // una volta creati correttamente tutti i blocchi ritorno la lista dei textview
      return listBlocks;
    }

    #endregion


    #region PRINTING PER IL CASO DI DEMO 

    /// <summary>
    /// Stampo in console il messaggio relativo allo step corrente in base alle specifiche 
    /// </summary>
    /// <param name="currStep"></param>
    /// <returns></returns>
    internal void DEMO_GetVisualConsoleElementForCase(DesignPattern_DEMOStep currStep)
    {
      Console.ForegroundColor = ConsoleColor.Yellow;
      Console.BackgroundColor = ConsoleColor.Black;
      Console.WriteLine(currStep.Description);
      if(currStep.See_Effect)
      {
        GetShowExamplePressKeyDescription();
      }
      else
      {
        GetStdPressKeyDescription();
      }
    }


    /// <summary>
    /// Print del codice associato allo step di demo corrente 
    /// </summary>
    /// <param name="currStep"></param>
    internal void DEMO_PrintAssociatedCodeLines(DesignPattern_DEMOStep currStep)
    {
      // recupero del testo associato allo step corrente 
      List<string> GetLinesTEST = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, currStep.Ref_File_RelativePath, currStep.Ref_File_Name)).ToList();
      // se la proprieta per File_Lines non è valorizzata allora stampo tutte le linee della lista 
      if(currStep.File_Lines == null)
      {
        PrintDEMOLines(GetLinesTEST);
      }
      else if(currStep.File_Lines.Count() == 0)
      {
        PrintDEMOLines(GetLinesTEST);
      }
      // recupero delle sole linee da mostrare per l'esempio corrente 
      List<string> linesToShow = GetLineToShowInDEMO(GetLinesTEST, currStep.File_Lines);
      PrintDEMOLines(linesToShow);
      if (currStep.See_Effect)
      {
        GetShowExamplePressKeyDescription();
      }
      else
      {
        GetStdPressKeyDescription();
      }
    }


    /// <summary>
    /// Recupero delle sole linee da mostrare all'interno del contesto corrente 
    /// </summary>
    /// <param name="allFileLines"></param>
    /// <param name="allFileLines"></param>
    /// <returns></returns>
    private List<string> GetLineToShowInDEMO(List<string> allFileLines, List<int[]> positions)
    {
      // recupero delle sole righe da mostrare per il contesto corrente 
      List<string> lineToShow = new List<string>();
      int currLineCounter = 1;
      foreach(string currLine in allFileLines)
      {
        if (ServiceLocator.GetExtraConvertersService.CheckLineToMark(currLineCounter, positions))
          lineToShow.Add(currLine);
        currLineCounter++;

      }
      return lineToShow;
    }


    /// <summary>
    /// Print effettivo per le linee di codice relative allo step di DEMO corrente 
    /// </summary>
    /// <param name="linesDEMO"></param>
    private void PrintDEMOLines(List<string> linesDEMO)
    {
      // impostazione dei colori per la console e il caso corrente 
      Console.ForegroundColor = ConsoleColor.Cyan;
      Console.BackgroundColor = ConsoleColor.DarkBlue;

      foreach (string demoLine in linesDEMO)
        Console.WriteLine(demoLine);
    }


    /// <summary>
    /// Permette di ottenere la colorazione standard per il press key console 
    /// </summary>
    private void GetStdPressKeyDescription()
    {
      GiveANewLineDefault();
      Console.ForegroundColor = ConsoleColor.DarkBlue;
      Console.BackgroundColor = ConsoleColor.White;
      Console.WriteLine(Resource.DEMO_STANDARD_DESCRIPTION);
      Console.ReadKey();
      GiveANewLineDefault();
    }


    /// <summary>
    /// Permette di ottenere la colorazione per lo show example e il press key 
    /// </summary>
    private void GetShowExamplePressKeyDescription()
    {
      GiveANewLineDefault();
      Console.ForegroundColor = ConsoleColor.DarkGreen;
      Console.BackgroundColor = ConsoleColor.White;
      Console.WriteLine(Resource.DEMO_RUN_CODE);
      Console.ReadKey();
      GiveANewLineDefault();
    }


    /// <summary>
    /// Nuova linea di a capo con la colorazione standrd 
    /// </summary>
    private void GiveANewLineDefault()
    {
      Console.BackgroundColor = ConsoleColor.Black;
      Console.Write(Environment.NewLine);
    }


    /// <summary>
    /// Reset dei colori allo stadio iniziale per eseguire l'effettivo run dell'esempio
    /// </summary>
    internal void DEMO_ResetColorParameters()
    {
      Console.Write(Environment.NewLine);
      Console.BackgroundColor = ConsoleColor.Black;
      Console.ForegroundColor = ConsoleColor.White;
      Console.Write(Environment.NewLine);
    }


    /// <summary>
    /// Visualizzazione del comando di uscita 
    /// </summary>
    internal void DEMO_ShowExitLabel()
    {
      GiveANewLineDefault();
      Console.ForegroundColor = ConsoleColor.Black;
      Console.BackgroundColor = ConsoleColor.White;
      Console.WriteLine(Resource.DEMO_EXIT);
      Console.ReadKey();
      GiveANewLineDefault();
    }

    #endregion
  }
}
