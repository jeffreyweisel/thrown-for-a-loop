List<Product> products = new List<Product>()    //creating new list syntax
{
new Product()
{
Name = "Football",
Price = 15.00M,
Sold = false,
StockDate = new DateTime(2022, 10 ,2),
ManufacturerYear = 2010,
Condition = 4.2
},
new Product()
{
Name = "Hockey Stick",
Price = 12.99M,
Sold = false,
StockDate = new DateTime(2023, 1, 4),
ManufacturerYear = 2020,
Condition = 2.5
},
new Product()
{
Name = "Soccer Ball",
Price = 7.50M,
Sold = false,
StockDate = new DateTime(2021, 3, 9),
ManufacturerYear = 2012,
Condition = 3
},
new Product()
{
Name = "Basketball Net",
Price = 10.99M,
Sold = false,
StockDate = new DateTime(2023, 11, 2),
ManufacturerYear = 2014,
Condition = 5
},
new Product()
{
Name = "Shoulder Pads",
Price = 23.75M,
Sold = true,
StockDate = new DateTime(2003, 1, 1),
ManufacturerYear = 2002,
Condition = 4.9
},
new Product()
{
Name = "Tennis Racket",
Price = 5.60M,
Sold = false,
StockDate = new DateTime(2021, 7, 11),
ManufacturerYear = 2014,
Condition = 3.6
}
};

DateTime now = DateTime.Now;    //declaring now as DateTime type and setting it to current DateTime

string greeting = @"Welcome to Thrown For a Loop    
Your one-stop shop for used sporting equipment"; //declare greeting as type string to be called later

Console.WriteLine(greeting);
string choice = null;
while (choice != "0")
{
    Console.WriteLine(@"Choose an option:
0. Exit
1. View All Products
2. View Product Details
3. View Latest Products");
    choice = Console.ReadLine();   //setting choice = user input
    if (choice == "0")
    {
        Console.WriteLine("See ya!");
    }
    else if (choice == "1")
    {
        ListProducts();
    }
    else if (choice == "2")
    {
        ViewProductDetails();
    }
    else if (choice == "3")
    {
        ViewLatestProducts();
    }
}

void ViewProductDetails()
{
    ListProducts();

    Product chosenProduct = null;

    while (chosenProduct == null)
    {
        Console.WriteLine("Enter a product number: ");
        try
        {
            int response = int.Parse(Console.ReadLine().Trim());
            chosenProduct = products[response - 1];
        }
        catch (FormatException)
        {
            Console.WriteLine("Please type only integers!");
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Please choose an existing item only!");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            Console.WriteLine("Do Better!");
        }
    }

    TimeSpan timeInStock = now - chosenProduct.StockDate;

    Console.WriteLine(@$"You chose: 
{chosenProduct.Name}, which costs {chosenProduct.Price} dollars.
It is {now.Year - chosenProduct.ManufacturerYear} years old.
It {(chosenProduct.Sold ? "is not available." : $"has been in stock for {timeInStock.Days} days.")}");
}

void ListProducts()
{
    decimal totalValue = 0.0M;
    foreach (Product product in products)
    {
        if (!product.Sold)
        {
            totalValue += product.Price;
        }
    }
    Console.WriteLine($"Total inventory value: ${totalValue}");
    Console.WriteLine("Products:");
    for (int i = 0; i < products.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {products[i].Name}");
    }
}

void ViewLatestProducts()
{
    // create a new empty List to store the latest products
    List<Product> latestProducts = new List<Product>();
    // Calculate a DateTime 90 days in the past
    DateTime threeMonthsAgo = DateTime.Now - TimeSpan.FromDays(90);
    // loop through the products
    foreach (Product product in products)
    {
        // Add a product to latestProducts if it fits the criteria
        if (product.StockDate > threeMonthsAgo && !product.Sold)
        {
            latestProducts.Add(product);
        }
    }
    Console.WriteLine("The Latest Products Are:");
    // print out the latest products to the console
    for (int i = 0; i < latestProducts.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {latestProducts[i].Name}");
    }
}

