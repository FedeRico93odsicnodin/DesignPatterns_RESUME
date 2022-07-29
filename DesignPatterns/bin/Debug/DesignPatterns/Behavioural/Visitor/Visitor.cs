using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Behavioural.Visitor
{
    /// <summary>
    /// The visitor pattern is used when you have to perform 
    /// the same action on many objects of different types
    /// </summary>
    public interface Visitor
    {
        /*
         Created to automatically use the right code based on the Object sent 
         Method Overloading 
         */
        double Visit(Liquor liquorItem);

        double Visit(Tobacco tobaccoItem);

        double Visit(Necessity necessityItem);
    }
}
