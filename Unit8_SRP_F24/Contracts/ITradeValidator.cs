using System;

namespace Unit8_SRP_F24.Contracts;

public interface ITradeValidator
{
    public bool ValidateTradeData(String[] fields, int currentLine);
}
