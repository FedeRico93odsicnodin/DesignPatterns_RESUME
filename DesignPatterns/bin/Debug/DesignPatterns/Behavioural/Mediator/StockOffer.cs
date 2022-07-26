using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Behavioural.Mediator
{
  public class StockOffer
  {
    private int _stockShares = 0;
    private string _stockSymbol = String.Empty;
    private int _colleagueCode = 0;

    public StockOffer(int numOfShares, string stock, int collCode)
    {
      _stockShares = numOfShares;
      _stockSymbol = stock;
      _colleagueCode = collCode;
    }

    public int GetStockShares() { return _stockShares; }

    public string GetStockSymbol() { return _stockSymbol; }

    public int GetCollCode() { return _colleagueCode; }
  }
}
