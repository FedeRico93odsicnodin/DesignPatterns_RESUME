using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Behavioural.Observer
{
  public class StockGrabber : Subject
  {
    private ArrayList _observers;
    private double _ibmPrice;
    private double _aaplPrice;
    private double _googPrice;

    public StockGrabber()
    {
      _observers = new ArrayList();
    }
    
    /// <summary>
    /// Cycling through all observers and notifies them of price changes 
    /// </summary>
    public void NotifyObserver()
    {
      foreach (Observer obs in _observers)
        obs.Update(_ibmPrice, _aaplPrice, _googPrice);
    }

    /// <summary>
    /// Adding a new observer to be notified inside the arraylist 
    /// </summary>
    /// <param name="o"></param>
    public void Register(Observer o)
    {
      _observers.Add(o);
      Console.WriteLine("an observer is registered");
    }


    /// <summary>
    /// Removing an existing observer from the arraylist 
    /// this observer will not be notified anymore
    /// </summary>
    /// <param name="o"></param>
    public void Unregister(Observer o)
    {
      _observers.Remove(o);
      Console.WriteLine("an observer is unregistered");
    }


    // Change prices for all stocks and notifies observers of changes 
    public void SetIBMPrice(double newIBMPrice)
    {
      this._ibmPrice = newIBMPrice;
      NotifyObserver();
    }

    public void SetAAPLPrice(double newAAPLPrice)
    {
      this._aaplPrice = newAAPLPrice;
      NotifyObserver();
    }

    public void SetGOOGPrice(double newGOOGPrice)
    {
      this._googPrice = newGOOGPrice;
      NotifyObserver();
    }
  }
}
