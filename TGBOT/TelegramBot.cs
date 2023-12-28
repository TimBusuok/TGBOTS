using System.Net.Http.Headers;

class TelegramBot{
    string token;
    public Action<TelegramMessagesModel>action;
    Thread thread;
    HttpClient hc;

    public TelegramBot(string token){
        this.token = token;
        hc = new HttpClient();
        hc.BaseAddress = new Uri($"https://api.telegram.org/bot{token}/");
        thread = new Thread(GetUpdates);
    }

private void GetUpdates()
{
    long offset = 0;
    HttpClient hc = new HttpClient(); // Initialize the HttpClient object
    
    while (true)
    {
        string content = hc.GetStringAsync($"https://api.telegram.org/bot{token}/getupdates?offset={offset + 1}").Result;
        try
        {
            TelegramMessagesModel[] ms = new JsonParsers().GetMessage(content);
            if (ms.Length != 0)
            {
                foreach (var item in ms)
                {
                    Console.WriteLine(item);
                    action(item);
                    offset = item.update_id;
                }
            }
        }
        catch
        {
            Console.WriteLine("ERROR!!!");
        }
        Thread.Sleep(1000);
    }
}
    public void SendMessage(long update_id, string text){
        #region
        #endregion
    }

    public void Start(){
        thread.Start();
    }
}
