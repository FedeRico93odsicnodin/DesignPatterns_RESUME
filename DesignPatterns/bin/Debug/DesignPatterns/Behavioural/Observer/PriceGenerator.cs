using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Behavioural.Observer
{
  public class PriceGenerator
  {
    private string _stock;

    /// <summary>
    /// Holding the reference to the stockgrabber object 
    /// </summary>
    private Subject _stockGrabber;

    /// <summary>
    /// Generator of new set of prices
    /// </summary>
    private Random _priceGenerator;


    public PriceGenerator(Subject stockGrabber, string newStock)
    {
      // store the reference to the stockgrabber object so 
      // I can make calls to its methods 
      this._stockGrabber = stockGrabber;

      _stock = newStock;

      this._priceGenerator = new Random();
      
    }


    /// <summary>
    /// Starting the thread for changing the different price for the current 
    /// context of observers
    /// </summary>
    public void StartPriceSell()
    {
      Thread t = new Thread(new ThreadStart(SetPrices));
      t.Start();
    }


    /// <summary>
    /// Setting the prices of the stock for a certain amount of time 
    /// </summary>
    public void SetPrices()
    {
      // this instruction for eventual new thread execution 
      Console.BackgroundColor = ConsoleColor.Black;
      // simulating the time for the generation of the new indicated price
      int timeForGeneration = _priceGenerator.Next(300, 2001);
      for(int i = 1; i <= 20; i++)
      {
        // the thread is generating the future price 
        Thread.Sleep(timeForGeneration);
        // generation of the number for the next price
        double nextDouble = _priceGenerator.NextDouble() + _priceGenerator.Next(100, 601);
        // rounding the number to be generated 
        nextDouble = Math.Round(nextDouble, 2);
        // advertising of the change of the price 
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("rand generation: new price '" + _stock + "' with the price " + nextDouble);
        Console.ForegroundColor = ConsoleColor.White;
        // notification to the clients (the observers) by the mean of the StockGrabber 
        switch(_stock)
        {
          case "IBM": { ((StockGrabber)_stockGrabber).SetIBMPrice(nextDouble); break; }
          case "AAPL": { ((StockGrabber)_stockGrabber).SetAAPLPrice(nextDouble); break; }
          case "GOOG": { ((StockGrabber)_stockGrabber).SetGOOGPrice(nextDouble); break; }
        }
      }
    }
  }
}
