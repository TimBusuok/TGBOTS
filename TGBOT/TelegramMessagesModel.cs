using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Threading.Tasks;


class TelegramMessagesModel
{
    public string token = File.ReadAllText("C:\\Users\\Тимофей\\Desktop\\Telegabot\\.gitignore");
    public long update_id;
    public long chatId;
    public string text;
    public string first_name;
    private long id;
    string content;

    public TelegramMessagesModel(long chatId, long update_id, string text, string first_name)
    {
        TelegramBot bot = new TelegramBot(token);
        this.chatId = chatId;
        this.update_id = update_id;
        this.first_name = first_name;
        this.text = text;

        switch(text){
            case "/start":
            content = "Приветствуем!\nВыбирите дальнейшие действия в меню";
            this.text = content;
            break;
            case "/info":
            content = "Этот бот был создан ради того чтобы вам помочь в узновании космоса 🌌\nНаши функции:\nПодробности о всех известных планетах🪐(/planet);\nКакой праздник сегодня🎉(/party);\n";
            this.text = content;
            break;
            case "/stop":
            content = "Досвидание! Приятно с вами работать))😊";
            this.text = content;
            break;
        }
    }
    public override string ToString()
    {
        return $"{first_name}:{text} -> {chatId};{update_id}"; // получение сообщения бота
    }

    // public void Various(string text)
    // {
    //     string moon = "луна";
    //     string earth = "земля";
    //     switch (text)
    //     {
    //         case "луна":
    //             this.text = moon;
    //             break;

    //         case "земля":
    //             this.text = earth;
    //             break;
    //     }
    // }


}
