using Microsoft.AspNetCore.SignalR.Client;
namespace Chess.App.Data;

public interface IChatService
{
    public void SendMessage(string message);
    public event EventHandler<string> ReceiveMessage;
}

public class ChatService : IChatService
{
    private HubConnection _connection;

    public ChatService()
    {
        _connection = new HubConnectionBuilder().WithUrl("http://192.168.134.49:5066/chat").Build(); ;

        _connection.On<string>("MessageReceived", (message) =>
        {
            ReceiveMessage?.Invoke(this, message);
        });

        Task.Run(() =>
        {
            Application.Current.Dispatcher.Dispatch(async () => await _connection.StartAsync());
        });
    }

    public async void SendMessage(string msg)
    {
        await _connection.InvokeCoreAsync("SendMessage", args: new[] { msg });
    }

    public event EventHandler<string> ReceiveMessage;
}

