using System;

namespace Vending_Machine
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] products = { "Water", "Coke", "Sandwich" ,"Fruit Juice" ,"Energy Drink" , "Chocolate" };
            double[] prices = { 1.50, 5.59, 6.99 , 3.99 , 4.99 , 3.99};

            while (true)
            {
                Console.WriteLine("1: Customer Menu");
                Console.WriteLine("2: Admin Panel");
                Console.Write("Please Enter Your Choice:");
                int mchoose = Convert.ToInt32(Console.ReadLine());

                if (mchoose == 1)
                {
                    CustomerPanel(products, prices);
                }
                else if (mchoose == 2)
                {
                    AdminPanel(ref products, ref prices);
                }
            }
        }

        static void CustomerPanel(string[] products, double[] prices)
        {
            Console.WriteLine("Choose Your Product:");
            for (int i = 0; i < products.Length; i++)
                Console.WriteLine($"{i}. {products[i]} - {prices[i]} TL");

            Console.Write("Please Make Your Choice: ");
            int secim = Convert.ToInt32(Console.ReadLine());

            Console.Write("Please İnsert Your Money: ");
            double money = Convert.ToDouble(Console.ReadLine());

            if (money >= prices[secim])
            {
                Console.WriteLine($"{products[secim]} Your Product İs Given");
                if (money > prices[secim])
                {
                    Console.WriteLine("Your Change İs Being Given.");
                }
            }
            else
            {
                Console.WriteLine("Not Enough Money!");
            }
        }

        static void AdminPanel(ref string[] produtcs, ref double[] prices)
        {
            Console.WriteLine("Admin Password:");
            if (Console.ReadLine() == "1001")
            {
                while (true)
                {
                    Console.WriteLine("1: Add Product");
                    Console.WriteLine("2: Delete Product");
                    Console.WriteLine("3: Update Product");
                    Console.WriteLine("4: Exit");
                    int secim = Convert.ToInt32(Console.ReadLine());

                    if (secim == 1) 
                    {
                        Console.Write("New Product: ");
                        string newproduct = Console.ReadLine();
                        Array.Resize(ref produtcs, produtcs.Length + 1);
                        produtcs[^1] = newproduct;

                        Console.Write("Price: ");
                        double newprice = Convert.ToDouble(Console.ReadLine());
                        Array.Resize(ref prices, produtcs.Length + 1);
                        prices[^1] = newprice;
                    }
                    else if (secim == 2) 
                    {
                        Console.Write("Please Enter The Product You Want To Delete: ");
                        int delete = Convert.ToInt32(Console.ReadLine());

                        
                        for (int i = delete; i < produtcs.Length - 1; i++)
                        {
                            produtcs[i] = produtcs[i + 1];
                            prices[i] = prices[i + 1];
                        }
                        Array.Resize(ref produtcs, produtcs.Length - 1);
                        Array.Resize(ref prices, prices.Length - 1);
                    }
                    else if (secim == 3) 
                    {
                        Console.Write("Please Select Product You Want To Update: ");
                        int update = Convert.ToInt32(Console.ReadLine());
                        Console.Write("New Price: ");
                        prices[update] = Convert.ToDouble(Console.ReadLine());
                    }
                    else if (secim == 4) 
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Wrong Choice!");
                    }
                }
            }
            else
            {
                Console.WriteLine("Wrong Password!");
            }
        }
    }
}
