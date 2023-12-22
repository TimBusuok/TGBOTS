

using System.Net.Http;

string token = File.ReadAllText("token.config");
HttpClient hc = new();
hc.BaseAddress = new Uri($"https://api.telegram.org/bot{token}/");

string ContentObj = hc.GetStringAsync("getme").Result;
System.Console.WriteLine(ContentObj);




















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