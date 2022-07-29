using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Behavioural.Visitor
{
    public interface Visitable
    {
        /*
         Allows the Visitor to pass the object so 
         the right operations occur on the right type of object 

            Accept() is passed the same visitor object 
            but then the method visit() is called using 
            the visitor object. The right version of visit()
            is called because of method overloading 
             */
        double Accept(Visitor visitor);
    }
}
