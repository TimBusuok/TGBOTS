using Newtonsoft.Json.Linq;
using System.Collections.Generic;

class JsonParsers
{
    internal TelegramMessagesModel[] GetMessage(string content)
    {
        List<TelegramMessagesModel> msgs = new List<TelegramMessagesModel>(); // Initialize a list to store the messages

        JToken[] data = JObject.Parse(content)["result"].ToArray(); // Parse the JSON and get the "result" array

        foreach (dynamic item in data) // Iterate over each item in the "result" array
        {
            long id = item.message.from.id;
            string text = item.message.text;
            long update_id = item.update_id;
            string first_name = item.message.from.first_name;

            TelegramMessagesModel message = new TelegramMessagesModel(id, update_id, text, first_name); // Create a new instance of TelegramMessagesModel
            msgs.Add(message); // Add the message to the list
        }

        return msgs.ToArray(); // Convert the list to an array and return it
    }
}