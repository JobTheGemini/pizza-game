using PizzaGame.Core.Domain;
using PizzaGame.Core.Interfaces;

namespace PizzaGame.Core;

public class Game : IGame
{
    private readonly int _pizzaMin;
    private readonly int _pizzaMax;
    private List<int> _pizzaList = new List<int>();
    private int _lastAction;
    private Player _nextPlayer = Player.A;
    private Player? _winner;

    public Game(int pizzaMin, int pizzaMax)
    {
        _pizzaMin = pizzaMin;
        _pizzaMax = pizzaMax;
    }

    public void Start()
    {
        var random = new Random();
        _pizzaList = Enumerable.Range(0, random.Next(_pizzaMin, _pizzaMax + 1)).ToList();
        _nextPlayer = Player.A;
        _winner = null;
        _lastAction = 0;
    }

    public void Play(int eatenPizzas)
    {
        if (eatenPizzas is < 0 or > 3 || eatenPizzas == _lastAction || eatenPizzas > _pizzaList.Count)
        {
            throw new Exception("Invalid choice");
        }
        _pizzaList.RemoveRange(_pizzaList.Count - eatenPizzas, eatenPizzas);
        
        _lastAction = eatenPizzas;
        _nextPlayer = _nextPlayer == Player.A ? Player.B : Player.A;

        if (HasEatenPoisonedPizza() || NextPlayerSkipTurn(eatenPizzas))
        {
            _winner = _nextPlayer;
        }
    }

    public GameStatus GetStatus()
    {
        return new GameStatus
        {
            IsEnded = IsEnded(),
            NextPlayer = _nextPlayer,
            Winner = _winner,
            Pizzas = _pizzaList.Count,
            LastAction = _lastAction
        };
    }

    private bool IsEnded()
    {
        return _winner != null;
    }

    private bool HasEatenPoisonedPizza()
    {
        return _pizzaList.Count == 0;
    }

    private bool NextPlayerSkipTurn(int current)
    {
        return _pizzaList.Count == 1 && current == 1;
    }
}