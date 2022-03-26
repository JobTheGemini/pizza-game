using PizzaGame.Core.Domain;

namespace PizzaGame.Core.Interfaces;

public interface IGame
{
    void Start();
    void Play(int eatenPizzas);
    GameStatus GetStatus();
}