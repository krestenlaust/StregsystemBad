﻿namespace Stregsystem.Core.Exceptions;


[Serializable]
public class InvalidIntegralValueDataProviderException : Exception
{
    public InvalidIntegralValueDataProviderException() { }
    public InvalidIntegralValueDataProviderException(string message) : base(message) { }
    public InvalidIntegralValueDataProviderException(string message, Exception inner) : base(message, inner) { }
    protected InvalidIntegralValueDataProviderException(
      System.Runtime.Serialization.SerializationInfo info,
      System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}
