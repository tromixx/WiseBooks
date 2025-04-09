public class StockDataService
{
    public async Task<StockSnapshot> GetSnapshotAsync(string ticker)
    {
        // Simulated: Replace with real API calls
        return new StockSnapshot
        {
            Ticker = ticker.ToUpper(),
            PreviousHigh = 190.50m,
            PreviousLow = 185.10m,
            PreviousClose = 188.20m,
            GapPercentage = 1.23m,
            TodayOpen = 190.00m,
            CurrentPrice = 192.10m,
            AverageVolume = 28_000_000,
            YesterdayVolume = 32_000_000,
            ClosePositionInCandle = "High"
        };
    }
}
