using System;

namespace Unit8_SRP_F24.Contracts;

public interface ILogger
{
    public void LogMessage(string message, params object[] args);
}
