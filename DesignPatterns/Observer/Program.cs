using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    class Program
    {
        /// <summary>
        /// The observer pattern is a design pattern that defines a link between objects so that when one object's state changes,
        /// all dependent objects are updated automatically.
        /// This pattern allows communication between objects in a loosely coupled manner.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var stockTicker = new ConcreteStockTicker();
            var ibmObserver = new IBMStockObserver("ROBER KANASZ");
            var allObserver = new AllStockObserver("IVOR LOTOCASH");

            stockTicker.Register(ibmObserver);
            stockTicker.Register(allObserver);

            foreach (var s in StockData.getNext())
                stockTicker.Stock = s;
            Console.Read();
        }

        public static class StockData
        {
            private static decimal[] samplePrices =
               new decimal[] { 10.00m, 10.25m, 555.55m, 9.50m, 9.03m, 500.00m, 499.99m, 10.10m, 10.01m };
            private static string[] sampleStocks = new string[] { "MSFT", "MSFT",
              "GOOG", "MSFT", "MSFT", "GOOG",
              "GOOG", "MSFT", "IBM" };
            public static IEnumerable<Stock> getNext()
            {
                for (int i = 0; i < samplePrices.Length; i++)
                {
                    Stock s = new Stock();
                    s.Code = sampleStocks[i];
                    s.Price = samplePrices[i];
                    yield return s;
                }
            }
        }

        public class AllStockObserver : IStockObserverBase
        {
            public AllStockObserver(string name)
            {
                Name = name;
            }

            public string Name { get; set; }

            public void Notify(Stock stock)
            {
                Console.WriteLine("Notified {0} of {1}'s " +
                                  "change to {2:C}", Name, stock.Code, stock.Price);
            }
        }

        public class IBMStockObserver : IStockObserverBase
        {
            public IBMStockObserver(string name)
            {
                Name = name;
            }

            public string Name { get; set; }

            public void Notify(Stock stock)
            {
                if (stock.Code == "IBM")
                    Console.WriteLine("Notified {0} of {1}'s " +
                                  "change to {2:C}", Name, stock.Code, stock.Price);
            }
        }

        public class ConcreteStockTicker : StockTickerBase
        {
            private Stock stock;
            public Stock Stock
            {
                get { return stock; }
                set
                {
                    stock = value;
                    Notify();
                }
            }

            public override void Notify()
            {
                foreach (var observer in _observers)
                {
                    observer.Notify(stock);
                }
            }
        }

        public class Stock
        {
            public decimal Price { get; set; }
            public string Code { get; set; }
        }

        public interface IStockObserverBase
        {
            void Notify(Stock stock);
        }

        public abstract class StockTickerBase
        {
            readonly protected List<IStockObserverBase> _observers = new List<IStockObserverBase>();

            public void Register(IStockObserverBase observer)
            {
                if (!_observers.Contains(observer))
                {
                    _observers.Add(observer);
                }
            }

            public void Unregister(IStockObserverBase observer)
            {
                if (_observers.Contains(observer))
                {
                    _observers.Remove(observer);
                }
            }

            public abstract void Notify();
        }

    }
}
