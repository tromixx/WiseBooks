# WiseBooks

### **Tech Stack**
1. **Front End**:  
   - **Blazor** (WebAssembly or Server) for a modern, interactive UI.
   - **Blazorise** or **MudBlazor** for pre-built UI components (e.g., charts, tables, forms).

2. **Back End**:  
   - **ASP.NET Core** for the backend API.
   - **GraphQL** (via HotChocolate) for flexible and efficient data queries.

3. **Database**:  
   - **SQLite** for local development and lightweight storage.
   - **MongoDB** (NoSQL) for user info if you prefer a schema-less approach.

4. **APIs**:  
   - **Alpaca API** for stock trading and market data.
   - **DeepSeek API** (or similar open-source AI tools) for predictive analytics and insights.

5. **Hosting**:  
   - **Azure** or **AWS** for cloud hosting.
   - **Docker** for containerization and deployment.

---

### **Implementation Plan**

#### **Phase 1: Setup and Core Features**
1. **Project Setup**:
   - Create a Blazor WebAssembly project for the front end.
   - Set up an ASP.NET Core backend with GraphQL support using HotChocolate.
   - Choose a database (SQLite for simplicity or MongoDB for flexibility).

2. **User Authentication**:
   - Implement user registration and login using **ASP.NET Core Identity**.
   - Use **JWT (JSON Web Tokens)** for secure authentication.

3. **Alpaca API Integration**:
   - Create a service to interact with the Alpaca API for:
     - Fetching stock data (real-time and historical).
     - Executing trades (buy/sell).
     - Managing portfolios.
   - Store API keys securely (e.g., using Azure Key Vault or environment variables).

4. **Portfolio Creation**:
   - Build a UI for users to create portfolios:
     - Pre-built portfolios (conservative, moderate, aggressive).
     - Custom portfolios with fractional shares.
   - Use Alpaca API to fetch stock data and execute trades.

5. **Portfolio Dashboard**:
   - Display the user’s portfolio with:
     - Current allocation (pie chart or bar graph).
     - Total value and gains/losses.
     - Interactive charts for minute-to-minute history.
   - Use **Chart.js** or **Blazorise Charts** for visualizations.

---

#### **Phase 2: Automated Rebalancing**
1. **Rebalancing Logic**:
   - Implement threshold-based rebalancing (e.g., ±5% drift from target allocation).
   - Use Alpaca API to execute trades for rebalancing.

2. **User Control**:
   - Allow users to set rebalancing preferences (threshold, frequency).
   - Notify users before executing rebalancing trades and require approval.

3. **Transparency**:
   - Log all rebalancing actions and display them in the dashboard.
   - Show the impact of rebalancing on the portfolio’s alignment.

---

#### **Phase 3: Alerting System**
1. **Price Alerts**:
   - Notify users when a stock’s price crosses a specific threshold.
   - Use Alpaca API for real-time price updates.

2. **Rebalancing Alerts**:
   - Notify users when the portfolio drifts from the target allocation.
   - Suggest specific actions to rebalance.

3. **News Alerts**:
   - Integrate a news API (e.g., **NewsAPI**) to provide stock-specific and market-wide news.
   - Use NLP (e.g., DeepSeek) to analyze sentiment and highlight important news.

---

#### **Phase 4: AI Integration**
1. **Portfolio Recommendations**:
   - Use DeepSeek or similar AI tools to analyze user preferences and market trends.
   - Recommend personalized portfolios or individual stocks.

2. **Predictive Analytics**:
   - Build machine learning models to predict stock performance or market trends.
   - Use **TensorFlow** or **PyTorch** for model training and deployment.

3. **Sentiment Analysis**:
   - Use NLP to analyze news articles, social media, and earnings calls.
   - Provide sentiment-based alerts or insights.

---

#### **Phase 5: Testing and Deployment**
1. **Testing**:
   - Write unit tests for backend services and API integrations.
   - Use **bUnit** for testing Blazor components.
   - Perform end-to-end testing with **Playwright** or **Selenium**.

2. **Deployment**:
   - Containerize the app using **Docker**.
   - Deploy to **Azure App Service** or **AWS Elastic Beanstalk**.
   - Set up CI/CD pipelines using **GitHub Actions** or **Azure DevOps**.

---

### **Database Design**
#### **SQLite (Relational)**
- **Users Table**:
  - `UserId` (Primary Key)
  - `Username`
  - `PasswordHash`
  - `Email`
- **Portfolios Table**:
  - `PortfolioId` (Primary Key)
  - `UserId` (Foreign Key)
  - `Name`
  - `TargetAllocation` (JSON)
- **Transactions Table**:
  - `TransactionId` (Primary Key)
  - `PortfolioId` (Foreign Key)
  - `StockSymbol`
  - `Quantity`
  - `Price`
  - `Timestamp`

#### **MongoDB (NoSQL)**
- **Users Collection**:
  - `_id`
  - `username`
  - `passwordHash`
  - `email`
- **Portfolios Collection**:
  - `_id`
  - `userId`
  - `name`
  - `targetAllocation` (JSON)
  - `transactions` (Array of transaction objects)

---

### **Tools and Libraries**
1. **Front End**:
   - **Blazorise** or **MudBlazor** for UI components.
   - **Chart.js** or **Blazorise Charts** for visualizations.
2. **Back End**:
   - **HotChocolate** for GraphQL.
   - **Alpaca .NET SDK** for Alpaca API integration.
   - **TensorFlow.NET** or **ML.NET** for AI/ML tasks.
3. **Database**:
   - **Entity Framework Core** for SQLite.
   - **MongoDB.Driver** for MongoDB.
4. **DevOps**:
   - **Docker** for containerization.
   - **GitHub Actions** or **Azure DevOps** for CI/CD.

---

### **Timeline**
1. **Week 1-2**: Project setup, user authentication, and Alpaca API integration.
2. **Week 3-4**: Portfolio creation and dashboard.
3. **Week 5-6**: Automated rebalancing and alerting system.
4. **Week 7-8**: AI integration (recommendations, predictive analytics, sentiment analysis).
5. **Week 9-10**: Testing, deployment, and final polish.

---

### **Conclusion**
This plan provides a clear roadmap for building your app using **Blazor**, **GraphQL**, and **SQLite/MongoDB**. By leveraging **Alpaca** and **DeepSeek APIs**, you can deliver a powerful yet simple and transparent tool for beginner investors. Let me know if you’d like further details or help with specific parts of the implementation!
