namespace Inventory_Manager_Console
{
    internal class Program
    {

        class Product
        {
            public string Name { get; set; }
            public float Quantity { get; set; }
            public float Price { get; set; }
            public float totalPrice { get; set; }
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
            begin:
            Console.WriteLine("Welcome to Inventory Manager");

            Console.WriteLine("Do you want to \n 1.Register \n 2.Login \n 3.Exit");
            string option1 = Console.ReadLine();

            if(option1 == "1")
            {
                Console.WriteLine("Create a Username");
                string new_username = Console.ReadLine();
                Console.WriteLine("Create a Password");
                string new_password = Console.ReadLine();
                Array.Resize(ref loginDetails, loginDetails.Length + 1);
                loginDetails[loginDetails.Length - 1] = (new_username, new_password);
                Console.WriteLine("Registration Successful! Please login now.");


            }

            else if(option1 == "2")
            {
                goto login;
            }
            else if(option1 == "3")
            {
                return;
            }
            else
            {
                Console.WriteLine("Invalid Input");
                goto begin;
            }

        login:
            

            Console.WriteLine("Enter Username");
            string username = Console.ReadLine();
            Console.WriteLine("Enter Password");
            string password = Console.ReadLine();



            if (loginDetails.Any(details => details.Item1 == username && details.Item2 == password))

            {
                Console.WriteLine($"Welcome {username} ");


                string name = null;
                float quantity = 0;
                float price = 0;

                Product[] products = new Product[0];

            Repeat:

                Console.WriteLine("Which option do you want to perform. Reply \n 1. Add Products \n 2. View Products \n 3. Exit");
                string option = Console.ReadLine();
                if (option == "1")
                {
                    Console.WriteLine("Type the Name of the Product");
                    name = Console.ReadLine();

                    enterQuantity:

                    Console.WriteLine("Enter the Quantity");

                    

                    if (!float.TryParse(Console.ReadLine(), out quantity))
                    {
                        Console.WriteLine("The value you entered is not a number");
                        goto enterQuantity;
                    }

                    Console.WriteLine("Enter the Price");

                    enterPrice:
                    if (!float.TryParse(Console.ReadLine(), out price))
                    {
                        Console.WriteLine("The value you entered is not a number");
                        goto enterPrice;
                    }
                    
                    Array.Resize(ref products, products.Length + 1);
                    products[products.Length - 1] = new Product { Name = name, Quantity = quantity, Price = price, totalPrice= price*quantity };


                    goto Repeat;

                }
                else if (option == "2")
                {
                    foreach (var product in products)
                    {

                        Console.WriteLine($"Name: {product.Name}, Quantity: {product.Quantity}, Price per product: N{product.Price}, Total Price: {product.totalPrice}" );
                    }
                    goto Repeat;
                }

                else if (option  == "3")
                {
                    return;
                }
                else
                {
                    Console.WriteLine("Select a valid option");
                    goto Repeat;


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

