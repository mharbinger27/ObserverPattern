using System;
using System.Collections.Generic;
using System.Text;

namespace Investments
{
    public abstract class Stock
    {
        private string _symbol;
        private double _price;
        private List<IInvestor> _investors = new List<IInvestor>();

        // Constructor
        public Stock(string symbol, double price)
        {
            this._symbol = symbol;
            this._price = price;

            Console.WriteLine($"Stock {symbol} created with value {price}.");
        }

        public void Attach(IInvestor investor)
        {
            _investors.Add(investor);
            Console.WriteLine($"Subscribed {investor.GetName()} to stock {this.Symbol}.");
        }

        public void Detach(IInvestor investor)
        {
            _investors.Remove(investor);
            Console.WriteLine($"Unsubscribed {investor.GetName()} to stock {this.Symbol}.");
        }

        public void Notify()
        {
            foreach (IInvestor investor in _investors)
            {
                investor.Update(this);
            }
        }
        
        // Gets or sets the price
        public double Price
        {
            get { return _price; }
            set
            {
                if (_price != value)
                {
                    _price = value;
                    Console.WriteLine($"Stock {this.Symbol} updated with value {value}.");
                    Notify();
                }
            }
        }

        // Gets the symbol
        public string Symbol
        {
            get { return _symbol; }
        }
    }
}
