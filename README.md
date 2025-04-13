# 📈 WiseBooks - Day Trading Companion (MVP1)

**Automate your pre-market analysis** by instantly visualizing yesterday's key levels, volume, and gaps—no more manual chart marking.

## 🎯 MVP1 Goal
Replace your **manual checklist** with an automated dashboard that:
- Fetches **yesterday's high/low/close** and **volume spikes**
- Calculates **gap %** (today's open vs. yesterday's close)
- Plots **key levels** on a candlestick chart
- Focuses on **MARA** (Bitcoin-correlated high-volatility stock)

## 🛠️ Tech Stack
| Component       | Choice                  | Why?                          |
|-----------------|-------------------------|-------------------------------|
| **Frontend**    | Blazor Server           | Fast prototyping, C# logic    |
| **Data API**    | Finnhub Free Tier       | Real-time + historical data   |
| **Charts**      | Lightweight Charts      | Free TradingView alternative  |
| **Hosting**     | Local (for now)         | Quick iteration               |

## 📂 MVP1 Features
### 1. Core Dashboard
- **Single ticker view (MARA)**  
- Auto-generated **yesterday's key levels**:
  ```csharp
  // Model
  public class StockSnapshot {
      public decimal YesterdayHigh { get; set; }
      public decimal YesterdayLow { get; set; }
      public decimal GapPercentage { get; set; }
      public string ClosePosition => Close > (High+Low)/2 ? "High" : "Low"; 
  }



Wishlist chart:
For more complex financial charts, MudBlazor supports:

Candlestick patterns

Multiple series

Custom tooltips

Zooming/panning

Wishlist software:
Mass Transit and Rabit queues
Reddis cache
Oauth
