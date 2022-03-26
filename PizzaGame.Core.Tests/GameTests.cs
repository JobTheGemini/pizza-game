using System.Collections.Generic;
using PizzaGame.Core.Domain;
using Xunit;

namespace PizzaGame.Core.Tests;

public class GameTests
{
    [Fact]
    public void TestOnGameStartPizzasShouldBeHigherThanMinValue()
    {
        const int pizzaMin = 11;
        const int pizzaMax = 100;
        
        var game = new Game(pizzaMin, pizzaMax);
        game.Start();
        
        Assert.True(game.GetStatus().Pizzas > pizzaMin);
    }

    [Fact]
    public void TestExample1()
    {
        var game = new Game(12, 12);
        game.Start();

        var actions = new List<(Player, int, int, int)>()
        {
            (Player.A, 12, 0, 1),
            (Player.B, 11, 1, 3),
            (Player.A, 8, 3, 2),
            (Player.B, 6, 2, 1),
            (Player.A, 5, 1, 3),
            (Player.B, 2, 3, 2)
        };

        GameStatus? status;
        foreach (var (nextPlayer, pizzas, lastAction, nextAction) in actions)
        {
            status = game.GetStatus();
            Assert.False(status.IsEnded);
            Assert.Equal(nextPlayer, status.NextPlayer);
            Assert.Equal(pizzas, status.Pizzas);
            Assert.Equal(lastAction, status.LastAction);
            game.Play(nextAction);
        }

        status = game.GetStatus();
        Assert.True(status.IsEnded);
        Assert.Equal(Player.A, status.Winner);
    }
    
    [Fact]
    public void TestExample2()
    {
        var game = new Game(12, 12);
        game.Start();

        var actions = new List<(Player, int, int, int)>()
        {
            (Player.A, 12, 0, 1),
            (Player.B, 11, 1, 3),
            (Player.A, 8, 3, 2),
            (Player.B, 6, 2, 1),
            (Player.A, 5, 1, 3),
            (Player.B, 2, 3, 1),
        };
        
        GameStatus? status;
        foreach (var (nextPlayer, pizzas, lastAction, nextAction) in actions)
        {
            status = game.GetStatus();
            Assert.False(status.IsEnded);
            Assert.Equal(nextPlayer, status.NextPlayer);
            Assert.Equal(pizzas, status.Pizzas);
            Assert.Equal(lastAction, status.LastAction);
            game.Play(nextAction);
        }
        
        status = game.GetStatus();
        Assert.True(status.IsEnded);
        Assert.Equal(Player.A, status.Winner);
    }
    
}