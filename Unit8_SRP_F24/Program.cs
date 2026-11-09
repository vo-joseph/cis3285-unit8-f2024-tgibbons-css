using System.Reflection;
using Unit8_SRP_F24;
using Unit8_SRP_F24.Contracts;

namespace SingleResponsibilityPrinciple
{
    class Program
    {
        static void Main(string[] args)
        {
            ILogger logger = new ConsoleLogger();

            var tradeStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Unit8_SRP_F24.trades.txt");
            if (tradeStream is null)
            {
                Console.Error.WriteLine("Could not find the embedded trades.txt file.");
                return;
            }

            ITradeValidator tradeValidator = new SimpleTradeValidator(logger);
            ITradeDataProvider tradeDataProvider = new StreamTradeDataProvider(tradeStream, logger);
            ITradeMapper tradeMapper = new SimpleTradeMapper();
            ITradeParser tradeParser = new SimpleTradeParser(tradeValidator, tradeMapper);
            ITradeStorage tradeStorage = new AdoNetTradeStorage(logger);


            TradeProcessor tradeProcessor = new TradeProcessor(tradeDataProvider, tradeParser, tradeStorage);

            tradeProcessor.ProcessTrades(tradeStream);

            //Console.ReadKey();
        }
    }
}
