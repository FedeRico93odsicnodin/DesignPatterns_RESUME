using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Behavioural.Mediator
{
  public class Colleague
  {
    private Mediator _mediator;
    private int _colleagueCode;

    public Colleague(Mediator newMediator)
    {
      _mediator = newMediator;
      _mediator.AddColleague(this);
    }

    /// <summary>
    /// This method invokes the same method in the mediator 
    /// referred
    /// </summary>
    /// <param name="stock"></param>
    /// <param name="shares"></param>
    public void SaleOffer(string stock, int shares)
    {
      _mediator.SaleOfficer(stock, shares, this._colleagueCode);
    }

    /// <summary>
    /// This method invokes the same method in the mediator 
    /// referred
    /// </summary>
    /// <param name="stock"></param>
    /// <param name="shares"></param>
    public void BuyOffer(string stock, int shares)
    {
      _mediator.BuyOffer(stock, shares, this._colleagueCode);
    }


    public void SetCollCode(int collCode) { _colleagueCode = collCode; }
  }
}
