
using Newtonsoft.Json.Linq;

class JsonParsers
{
    string content;
   internal TelegramMessagesModel[] GetMessage(string content)
    {
        List<TelegramMessagesModel> msgs = new(); // запустили лист всех сообщений 
        JToken[] data = JObject.Parse(content)["result"].ToArray(); // разобрали JSON сообщений

        foreach (dynamic item in data) // цикл по разборке JSONа 
        {
            long id = item.message.from.id;
            string text = item.message.text;
            long update_id = item.update_id;
            string first_name = item.message.from.first_name;

            msgs.Add(new(id,update_id,text,first_name)); // обновили сообщения новым данными 

            
            
        }
        return msgs.ToArray();
    }
}