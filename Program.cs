Dictionary<string, string> sizeOptions = new Dictionary<string, string>() {
        { "1", "small" },
        { "2", "medium" },
        { "3", "large" }
    };

Dictionary<string, string> baseOptions = new Dictionary<string, string>() {
        { "1", "thin" },
        { "2", "thick" }
    };

Dictionary<string, string> toppingOptions = new Dictionary<string, string>() {
        { "1", "pepperoni" },
        { "2", "chicken" },
        { "3", "extra cheese" },
        { "4", "mushroom" },
        { "5", "spinach" },
        { "6", "olives" }
    };

Dictionary<string, string> orderActions = new Dictionary<string, string>() {
        { "1", "confirm" },
        { "2", "alter" },
        { "3", "cancel" }
    };

Console.Write("How many pizzas do you want to order?: ");
int pizzaAmount = Convert.ToInt32(Console.ReadLine());

List<string> chosenToppings = new List<string>();
Pizza[] pizzas = new Pizza[pizzaAmount];
OrderPizzas();

void OrderPizzas()
{
    for (int i = 0; i < pizzaAmount; i++)
    {
        Console.Write("What size pizza do you want? (1) small, (2) medium, (3) large: ");
        string size = sizeOptions[Console.ReadLine()!];

        Console.Write("What base do you want? (1) thin, (2) thick: ");
        string baseType = baseOptions[Console.ReadLine()!];

        Console.Write("How many toppings do you want?: ");
        int toppingAmount = Convert.ToInt32(Console.ReadLine());

        List<string> toppings = new List<string>();

        for (int j = 0; j < toppingAmount; j++)
        {
            Console.Write("What topping do you want? (1) pepperoni, (2) chicken, (3) extra cheese, (4) mushroom, (5) spinach, (6) olives: ");
            string topping = toppingOptions[Console.ReadLine()!];
            toppings.Add(topping);
            chosenToppings.Add(topping);
        }

        Pizza newPizza = new Pizza();
        newPizza.Size = size;
        newPizza.BaseType = baseType;
        newPizza.Toppings = toppings;
        pizzas[i] = newPizza;
    }

    Console.Write("How would you like to proceed? (1) confirm, (2) alter, (3) cancel: ");
    string orderAction = orderActions[Console.ReadLine()!];

    switch (orderAction)
    {
        case "confirm":
            Console.WriteLine($"Your order has been confirmed! Order number is {new Random().Next(101)}.");
            break;
        case "alter":
            Console.WriteLine("Restarting order...");
            OrderPizzas();
            break;
        case "cancel":
            Console.WriteLine("Your order has been cancelled!");
            break;
    }
}

Topping mostPopularTopping = new Topping();
mostPopularTopping.Name = chosenToppings.GroupBy(x => x).OrderByDescending(x => x.Count()).Select(x => x.Key).First();
mostPopularTopping.Percentage = (int)Math.Round(((float)chosenToppings.GroupBy(x => x).OrderByDescending(x => x.Count()).Select(x => x.Count()).First() / chosenToppings.Count) * 100);

Topping leastPopularTopping = new Topping();
leastPopularTopping.Name = chosenToppings.GroupBy(x => x).OrderBy(x => x.Count()).Select(x => x.Key).First();
leastPopularTopping.Percentage = (int)Math.Round(((float)chosenToppings.GroupBy(x => x).OrderBy(x => x.Count()).Select(x => x.Count()).First() / chosenToppings.Count) * 100);

Console.WriteLine($"The most popular topping was {mostPopularTopping.Name} with a percentage of {mostPopularTopping.Percentage}%.");
Console.WriteLine($"The least popular topping was {leastPopularTopping.Name} with a percentage of {leastPopularTopping.Percentage}%.");

struct Pizza
{
    public string Size;
    public string BaseType;
    public List<string> Toppings;
}

struct Topping
{
    public string Name;
    public int Percentage;
}