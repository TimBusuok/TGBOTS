
using System.ComponentModel;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

string token = File.ReadAllText("C:\\Users\\Тимофей\\Desktop\\Telegabot\\BOT\\.gitignore");
HttpClient hc = new();
hc.BaseAddress = new Uri($"https://api.telegram.org/bot{token}/");

int offset = 0;
string ContentObj = hc.GetStringAsync($"getUpdates?offset={offset}").Result;
var obj = JObject.Parse(ContentObj);
JArray message = JArray.Parse(obj["result"].ToString());

for(int i = 0;i < message.Count;i++){
    System.Console.Write($"{message[i]["message"]["from"]["first_name"]} ->");
    System.Console.Write($"{message[i]["message"]["text"]}");
}

System.Console.WriteLine(message.Count);






















class GetMesModel
{
    bool ok;
    ResultModel result;

}

class ResultModel
{
    long id;
    bool is_bot;
    string first_name;
    string username;
    bool can_join_groups;
    bool can_read_all_group_messages;
    bool supports_inline_queries;
}