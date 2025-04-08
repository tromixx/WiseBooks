Day trading companion app designed to make real-time decisions based on **previous day’s market activity**.

---

# ✅ PHASE 1 – ROCK SOLID TRADING PLAN (Day Trading Context)

This is the daily **pre-market and intraday battle plan**. It focuses on:

## 🎯 Key Goals:
- Know **where the market was interested yesterday**
- Understand **today’s early momentum**
- Decide on **entry/exit zones** based on real data

---

## 📅 Step-by-Step Daily Checklist for Trading

### 🔍 Pre-Market (8:00 – 9:30 AM ET)
```markdown
1. [ ] Scan 3–5 tickers (SPY, QQQ, TSLA, NVDA, AAPL, etc)
2. [ ] Mark Yesterday’s High & Low → Horizontal lines on chart
3. [ ] Mark Premarket High & Low
4. [ ] Look for volume spike zones (from yesterday)
5. [ ] Identify Support & Resistance from past 3–5 days
6. [ ] Note:
     - % gap up/down from yesterday's close
     - Close position in yesterday’s candle (high/middle/low)
     - Volume vs 20-day average
7. [ ] Check SPY/QQQ behavior
8. [ ] Note any earnings/news for your tickers
```

---

### 📊 Intraday Plan (9:30 AM – 11:00 AM ET)
```markdown
1. [ ] First 15m: Wait and watch — observe price action
2. [ ] If price reclaims yesterday’s high → consider long setup
3. [ ] If price rejects premarket high or key resistance → short setup
4. [ ] Monitor volume – is it confirming the move?
5. [ ] Use VWAP + EMAs for additional confluence
6. [ ] Protect capital: define risk (stop-loss) before trade
```

---

## 🔁 Proven Patterns to Watch
- **Gap and Go**
- **Gap Fill Reversal**
- **Opening Range Breakout (ORB)**
- **Previous Day Break and Retest**

---

# 🧠 PHASE 2 – BUILDING “WiseBooks” (Blazor Server App)

Let’s build a **Blazor Server App** — ideal for performance, local debugging, and future backend extensibility (Python API, trading bots, etc).

---

## 🧱 Project Setup

### 🛠️ Step 1: Create the App
Open VS 2022 or newer →  
**New Project > Blazor Server App > Call it `WiseBooks`**

- ✅ .NET 8
- ✅ Authentication: None (for now)
- ✅ ASP.NET Core Hosted: No
- ✅ Location: Your preferred repo folder

---

## 📁 Folder Structure
```
WiseBooks/
│
├── Pages/
│   └── Dashboard.razor         # Main app logic
│
├── Services/
│   └── StockDataService.cs     # Pull data from Alpha Vantage or Yahoo
│
├── Models/
│   └── StockSnapshot.cs        # Yesterday’s stats
│
├── wwwroot/
│   └── charting + indicators
│
└── appsettings.json            # API key config (AlphaVantage etc.)
```

---

## 🧩 Step 2: Define Model
`Models/StockSnapshot.cs`
```csharp
public class StockSnapshot
{
    public string Ticker { get; set; }
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
```

---

## 🔌 Step 3: Create the Stock Data Service
`Services/StockDataService.cs`

We'll simulate fetching data from Alpha Vantage or Yahoo. You can later plug in real API logic.

```csharp
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
```

---

## 🌅 Step 4: Dashboard UI Page

`Pages/Dashboard.razor`
```razor
@page "/"
@inject StockDataService DataService

<PageTitle>WiseBooks Dashboard</PageTitle>

<h1 class="text-3xl font-bold mb-4">📘 WiseBooks Trading Dashboard</h1>

<input @bind="ticker" placeholder="Enter ticker..." class="p-2 border rounded" />
<button @onclick="LoadStock" class="ml-2 px-4 py-2 bg-blue-500 text-white rounded">Analyze</button>

@if (snapshot != null)
{
    <div class="mt-4 p-4 bg-gray-100 rounded shadow">
        <h2 class="text-xl font-semibold">@snapshot.Ticker Snapshot</h2>
        <p>📈 Previous High: $@snapshot.PreviousHigh</p>
        <p>📉 Previous Low: $@snapshot.PreviousLow</p>
        <p>🔒 Previous Close: $@snapshot.PreviousClose</p>
        <p>🚀 Gap % Today: <b>@snapshot.GapPercentage%</b></p>
        <p>🕯️ Close Position in Candle: @snapshot.ClosePositionInCandle</p>
        <p>📊 Yesterday Volume: @snapshot.YesterdayVolume</p>
        <p>📉 Average Volume: @snapshot.AverageVolume</p>
    </div>
}

@code {
    private string ticker = "AAPL";
    private StockSnapshot? snapshot;

    private async Task LoadStock()
    {
        snapshot = await DataService.GetSnapshotAsync(ticker);
    }
}
```

---

## ✅ Step 5: Register Services

In `Program.cs`:
```csharp
builder.Services.AddScoped<StockDataService>();
```

---

## 🔄 Optional Step: Add Auto-Refresh Every 30s
Inside `@code` block:
```csharp
protected override async Task OnInitializedAsync()
{
    await LoadStock();
    _ = Task.Run(async () =>
    {
        while (true)
        {
            await Task.Delay(30000);
            await LoadStock();
            StateHasChanged();
        }
    });
}
```

---

## 🔮 What’s Next (Optional Features Later)

- Add charting via `Chart.js` or `Plotly` in `wwwroot`
- Add news & earnings feed (using Finnhub or MarketWatch scraping)
- Add pattern detection (Gap & Go, ORB) into service logic
- Add TradingView widget embed or API alerts
- Save past days for backtesting

---
