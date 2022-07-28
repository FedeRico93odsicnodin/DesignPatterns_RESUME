using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Behavioural.Observer
{
  public class Main_Observer
  {
    public static void RunExample()
    {
      // Create the Subject object 
      // it will handle updating all observers 
      // all well as deleting and adding them
      StockGrabber stockGrabber = new StockGrabber();

      // Create an Observer that will be sent updates from Subject 
      StockObserver observer1 = new StockObserver(stockGrabber);

      // setting a first set of prices by the stockgrabber 
      stockGrabber.SetIBMPrice(197);
      stockGrabber.SetAAPLPrice(677.60);
      stockGrabber.SetGOOGPrice(676.40);

      // Create a second Observer that will be sent updates from Subject 
      StockObserver observer2 = new StockObserver(stockGrabber);

      // setting a second set of prices by the stockgrabber 
      stockGrabber.SetIBMPrice(198);
      stockGrabber.SetAAPLPrice(777.60);
      stockGrabber.SetGOOGPrice(656.29);

      // delete one of the observers 
      stockGrabber.Unregister(observer2);

      // setting a third set of prices by the stockgrabber 
      stockGrabber.SetIBMPrice(200);
      stockGrabber.SetAAPLPrice(277.60);
      stockGrabber.SetGOOGPrice(622.34);
      
      // creating the random price generation services 
      PriceGenerator IBMPriceGeneration = new PriceGenerator(stockGrabber, "IBM");
      PriceGenerator AAPLPriceGeneration = new PriceGenerator(stockGrabber, "AAPL");
      PriceGenerator GOOGPriceGeneration = new PriceGenerator(stockGrabber, "GOOG");

      // starting the random generation services 
      IBMPriceGeneration.StartPriceSell();
      AAPLPriceGeneration.StartPriceSell();
      GOOGPriceGeneration.StartPriceSell();
      
    }
  }
}
