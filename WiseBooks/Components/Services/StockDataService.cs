public class StockDataService
{
    private readonly Random _random = new();
    
    public async Task<StockSnapshot> GetSnapshotAsync(string ticker)
    {
        // Simulate API delay
        await Task.Delay(300);
        
        // Generate realistic fake data
        decimal basePrice = ticker.ToUpper() switch
        {
            "MARA" => 25.00m,
            "SPY" => 450.00m,
            _ => 100.00m
        };

        var volatility = _random.Next(5, 15);
        var prevClose = basePrice + (decimal)(_random.NextDouble() * 2 - 1);
        var todayOpen = prevClose * (1 + (decimal)(_random.NextDouble() * 0.02 - 0.01));

        return new StockSnapshot
        {
            Ticker = ticker.ToUpper(),
            PreviousHigh = prevClose + (decimal)(_random.NextDouble() * volatility / 100),
            PreviousLow = prevClose - (decimal)(_random.NextDouble() * volatility / 100),
            PreviousClose = prevClose,
            GapPercentage = Math.Round((todayOpen - prevClose) / prevClose * 100, 2),
            TodayOpen = todayOpen,
            CurrentPrice = todayOpen * (1 + (decimal)(_random.NextDouble() * 0.005 - 0.0025)),
            AverageVolume = 10_000_000 + _random.Next(-2_000_000, 5_000_000),
            YesterdayVolume = 10_000_000 + _random.Next(-3_000_000, 7_000_000),
            ClosePositionInCandle = _random.Next(0, 3) switch { 0 => "Low", 1 => "Middle", _ => "High" }
        };
    }
}