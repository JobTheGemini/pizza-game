using Newtonsoft.Json;

namespace PizzaGame.Core.Domain;

public class GameStatus
{
    public bool IsEnded { get; set; }
    public Player NextPlayer { get; set; }
    public Player? Winner { get; set; }
    public int Pizzas { get; set; }
    public int LastAction { get; set; }

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }    
}