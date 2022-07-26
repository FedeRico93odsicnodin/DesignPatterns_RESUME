using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Behavioural.Mediator
{
  public interface Mediator
  {
    void SaleOfficer(string stock, int shares, int collCode);

    void BuyOffer(string stock, int shares, int collCode);

    // colleague will be created in next page 
    void AddColleague(Colleague colleague);
  }
}
