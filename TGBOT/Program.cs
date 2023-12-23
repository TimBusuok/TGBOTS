
using System.ComponentModel;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

string token = File.ReadAllText("C:\\Users\\Тимофей\\Desktop\\Telegabot\\BOT\\TGBOT\\token.config");
HttpClient hc = new();
hc.BaseAddress = new Uri($"https://api.telegram.org/bot{token}/");


string ContentObj = hc.GetStringAsync("getme").Result;
var obj = JObject.Parse(ContentObj);
System.Console.WriteLine(obj["ok"]);




















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