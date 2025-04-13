// In Services/StockDataService.cs
using System;
using System.Threading.Tasks;

namespace WiseBooks.Services
{
    public class StockDataService
    {
        private readonly Random _random = new();
        
        public async Task<StockSnapshot> GetMaraSnapshotAsync()
        {
            await Task.Delay(300); // Simulate API delay
            
            decimal basePrice = 25.00m;
            decimal randomOffset = (decimal)(_random.NextDouble() * 2 - 1);
            decimal prevClose = basePrice + randomOffset;
            
            return new StockSnapshot
            {
                PreviousHigh = Math.Round(prevClose + (decimal)(_random.NextDouble() * 0.5), 2),
                PreviousLow = Math.Round(prevClose - (decimal)(_random.NextDouble() * 0.5), 2),
                PreviousClose = Math.Round(prevClose, 2),
                GapPercentage = Math.Round((decimal)(_random.NextDouble() * 2 - 1), 2), // Random between -1 and 1%
                ClosePositionInCandle = _random.Next(0, 3) switch { 0 => "Low", 1 => "Middle", _ => "High" }
            };
        }
    }

    public class StockSnapshot
    {
        public decimal PreviousHigh { get; set; }
        public decimal PreviousLow { get; set; }
        public decimal PreviousClose { get; set; }
        public decimal GapPercentage { get; set; }
        public string ClosePositionInCandle { get; set; } = string.Empty;
    }
}