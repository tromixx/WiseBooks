public class StockSnapshot
{
    public string? Ticker { get; set; }
    public decimal PreviousHigh { get; set; }
    public decimal PreviousLow { get; set; }
    public decimal PreviousClose { get; set; }
    public decimal GapPercentage { get; set; }
    public decimal TodayOpen { get; set; }
    public decimal CurrentPrice { get; set; }
    public decimal AverageVolume { get; set; }
    public decimal YesterdayVolume { get; set; }
    public string ClosePositionInCandle { get; set; } // "High", "Middle", "Low"
}
