using Microsoft.Data.SqlClient;
using Unit8_SRP_F24.Contracts;

namespace SingleResponsibilityPrinciple
{
    public class TradeProcessor
    {
        private ITradeDataProvider tradeDataProvider;
        private ITradeParser tradeParser;
        private ITradeStorage tradeStorage;

        public TradeProcessor(ITradeDataProvider tradeDataProvider, ITradeParser tradeParser, ITradeStorage tradeStorage)
        {
            this.tradeDataProvider = tradeDataProvider;
            this.tradeParser = tradeParser;
            this.tradeStorage = tradeStorage;
        }
        
        const float LotSize = 100000f;

        /// <summary>
        /// Main routine that processes the trade file
        /// </summary>
        /// <param name="stream"> The text file contianing the trade data </param>
        public void ProcessTrades(Stream stream)
        {
            var lines = tradeDataProvider.ReadTradeData();
            var trades = tradeParser.ParseTrades(lines);
            tradeStorage.StoreTrades(trades);
        }

    }
}
