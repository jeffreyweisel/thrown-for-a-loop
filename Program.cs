string greeting = @"Welcome to Thrown For  A Loop
Your one-stop shop for used sporting equipment";    //declare string to be referenced later

Console.WriteLine(greeting);    //same as console.log in js

List<Product> products = new List<Product>()
{
    new Product()
    {
        Name = "Football",
        Price = 15,
        Sold = false,
        Quality = "decent",
        StockDate = new DateTime(2022, 10, 20),
        ManufactureYear = 2010

    },
    new Product()
    {
        Name = "Hockey Stick",
        Price = 12,
        Sold = false,
        Quality = "ehhhh",
        StockDate = new DateTime(2023, 11, 20),
        ManufactureYear = 2017
    },
    new Product()
    {
        Name = "Basketball Net",
        Price = 11,
        Sold = true,
        Quality = "great",
        StockDate = new DateTime(2012, 6, 21),
        ManufactureYear = 2013
    },
    new Product()
    {
        Name = "Baseball Glove",
        Price = 21,
        Sold = false,
        Quality = "okay",
        StockDate = new DateTime(2020, 3, 15),
        ManufactureYear = 2019
    }
};

Console.WriteLine("Products:");

for (int i = 0; i < products.Count; i++)
{
    Console.WriteLine($"{i + 1}. {products[i].Name}");
}
Console.WriteLine("Please enter a product number: ");

int response = int.Parse(Console.ReadLine().Trim());    //trim removes whitespace

while (response > products.Count || response < 1)  //checks to make sure something was typed.
{
    Console.WriteLine("Choose a number between 1 and 5!");
    response = int.Parse(Console.ReadLine().Trim());       //ReadLine returns line of characters from the input stream, or null if no more lines are available
}

Product chosenProduct = products[response - 1];
DateTime now = DateTime.Now;

TimeSpan timeInStock = now - chosenProduct.StockDate;

Console.WriteLine(@$"You chose: 
{chosenProduct.Name}, which costs {chosenProduct.Price} dollars.
It is {now.Year - chosenProduct.ManufactureYear} years old. 
It {(chosenProduct.Sold ? "is not available." : $"has been in stock for {timeInStock.Days} days, and is of {chosenProduct.Quality} quality.")}");

