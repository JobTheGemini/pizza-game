using Microsoft.AspNetCore.SignalR;
using PizzaGame.Core.Interfaces;

namespace PizzaGame.Web;

public class GameHub : Hub
{
    private readonly IGame _pizzaGame;

    public GameHub(IGame pizzaGame)
    {
        _pizzaGame = pizzaGame;
    }

    public void StartMessage()
    {
        _pizzaGame.Start();
        SendGameUpdateMessage();
    }
    
    public void ActionMessage(int eatenPizzas)
    {
        try
        {
            _pizzaGame.Play(eatenPizzas);
            SendGameUpdateMessage();
        }
        catch (Exception e)
        {
            SendErrorMessage(e.Message);
        }
    }
    
    private void SendGameUpdateMessage()
    {
        Clients.All.SendAsync("GameUpdate", _pizzaGame.GetStatus().ToString());
    }
    
    private void SendErrorMessage(string message)
    {
        Clients.All.SendAsync("Error", message);
    }

}