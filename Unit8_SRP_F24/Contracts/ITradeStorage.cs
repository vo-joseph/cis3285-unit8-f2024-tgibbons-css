using System;

namespace Unit8_SRP_F24.Contracts;

public interface ITradeStorage
{
    public void StoreTrades(IEnumerable<TradeRecord> trades);
}
