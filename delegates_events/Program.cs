using System;
using System.Collections.Generic;

namespace EcommerceAssessment
{
    // TASK 1: GENERIC REPOSITORY
    public class Repository<T>
    {
        private List<T> items = new List<T>();

        public void Add(T item)
        {
            items.Add(item);
        }

        public List<T> GetAll()
        {
            return items;
        }
    }

    // TASK 2: ORDER MODEL
    public class Order
    {
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public double Amount { get; set; }

        public override string ToString()
        {
            return $"OrderId: {OrderId}, Customer: {CustomerName}, Amount: {Amount}";
        }
    }

    // TASK 3: CUSTOM DELEGATE
    public delegate void OrderCallback(string message);

    // TASK 4: ORDER PROCESSOR
    public class OrderProcessor
    {
        public event Action<string> OrderProcessed;

        public void ProcessOrder(
            Order order,
            Func<double, double> taxCalculator,
            Func<double, double> discountCalculator,
            Predicate<Order> validator,
            OrderCallback callback)
        {
            // Validation
            if (!validator(order))
            {
                callback?.Invoke("Callback: Order validation failed.");
                return;
            }

            // Calculations
            double tax = taxCalculator(order.Amount);
            double discount = discountCalculator(order.Amount);

            order.Amount = order.Amount + tax - discount;

            // Callback
            callback?.Invoke($"Callback: Order {order.OrderId} processed successfully.");

            // Event
            OrderProcessed?.Invoke($"Event: Order {order.OrderId} completed.");
        }
    }

    // TASK 5: EXECUTION
    class Program
    {
        static void Main()
        {
            // Repository
            Repository<Order> orderRepo = new Repository<Order>();

            orderRepo.Add(new Order { OrderId = 1, CustomerName = "ramu", Amount = 5000 });
            orderRepo.Add(new Order { OrderId = 2, CustomerName = "dosa", Amount = 2000 });
            orderRepo.Add(new Order { OrderId = 3, CustomerName = "idli_chatni_cahtni", Amount = 8000 });

            // Delegates
            Func<double, double> taxCalculator = amount => amount * 0.18;
            Func<double, double> discountCalculator = amount => amount * 0.05;
            Predicate<Order> validator = order => order.Amount >= 3000;

            // Callback
            OrderCallback callback = msg => Console.WriteLine(msg);

            // Processor
            OrderProcessor processor = new OrderProcessor();

            // Event handlers
            Action<string> logger = msg => Console.WriteLine($"Logger: {msg}");
            Action<string> notifier = msg => Console.WriteLine($"Notifier: {msg}");

            // Multicast event subscription
            processor.OrderProcessed += logger;
            processor.OrderProcessed += notifier;

            // Process orders
            foreach (var order in orderRepo.GetAll())
            {
                processor.ProcessOrder(
                    order,
                    taxCalculator,
                    discountCalculator,
                    validator,
                    callback
                );
                Console.WriteLine();
            }

            // Sorting orders (Descending Amount)
            List<Order> processedOrders = orderRepo.GetAll();
            processedOrders.Sort((o1, o2) => o2.Amount.CompareTo(o1.Amount));

            Console.WriteLine("Sorted Orders (Descending Amount):");
            foreach (var order in processedOrders)
            {
                Console.WriteLine(order);
            }
        }
    }
}
