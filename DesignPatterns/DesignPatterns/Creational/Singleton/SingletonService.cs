using DesignPatterns.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DesignPatterns.Utils.Constants;

namespace DesignPatterns.DesignPatterns.Creational
{
    public sealed class SingletonService
    {

        private static int _counter = 0;
        private static SingletonService _istanceSingleton = null;
        /// <summary>
        /// Getter for the single instance of the class (which is sealed)
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
        /// Private constructor: not invokable from another class
        /// </summary>
        private SingletonService()
        {
          _counter++;
          Console.WriteLine("counter value " + _counter);
        }
        public void PrintDetails(string message)
        {
          Console.WriteLine(message);
        }
    }
}
