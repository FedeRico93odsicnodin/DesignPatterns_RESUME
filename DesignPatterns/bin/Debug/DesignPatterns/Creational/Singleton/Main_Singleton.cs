using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Creational.Singleton
{
  public class Main_Singleton
  {
    public static void RunExample()
    {
      // assuming Singleton is created from student class 
      // we refer to the GetInstance property from the Singleton class 
      SingletonService fromStudent = SingletonService.GetInstanceSingleton;
      fromStudent.PrintDetails("From Student");

      // assuming Singleton is created from employee class 
      // we refer to the GetInstance property from the Singleton class 
      // (BUT: in this case the singleton was already created by the student before)
      SingletonService fromEmployee = SingletonService.GetInstanceSingleton;
      fromEmployee.PrintDetails("From Employee");
      
    }
  }
}
