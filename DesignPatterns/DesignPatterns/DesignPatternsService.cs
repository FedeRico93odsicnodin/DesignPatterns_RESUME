using DesignPatterns.DesignPatterns.Creational;
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
        /// Singleton service 
        /// </summary>
        public SingletonService GetSingletonService
        {
            get
            {
                return SingletonService.GetInstanceSingleton;
            }
        }


        #endregion
    }
}
