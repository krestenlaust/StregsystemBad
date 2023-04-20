﻿using Stregsystem.Core.DTOs;

namespace Stregsystem.Core.Transactions;

internal class BuyTransaction : Transaction
{
    public Product Product { get; }

    public BuyTransaction(int ID, User user, decimal amount) : base(ID, user, amount)
    {
    }
}
