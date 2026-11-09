using System;

namespace Unit8_SRP_F24.Contracts;

public interface ITradeMapper
{
    public TradeRecord MapTradeDataToTradeRecord(String[] fields);
}
