using System;

namespace SportsBet.Services
{
    public interface IDateTimeProvider
    {
        DateTime? Now();
    }
}