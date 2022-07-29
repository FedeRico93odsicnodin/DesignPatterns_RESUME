using DesignPatterns.DesignPatterns.Behavioural;
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
        case 1:
          {
            DesignPatternsSTEPS.Singleton_LiveDEMO();
            foundDesPattern = true;
            break;
          }
        case 2:
          {
            DesignPatternsSTEPS.Factory_LiveDEMO();
            foundDesPattern = true;
            break;
          }
        case 4:
          {
            DesignPatternsSTEPS.Builder_LiveDEMO();
            foundDesPattern = true;
            break;
          }
        case 5:
          {
            DesignPatternsSTEPS.Prototype_LiveDEMO();
            foundDesPattern = true;
            break;
          }
        case 6:
          {
            DesignPatternsSTEPS.Adapter_LiveDEMO();
            foundDesPattern = true;
            break;
          }
        case 7:
          {
            DesignPatternsSTEPS.Bridge_LiveDEMO();
            foundDesPattern = true;
            break;
          }
        case 8:
          {
            DesignPatternsSTEPS.Composite_LiveDEMO();
            foundDesPattern = true;
            break;
          }
        case 9:
          {
            DesignPatternsSTEPS.Strategy_LiveDEMO();
            foundDesPattern = true;
            break;
          }
        case 10:
          {
            DesignPatternsSTEPS.Chain_Of_Responsibility_LiveDEMO();
            foundDesPattern = true;
            break;
          }
        case 11:
          {
            DesignPatternsSTEPS.Command_LiveDEMO();
            foundDesPattern = true;
            break;
          }
        case 12:
          {
            DesignPatternsSTEPS.Decorator_LiveDEMO();
            foundDesPattern = true;
            break;
          }
        case 13:
          {
            DesignPatternsSTEPS.Facade_LiveDEMO();
            foundDesPattern = true;
            break;
          }
        case 14:
          {
            DesignPatternsSTEPS.FlyWeight_LiveDEMO();
            foundDesPattern = true;
            break;
          }
        case 15:
          {
            DesignPatternsSTEPS.Proxy_LiveDEMO();
            foundDesPattern = true;
            break;
          }
        case 16:
          {
            DesignPatternsSTEPS.Iterator_LiveDEMO();
            foundDesPattern = true;
            break;
          }
        case 17:
          {
            DesignPatternsSTEPS.Mediator_LiveDEMO();
            foundDesPattern = true;
            break;
          }
        case 18:
          {
            DesignPatternsSTEPS.Memento_LiveDEMO();
            foundDesPattern = true;
            break;
          }
        case 19:
          {
            DesignPatternsSTEPS.Observer_LiveDEMO();
            foundDesPattern = true;
            break;
          }
        case 20:
          {
            DesignPatternsSTEPS.State_LiveDEMO();
            foundDesPattern = true;
            break;
          }
                case 21:
                    {
                        DesignPatternsSTEPS.TemplateMethod_LiveDEMO();
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
