using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Behavioural.Mediator
{
  public class Main_Mediator
  {
    public static void RunExample()
    {
      // instance of the mediator between the different clients 
      StockMediator nyse = new StockMediator();

      // first broker: it receives the instance of the mediator just created 
      GormanSlacks broker = new GormanSlacks(nyse);

      // second broker: it receives the instance of the mediator too
      JTPoorman broker2 = new JTPoorman(nyse);

      // sold offers of the first broker 
      broker.SaleOffer("MSFT", 100);
      broker.SaleOffer("GOOG", 50);

      // sold / bought offers of the second broker
      broker2.BuyOffer("MSFT", 100);
      broker2.SaleOffer("NRG", 10);

      // sold offers by the first broker
      broker.BuyOffer("NRF", 10);

      // getting all the set of the bought and sold offers 
      nyse.GetStockOfferings();
    }
  }
}
