﻿using DesignPatterns.Model;
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
        /// <summary>
        /// Lista di tutti i design patterns per il contesto corrente
        /// </summary>
        internal static List<DesignPattern> DesignPatterns { get; set; }


        /// <summary>
        /// Lista di tutte le descrizioni per i design patterns correnti 
        /// </summary>
        internal static List<DesignPatternDescription> DesignPatterns_Descriptions { get; set; }


        /// <summary>
        /// Lista di tutti i tipi per i design patterns disponibili 
        /// </summary>
        internal static List<DesignType> DesignPatterns_Types { get; set; }
    }
}
