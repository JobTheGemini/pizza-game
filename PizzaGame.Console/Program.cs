using PizzaGame.Core;
using PizzaGame.Core.Domain;

const int minPizzas = 11;
const int maxPizzas = 100;

var game = new Game(minPizzas, maxPizzas);
game.Start();

GameStatus status;
while (!(status = game.GetStatus()).IsEnded)
{
    Console.WriteLine($"Round: {status.NextPlayer}. There are still {status.Pizzas} pizzas");
    try
    {
        Console.Write("How many pizzas do you want?");
        var result = int.Parse(Console.ReadLine()!);
        game.Play(result);
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
}
Console.WriteLine($"The winner is {game.GetStatus().Winner}");