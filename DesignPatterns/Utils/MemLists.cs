using DesignPatterns.Model;
using DesignPatterns.ViewConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Utils
{
    /// <summary>
    /// Liste in memoria per i design patterns correnti e le loro descrizioni
    /// </summary>
    internal static class MemLists
    {
    #region OGGETTI DB

    /// <summary>
    /// Lista di tutti i design patterns per il contesto corrente
    /// </summary>
    public static List<DesignPattern> DesignPatterns { get; set; }


    /// <summary>
    /// Lista di tutte le descrizioni per i design patterns correnti 
    /// </summary>
    public static List<DesignPatternDescription> DesignPatterns_Descriptions { get; set; }


    /// <summary>
    /// Lista di tutti i tipi per i design patterns disponibili 
    /// </summary>
    public static List<DesignType> DesignPatterns_Types { get; set; }


    /// <summary>
    /// Tutte le descrizioni per le tipologie di design pattern e il contesto corrente
    /// </summary>
    public static List<DesignTypeDescription> DesignTypesDescriptions { get; set; }


    /// <summary>
    /// Tutti gli esempi per i design patterns correnti 
    /// </summary>
    public static List<DesignPatterns_Examples> DesignPatternsExamples { get; set; }


    public static List<DesignPattern_DEMOStep> DesignPattern_DEMOStep { get; set; }

    #endregion


    #region PAGINE DIVERSE VISUALIZZAZIONI

    /// <summary>
    /// Lista di tutte le pagine di view console che sono state istanziate con le diverse descrizioni
    /// disponibili
    /// </summary>
    public static List<GeneralPage> AllPagesViewConsole { get; set; }

    #endregion

  }
}
