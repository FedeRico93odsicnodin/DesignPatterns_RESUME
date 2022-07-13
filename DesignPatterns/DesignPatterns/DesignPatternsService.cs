﻿using DesignPatterns.DesignPatterns.Behavioural;
using DesignPatterns.DesignPatterns.Behavioural.Strategy;
using DesignPatterns.DesignPatterns.Creational;
using DesignPatterns.Properties;
using DesignPatterns.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns
{
    /// <summary>
    /// Tutti i servizi relativi ai design patterns
    /// </summary>
    public class DesignPatternsService
    {
        #region CREATIONAL PATTERNS

    

    /// <summary>
    /// Partenza per la live demo del design pattern corrente in base alle specifiche passate 
    /// NB: deve essere stato configurato correttamente sia gli attributi per il design pattern (devono trovarsi nella base dati di partenza)
    /// che il metodo di partenza per il design pattern attuale 
    /// </summary>
    /// <param name="designPatternID"></param>
    /// <param name="designPatternName"></param>
    public void StartLiveDemo(int designPatternID, string designPatternName)
    {
      // eccezione se non trovo il design pattern nella lista configurata 
      if (MemLists.DesignPatterns.Where(x => x.ID == designPatternID && x.Name == designPatternName).Count() == 0)
        throw new Exception(
          String.Format(Resource.EXCEPTION_MISSING_DESPATTERN, designPatternID, designPatternName)
          );

      // switch per il metodo da eseguire 
      bool foundDesPattern = false;
      switch(designPatternID)
      {
        case 4:
          {
            DesignPatternsSTEPS.Builder_LiveDEMO();
            foundDesPattern = true;
            break;
          }
        case 6:
          {
            DesignPatternsSTEPS.Adapter_LiveDEMO();
            foundDesPattern = true;
            break;
          }
        case 9:
          {
            DesignPatternsSTEPS.Strategy_LiveDEMO();
            foundDesPattern = true;
            break;
          }
      }

      // se non ho trovato nessuna corrispondenza live allora esco con una eccezione 
      if (!foundDesPattern)
        throw new Exception(
          String.Format(Resource.EXEPTION_DEMO_NOTFOUND,
          designPatternID,
          designPatternName)
          );
    }


        #endregion
    }
}
