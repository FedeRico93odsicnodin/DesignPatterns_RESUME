using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Creational
{
    public sealed class SingletonService
    {
        private static SingletonService _istanceSingleton = null;


        /// <summary>
        /// Getter per una singola istanza di questa classe che è sealed rispetto alle proprieta reltive alla classe stessa 
        /// </summary>
        public static SingletonService GetInstanceSingleton
        {
            get
            {
                if (_istanceSingleton == null)
                    _istanceSingleton = new SingletonService();

                return _istanceSingleton;
            }
        }


        /// <summary>
        /// Costruttore privato: in modo da non avere la possibile istanza in un'altra classe 
        /// </summary>
        private SingletonService()
        {
        }
    }
}
