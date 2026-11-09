using System;
using Unit8_SRP_F24.Contracts;

namespace Unit8_SRP_F24;

public class ConsoleLogger : ILogger
{
    public void LogMessage(string message, params object[] args)
    {
        Console.WriteLine(message, args);
    }
}
