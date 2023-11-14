string greeting = @"Welcome to Thrown For  A Loop
Your one-stop shop for used sporting equipment";    //declare string to be referenced later

Console.WriteLine(greeting);    //same as console.log in js

List<Product> products = new List<Product>()
{
    new Product()
    {
        Name = "Football",
        Price = 15,
        Sold = false
    },
    new Product()
    {
        Name = "Hockey Stick",
        Price = 12,
        Sold = false
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
Console.WriteLine($"You chose: {chosenProduct.Name}, which costs {chosenProduct.Price} dollars and is {(chosenProduct.Sold ? "" : "not ")}sold.");

