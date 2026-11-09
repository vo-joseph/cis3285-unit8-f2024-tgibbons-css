using System;
using Unit8_SRP_F24.Contracts;

namespace Unit8_SRP_F24;

public class StreamTradeDataProvider : ITradeDataProvider
{
    private Stream stream;
    private ILogger logger;
    public StreamTradeDataProvider(Stream stream, ILogger logger)
    {
        this.stream = stream;
        this.logger = logger;
    }

    /// <summary>
    /// Read the text file containing the trades. This file should in in the format of one trade per line
    ///    GBPUSD,1000,1.51
    /// </summary>
    /// <param name="stream"> File must be passed in as a Stream. </param>
    /// <returns> Returns a list of strings, one for each string for each line in the file </returns>
    public IEnumerable<string> ReadTradeData()
    {
        // read rows
        List<string> lines = new List<string>();
        using (var reader = new StreamReader(stream))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                lines.Add(line);
            }
        }
        return lines;
    }
}
