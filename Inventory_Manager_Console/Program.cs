namespace Inventory_Manager_Console
{
    internal class Program
    {

        class Product
        {
            public string Name { get; set; }
            public int Quantity { get; set; }
            public int Price { get; set; }
        }
        static void Main(string[] args)
        {
            (string, string)[] loginDetails =
            {
                ("Matthew", "123"),
                ("Mark" , "abc"),
                ("Luke", "xyz"),
                ("John", "000")
            };
            login:
            Console.WriteLine("Enter Username");
            string username = Console.ReadLine();
            Console.WriteLine("Enter Password");
            string password = Console.ReadLine();

            if (loginDetails.Any(details => details.Item1 == username && details.Item2 == password))

            {
                Console.WriteLine("Welcome to Inventory Manager");

                string name = null;
                int quantity = 0;
                int price = 0;

                List<Product> products = new List<Product>();

            Repeat:

                Console.WriteLine("Which option do you want to perform. Reply \n 1. Add Products \n 2. View Products");
                string option = Console.ReadLine();
                if (option == "1")
                {
                    Console.WriteLine("Type the Name of the Product");
                    name = Console.ReadLine();

                    Console.WriteLine("Enter the Quantity");

                    if (!int.TryParse(Console.ReadLine(), out quantity))
                    {
                        Console.WriteLine("The value you entered is not a number");
                    }

                    Console.WriteLine("Enter the Price");

                    if (!int.TryParse(Console.ReadLine(), out price))
                    {
                        Console.WriteLine("The value you entered is not a number");
                    }

                    Product newProduct = new Product { Name = name, Quantity = quantity, Price = price };
                    products.Add(newProduct);

                    goto Repeat;

                }
                if (option == "2")
                {
                    foreach (var product in products)
                    {
                        Console.WriteLine($"Name: {product.Name}, Quantity: {product.Quantity}, Price: N{product.Price}");
                    }

                }
                else
                {
                    Console.WriteLine("Select a valid option");


                }
            }
            else
            {
                Console.WriteLine("Invalid Username/Password");
                goto login;
            }
        }
    }
}
