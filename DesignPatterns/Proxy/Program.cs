using System;

namespace Proxy
{
    class Program
    {
        static void Main(string[] args)
        {
            var server = new Server();
            server.TakeOrder("order1");
            var order = server.DeliverOrder();
            server.ProcessPayment(order);

            var newServer = new NewServerProxy();
            newServer.TakeOrder("order2");
            var newOrder = newServer.DeliverOrder();
            newServer.ProcessPayment(newOrder);

            Console.Read();
        }
    }

    /// <summary>
    /// The Subject interface which both the RealSubject and proxy will need to implement
    /// </summary>
    public interface IServer
    {
        void TakeOrder(string order);
        string DeliverOrder();
        void ProcessPayment(string payment);
    }

    /// <summary>
    /// The RealSubject class which the Proxy can stand in for
    /// </summary>
    class Server : IServer
    {
        private string Order;
        public void TakeOrder(string order)
        {
            Console.WriteLine("Server takes order for " + order + ".");
            Order = order;
        }

        public string DeliverOrder()
        {
            return Order;
        }

        public void ProcessPayment(string payment)
        {
            Console.WriteLine("Payment for order (" + payment + ") processed.");
        }
    }

    /// <summary>
    /// The Proxy class, which can substitute for the Real Subject.
    /// </summary>
    class NewServerProxy : IServer
    {
        private string Order;
        private Server _server = new Server();

        public void TakeOrder(string order)
        {
            Console.WriteLine("New trainee server takes order for " + order + ".");
            Order = order;
        }

        public string DeliverOrder()
        {
            return Order;
        }

        public void ProcessPayment(string payment)
        {
            Console.WriteLine("New trainee cannot process payments yet!");
            _server.ProcessPayment(payment);
        }
    }
}
