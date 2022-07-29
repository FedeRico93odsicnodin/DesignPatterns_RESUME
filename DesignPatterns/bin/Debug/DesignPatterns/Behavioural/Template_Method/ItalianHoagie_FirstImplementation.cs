using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Behavioural.Template_Method
{
  /// <summary>
  /// In this first implementation the sandwich is made standalone 
  /// there's the method for made it but in case in which there are more sandwiches
  /// a lot of code has to be duplicated for new cases 
  /// </summary>
  public class ItalianHoagie_FirstImplementation
  {
    private string[] _meatUsed = { "Salami", "Pepperoni", "Capicola Ham" };
    private string[] _cheeseUsed = { "Provolone" };
    private string[] _veggiesUsed = { "Lettuce", "Tomatoes", "Onions", "Sweet Peppers" };
    private string[] _condimentsUsed = { "Oil", "Vinegar" };


    public void MakeSandwich()
    {
      // all those methods are implemented and rest in the peremeter of this class
      CutBun();
      AddMeat();
      AddCheese();
      AddVegetables();
      AddCondiments();
      WrapTheHoagie();
      // they can't be adopted or be common to other classes of sandwiches
    }


    public void CutBun()
    {
      Console.WriteLine("The Hoagie is Cut");
    }


    public void AddMeat()
    {
      Console.WriteLine("Add Salami, Pepperoni and Capicola Ham");
    }


    public void AddCheese()
    {
      Console.WriteLine("Add Provolone");
    }


    public void AddVegetables()
    {
      Console.WriteLine("Add Lettuce, Tomatoes, Onions and Sweet Peppers");
    }


    public void AddCondiments()
    {
      Console.WriteLine("Add oil and vinegar");
    }


    public void WrapTheHoagie()
    {
      Console.WriteLine("Wrap the Hoagie");
    }
  }
}
