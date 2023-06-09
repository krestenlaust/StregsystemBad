﻿using Stregsystem.Core.DTOs;

namespace Stregsystem.Core.Exceptions;

/// <summary>
/// Thrown when a user tries to purchase a product they can't afford.
/// </summary>
[Serializable]
public class InsufficientCreditsException : Exception
{
    public User User { get; }
    public Product Product { get; }

    public InsufficientCreditsException(User user, Product product)
    {
        this.User = user;
        this.Product = product;
    }
}
