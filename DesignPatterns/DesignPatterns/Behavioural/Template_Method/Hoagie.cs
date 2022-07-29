using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Behavioural.Template_Method
{
  /// <summary>
  /// A template method pattern contains a method that provides the steps 
  /// of the algorithm. It allows subclasses to override some of the methods 
  /// </summary>
  public abstract class Hoagie
  {
    private bool _afterFirstCondiment = false;

    /// <summary>
    /// This method is general to all the sandwiches and cannot be overridden 
    /// </summary>
     public void MakeSandwich()
    {
      CutBun();

      if(CustomerWantsMeat())
      {
        AddMeat();
        // handling new lines for spaces 
        _afterFirstCondiment = true;
      }
      if(CustomerWantsCheese())
      {
        if(_afterFirstCondiment) { Console.Write("\n"); }
        AddCheese();
        _afterFirstCondiment = true;
      }
      if(CustomerWantsVegetables())
      {
        if (_afterFirstCondiment) { Console.Write("\n"); }
        AddVegetables();
        _afterFirstCondiment = true;
      }
      if (CustomerWantsCondiments())
      {
        if (_afterFirstCondiment) { Console.Write("\n"); }
        AddCondiments();
        _afterFirstCondiment = true;
      }

      WrapTheHoagie();
    }

    #region STANDARD METHODS FOR ALL THE SANDWICHES: THEY CANNOT BE OVERRIDDEN

    /// <summary>
    /// Also this methods are a "standard" for all the possible sandwiches
    /// </summary>
    public void CutBun()
    {
      Console.WriteLine("The Hoagie is cut");
    }
    public void WrapTheHoagie()
    {
      Console.WriteLine("Wrap the Hoagie");
    }
    public void AfterFirstCondiment()
    {
      Console.WriteLine("\n");
    }

    #endregion


    #region ABSTRACT METHODS TO BE OVERRIDDEN AND IMPLEMENTED DEPENDING ON HOAGIE

    public abstract void AddMeat();

    public abstract void AddCheese();

    public abstract void AddVegetables();

    public abstract void AddCondiments();

    #endregion


    #region VIRTUAL METHODS: THEY CAN BE OVERRIDDEN DEPENDING ON THE HOAGIE

    public virtual bool CustomerWantsMeat() { return true; }

    public virtual bool CustomerWantsCheese() { return true; }

    public virtual bool CustomerWantsVegetables() { return true; }

    public virtual bool CustomerWantsCondiments() { return true; }

    #endregion
  }
}
