using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Behavioural.Mediator
{
  /// <summary>
  /// Rela implementation of the Mediator interface 
  /// </summary>
  public class StockMediator : Mediator
  {
    private ArrayList _colleagues;
    private ArrayList _stockBuyOffers;
    private ArrayList _stockSaleOffers;

    private int _colleagueCodes = 0;


    public StockMediator()
    {
      _colleagues = new ArrayList();
      _stockBuyOffers = new ArrayList();
      _stockSaleOffers = new ArrayList();
    }


    public void AddColleague(Colleague colleague)
    {
      _colleagues.Add(colleague);
      _colleagueCodes++;
      colleague.SetCollCode(_colleagueCodes);
    }

    public void SaleOfficer(string stock, int shares, int collCode)
    {
      bool stockSold = false;

      foreach(StockOffer offer in _stockBuyOffers)
      {
        if((offer.GetStockSymbol() == stock) && (offer.GetStockShares() == shares))
        {
          Console.WriteLine(shares + " shares of " + stock + " sold to colleague code " + offer.GetCollCode());

          _stockBuyOffers.Remove(offer);

          stockSold = true;
        }
        if (stockSold) break;

        if(!stockSold)
        {
          Console.WriteLine(shares + " shares of " + stock + " added to inventory");

          StockOffer newOffering = new StockOffer(shares, stock, collCode);

          _stockSaleOffers.Add(newOffering);
        }
      }
    }

    public void BuyOffer(string stock, int shares, int collCode)
    {
      bool stockBought = false;

      foreach(StockOffer offer in _stockSaleOffers)
      {
        if((offer.GetStockSymbol() == stock) && offer.GetStockShares() == shares)
        {
          Console.WriteLine(shares + " shares of " + stock + " bought by colleague code " + offer.GetCollCode());

          _stockSaleOffers.Remove(offer);

          stockBought = true;
        }
      }

      if(!stockBought)
      {
        Console.WriteLine(shares + " shares of " + stock + " added to inventory");

        StockOffer newOffering = new StockOffer(shares, stock, collCode);

        _stockBuyOffers.Add(newOffering);
      }
    }

    public void GetStockOfferings()
    {
      Console.WriteLine("Stocks for Sale");

      foreach(StockOffer offer in _stockSaleOffers)
        Console.WriteLine(offer.GetStockShares() + " of " + offer.GetStockSymbol());

      Console.WriteLine("\nStock buy Offers");

      foreach (StockOffer offer in _stockBuyOffers)
        Console.WriteLine(offer.GetStockShares() + " of " + offer.GetStockSymbol());
    }

  }
}
