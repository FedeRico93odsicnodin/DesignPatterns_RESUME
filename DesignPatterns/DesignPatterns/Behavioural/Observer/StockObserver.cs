using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Behavioural.Observer
{
  /// <summary>
  /// Represents each Observer that is monitoring changes in the subject
  /// </summary>
  public class StockObserver : Observer
  {
    private double _ibmPrice;
    private double _aaplPrice;
    private double _googPrice;

    /// <summary>
    /// Static used as a counter 
    /// </summary>
    private static int _observerIDTracker = 0;
    
    /// <summary>
    /// Used to track the observer 
    /// </summary>
    private int _observerID;

    /// <summary>
    /// Will hold reference to the StockGrabber object 
    /// </summary>
    private Subject _stockGrabber;


    public StockObserver(Subject stockGrabber)
    {
      // store the reference to the stockGrabber objet so 
      // I can make calls to its methods 
      this._stockGrabber = stockGrabber;

      // assign an observer ID and increment the static counter 
      this._observerID = ++_observerIDTracker;

      // Message notifies user of a new observer 
      Console.WriteLine("New observer " + this._observerID);

      // add the observer to the Subjects Arraylist 
      stockGrabber.Register(this);
    }


    public void Update(double ibmPrice, double applPrice, double googPrice)
    {
      this._ibmPrice = ibmPrice;
      this._aaplPrice = applPrice;
      this._googPrice = googPrice;

      PrintThePrices();
    }


    public void PrintThePrices()
    {
      Console.WriteLine(_observerID + "\nIBM: " + _ibmPrice + "\nAAPL: " + _aaplPrice + "\nGOOG: " + _googPrice + "\n");
    }
  }
}
