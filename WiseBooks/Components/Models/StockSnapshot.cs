namespace WiseBooks.Models
{
    public class StockSnapshot
    {
        public decimal PreviousHigh { get; set; }
        public decimal PreviousLow { get; set; }
        public decimal PreviousClose { get; set; }
        public decimal GapPercentage { get; set; }
        public string ClosePositionInCandle { get; set; } = string.Empty; // Initialize with default
    }
}