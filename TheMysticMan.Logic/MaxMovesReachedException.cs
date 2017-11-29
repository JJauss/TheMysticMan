using System;

namespace TheMysticMan.Logic{
  public class MaxMovesReachedException : Exception
  {
    public MaxMovesReachedException(string message) : base(message)
    {
    }
  }
}