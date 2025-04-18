class TradingDashboard {
    constructor() {
        this.dates = ['Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Mon', 'Tue'];
        this.closingPrices = [16.80, 17.50, 17.90, 18.50, 18.40];
        this.predictedPrices = [18.40, 18.80];
        this.fixedMin = 16.00;
        this.fixedMax = 20.00;
        this.priceChart = null;
        this.updateInterval = null;
        
        this.initialize();
    }

    initialize() {
        this.cleanupStorage();
        this.setupChart();
        this.startRealTimeUpdates();
        this.setupResizeHandler();
    }

    cleanupStorage() {
        try {
            if (window.indexedDB && indexedDB.databases) {
                indexedDB.databases().then(dbs => {
                    dbs.forEach(db => {
                        indexedDB.deleteDatabase(db.name);
                    });
                }).catch(e => console.log("IndexedDB cleanup error:", e));
            }
            localStorage.clear();
            sessionStorage.clear();
        } catch (e) {
            console.log("Storage cleanup error:", e);
        }
    }

    generatePrediction(lastPrice) {
        const direction = Math.random() > 0.4 ? 1 : -1;
        const strength = 0.1 + Math.random() * 0.3;
        
        const firstPrediction = Math.min(
            this.fixedMax, 
            Math.max(
                this.fixedMin, 
                lastPrice + (direction * strength * 0.5)
            )
        );
        
        const secondPrediction = Math.min(
            this.fixedMax, 
            Math.max(
                this.fixedMin, 
                lastPrice + (direction * strength)
            )
        );
        
        return [firstPrediction, secondPrediction];
    }

    calculateRecommendation(currentPrice, predictedPrices) {
        const priceChange = predictedPrices[1] - currentPrice;
        return Math.min(100, Math.max(0, 50 + (priceChange / currentPrice) * 2000));
    }

    updateThermometer(recommendationStrength) {
        const thermometerFill = document.getElementById('recommendationFill');
        if (thermometerFill) {
            thermometerFill.style.height = `${100 - recommendationStrength}%`;
        }
    }

    setupChart() {
        const priceCtx = document.getElementById('priceChart')?.getContext('2d');
        if (!priceCtx) return;

        this.predictedPrices = this.generatePrediction(this.closingPrices[this.closingPrices.length-1]);
        const recommendationStrength = this.calculateRecommendation(
            this.closingPrices[this.closingPrices.length-1], 
            this.predictedPrices
        );
        this.updateThermometer(recommendationStrength);

        this.priceChart = new Chart(priceCtx, {
            type: 'line',
            data: {
                labels: this.dates,
                datasets: [
                    {
                        label: 'Actual Price',
                        data: [...this.closingPrices, null, null],
                        borderColor: 'rgba(0, 123, 255, 1)',
                        backgroundColor: 'rgba(0, 123, 255, 0.1)',
                        borderWidth: 2,
                        tension: 0.3,
                        fill: true,
                    },
                    {
                        label: 'Predicted Price',
                        data: [null, null, null, null, this.closingPrices[this.closingPrices.length-1], ...this.predictedPrices],
                        borderColor: 'rgba(220, 53, 69, 0.7)',
                        backgroundColor: 'rgba(220, 53, 69, 0.05)',
                        borderWidth: 2,
                        borderDash: [5, 5],
                        tension: 0.3,
                        fill: false,
                    }
                ]
            },
            options: this.getChartOptions()
        });
    }

    getChartOptions() {
        return {
            responsive: true,
            maintainAspectRatio: false,
            plugins: {
                title: {
                    display: true,
                    text: 'MARA Weekly Performance with Prediction'
                },
                legend: {
                    display: true,
                    position: 'top'
                },
                tooltip: {
                    callbacks: {
                        label: function(context) {
                            let label = context.dataset.label || '';
                            if (label) {
                                label += ': ';
                            }
                            if (context.parsed.y !== null) {
                                label += `$${context.parsed.y.toFixed(2)}`;
                                if (context.dataIndex >= 5) {
                                    label += ' (predicted)';
                                }
                            }
                            return label;
                        }
                    }
                }
            },
            interaction: {
                mode: 'index',
                intersect: false
            },
            scales: {
                y: {
                    min: this.fixedMin,
                    max: this.fixedMax,
                    ticks: {
                        stepSize: 0.5,
                        callback: function(value) {
                            return `$${value.toFixed(2)}`;
                        }
                    },
                    title: {
                        display: true,
                        text: 'Price ($)'
                    }
                },
                x: {
                    title: {
                        display: true,
                        text: 'Day'
                    }
                }
            }
        };
    }

    startRealTimeUpdates() {
        this.updateInterval = setInterval(() => {
            const fluctuation = (Math.random() - 0.5) * 0.15;
            const newPrice = Math.min(this.fixedMax, Math.max(this.fixedMin, 
                this.closingPrices[this.closingPrices.length-1] + fluctuation));
            
            this.closingPrices.push(newPrice);
            this.closingPrices.shift();
            
            this.predictedPrices = this.generatePrediction(newPrice);
            
            if (this.priceChart) {
                this.priceChart.data.datasets[0].data = [...this.closingPrices, null, null];
                this.priceChart.data.datasets[1].data = [null, null, null, null, newPrice, ...this.predictedPrices];
                this.priceChart.update();
            }
            
            const metricValue = document.querySelector('.metric-value');
            if (metricValue) {
                metricValue.textContent = `$${newPrice.toFixed(2)}`;
            }
            
            const recommendationStrength = this.calculateRecommendation(newPrice, this.predictedPrices);
            this.updateThermometer(recommendationStrength);
        }, 2000);
    }

    setupResizeHandler() {
        window.addEventListener('resize', () => {
            if (this.priceChart) {
                this.priceChart.resize();
            }
        });
    }
}

// Initialize when DOM is loaded
document.addEventListener('DOMContentLoaded', () => {
    new TradingDashboard();
});