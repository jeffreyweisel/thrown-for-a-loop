using System.Globalization;
using System.Xml.Serialization;

List<Product> products = new List<Product>()    //creating new list syntax
{
new Product()
{
Name = "Football",
Price = 15.00M,
SoldOnDate = DateTime.Today.AddDays(12),
StockDate = new DateTime(2022, 10 ,2),
ManufacturerYear = 2010,
Condition = 4.2
},
new Product()
{
Name = "Hockey Stick",
Price = 12.99M,
SoldOnDate = DateTime.Today.AddDays(2),
StockDate = new DateTime(2023, 1, 4),
ManufacturerYear = 2020,
Condition = 2.5
},
new Product()
{
Name = "Soccer Ball",
Price = 7.50M,
StockDate = new DateTime(2021, 3, 9),
ManufacturerYear = 2012,
SoldOnDate = null,
Condition = 3
},
new Product()
{
Name = "Basketball Net",
Price = 10.99M,
SoldOnDate = null,
StockDate = new DateTime(2023, 11, 2),
ManufacturerYear = 2014,
Condition = 5,
},
new Product()
{
Name = "Shoulder Pads",
Price = 23.75M,
StockDate = new DateTime(2003, 1, 1),
ManufacturerYear = 2002,
Condition = 4.9,
SoldOnDate = null
},
new Product()
{
Name = "Tennis Racket",
Price = 5.60M,
SoldOnDate = DateTime.Today.AddDays(4),
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
3. View Latest Products
4. Monthly Sales Report
5. Add Product To Inventory
6. Make a purchase
7. Average shelf time for not sold products
8. Average shelf time for sold products");
    
    choice = Console.ReadLine();   //setting choice = user input
    
    Console.Clear();
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
    else if (choice == "4")
    {
        MonthlySalesReport();
    }
    else if (choice == "5")
    {
        AddProductToInventory();
    }
    else if (choice == "6")
    {
        PurchaseProduct();
    }
    else if (choice == "7")
    {
        UnsoldAverageShelfTime();
    }
    else if (choice == "8")
    {
        SoldAverageShelfTime();
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
It {(chosenProduct.SoldOnDate != null ? "is not available." : $"has been in stock for {timeInStock.Days} days.")}");
}

void ListProducts()
{
    decimal totalValue = 0.0M;
    foreach (Product product in products)
    {
        totalValue += product.Price;
        
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
        if (product.StockDate > threeMonthsAgo)
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

void MonthlySalesReport()
{
    Console.WriteLine("Choose a month and year to view sales stats for:");

    // Year
    Console.Write("Month: ");
    int month = int.Parse(Console.ReadLine());
    //Month
    Console.Write("Year: ");
    int year = int.Parse(Console.ReadLine());

    // Use Where to find products that were sold in that month and year 
   var selectedProducts = products
    .Where(p => p.SoldOnDate.HasValue && p.SoldOnDate.Value.Year == year && p.SoldOnDate.Value.Month == month);

    // Calculate total sales
    decimal totalSales = selectedProducts.Sum(p => p.Price);

    // Print result
    Console.WriteLine($"Sales stats for {month}/{year}:");
    Console.WriteLine($"Total Sales: ${totalSales}");
}

void AddProductToInventory()
{
    Product newProduct = new Product();

    // Product Name
    Console.WriteLine("Product Name:");
    newProduct.Name = Console.ReadLine().Trim();

    //Product Price
    Console.WriteLine("Product Price:");
    if (decimal.TryParse(Console.ReadLine().Trim(), out decimal Price))
    {
        newProduct.Price = Price;
    }

    //Product Available
    newProduct.SoldOnDate = null;
    
    //Product Stock Date
    newProduct.StockDate = DateTime.Now;

    Console.WriteLine($"{newProduct.Name} costs {newProduct.Price}");
    products.Add(newProduct);
}

void PurchaseProduct()
{
    ListProducts();

    Product chosenProduct = null;
    bool invalidChoice = true;

    while (invalidChoice)
    {
        Console.WriteLine("Enter the number of the product you wish to purchase:");

        try
        {
            int response = int.Parse(Console.ReadLine().Trim());
            chosenProduct = products[response - 1];

            // Buy it
                Console.WriteLine($"Enter the product number you wish to purchase");
                chosenProduct.SoldOnDate = DateTime.Now;
                
                Console.WriteLine($"You just purchased {chosenProduct.Name} at a price of ${chosenProduct.Price}! Congrats!.");
                invalidChoice = false;
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}

void UnsoldAverageShelfTime()
{
    // Create new list that holds not sold products
    List<Product> stockedProducts = products.Where(p => p.SoldOnDate == null).ToList();

    if (stockedProducts.Count > 0)
    {
        double totalShelfTime = 0;

        foreach (Product product in stockedProducts)
        {
            // Calculate the time on shelf for each product
            TimeSpan shelfTime = DateTime.Now - product.SoldOnDate.Value;
            totalShelfTime += shelfTime.TotalDays;
        }

        // Calculate the average shelf time
        double averageShelfTime = totalShelfTime / stockedProducts.Count;

        Console.WriteLine($"Average shelf time for currently stocked products: {averageShelfTime} days");
    }
    else
    {
        Console.WriteLine("No stocked products with sold dates found.");
    }
}
                
void SoldAverageShelfTime()
{
    // Create new list that holds sold products
    List<Product> soldProducts = products.Where(p => p.SoldOnDate != null).ToList();

    if (soldProducts.Count > 0)
    {
        double totalShelfTime = 0;

        foreach (Product product in soldProducts)
        {
            // Calculate the time on shelf for each product
            TimeSpan shelfTime = product.SoldOnDate.Value - product.StockDate;
            totalShelfTime += shelfTime.TotalDays;
        }

        // Calculate the average shelf time
        double averageShelfTime = totalShelfTime / soldProducts.Count;

        Console.WriteLine($"Average shelf time for currently stocked products: {averageShelfTime} days");
    }
    else
    {
        Console.WriteLine("No stocked products with sold dates found.");
    }
}
                