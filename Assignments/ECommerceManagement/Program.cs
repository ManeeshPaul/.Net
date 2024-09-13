namespace ECommerceManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create and display products
            var product1 = new Product("Television", 25000, "Electronics");
            var product2 = new Product("Mouse", 500, "Accessories");

            Console.WriteLine(product1);
            Console.WriteLine(product2);

            // Create and display a user
            var user = new User("Jerry", "password123", "jerry@gmail.com");
            Console.WriteLine(user);

            // Create and display an order
            var order = new Order();
            order.AddProduct(product1, 2); // Adding multiple quantities
            order.AddProduct(product2);
            order.UpdateTotal(0.1m); // Apply 10% discount
            Console.WriteLine(order);

            // Create and display persons
            var customer = new Customer("Arun", "Arun@gmail.com", "arun");
            var admin = new Admin("Sachin_Admin", "Sachin@gmail.com", "admin123");
            Console.WriteLine(customer);
            Console.WriteLine(admin);

            // Process orders
            IOrderProcessor paymentProcessor = new PaymentProcessor();
            IOrderProcessor shippingProcessor = new ShippingProcessor();

            paymentProcessor.ProcessOrder(order);
            shippingProcessor.ProcessOrder(order);

            paymentProcessor.CancelOrder(order);
            shippingProcessor.CancelOrder(order);
        }
    }
}