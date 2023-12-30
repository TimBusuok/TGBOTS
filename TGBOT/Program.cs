
using System.ComponentModel;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;



string token = File.ReadAllText("C:\\Users\\Тимофей\\Desktop\\Telegabot\\.gitignore"); // установили путь к файлу токена 
TelegramBot bot = new TelegramBot(token);

void Updates(TelegramMessagesModel msg) // функция получения информации 
{
    bot.SendMessageAsync(msg.chatId,$"{msg.text}"); // написали id сообщения
}

bot.action = Updates;
bot.Start(); // запустили бота 

System.Console.WriteLine("++++");  









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