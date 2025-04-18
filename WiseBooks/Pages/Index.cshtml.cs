using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace WiseBooks.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public List<Metric> Metrics { get; set; } = new();

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
        InitializeMetrics();
    }

    public void OnGet()
    {
    }

    private void InitializeMetrics()
    {
        Metrics = new List<Metric>
        {
            new("MARA", "Marathon Digital", "$18.40", "positive", "+2.34%"),
            new("Gap %", "Today's Opening", "4.27%", "positive", "Bullish"),
            new("Volume", "Today's Activity", "12.4M", "neutral", "+34% avg"),
            new("Range", "Yesterday's", "$17.2-$18.1", "", "5.2% range")
        };
    }
}

public record Metric(string Title, string Subtitle, string Value, string ChangeClass, string ChangeText);