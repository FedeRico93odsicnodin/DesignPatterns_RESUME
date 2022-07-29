﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Behavioural.State
{
  public interface ATMState
  {
    void InsertCard();

    void EjectCard();

    void InsertPin(int pinEntered);

    void RequestCash(int cashToWithdraw);
  }
}
