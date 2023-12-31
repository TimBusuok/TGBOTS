using System;
using System.Linq;
using System.Threading.Tasks;


class TelegramMessagesModel
{
    public string token;
    public long update_id;
    public long chatId;
    public string text;
    public string first_name;
    private long id;

    string content;

    public TelegramMessagesModel(long chatId, long update_id, string text, string first_name)
    {
        this.chatId = chatId;
        this.update_id = update_id;
        this.first_name = first_name;
        this.text = text;
        if(text == "/start"){
            string content = $"Приветствую, выбирите функцию:\n{MesVar()}";
            this.text = content;
        }

        if (text == "/stop")
        {
            content = "Досвидание! Спасибо что использовали нашего бота";
            this.text = content;
        }
    }

    private string InlineKeyboardButton(InlineKeyboardMarkup inlineKeyboardMarkup)
    {
        throw new NotImplementedException();
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

    public static InlineKeyboardMarkup MesVar()
    {

            var button1 = new InlineKeyboardButton
            {
                Text = "Кнопка 1",
                CallbackData = "button1"
            };

            var button2 = new InlineKeyboardButton
            {
                Text = "Кнопка 2",
                CallbackData = "button2"
            };

            var replyMarkup = new InlineKeyboardMarkup(new[]
            {
                new[] { button1, button2 }
            });

            return replyMarkup;
        }
}

internal class InlineKeyboardMarkup
{
    private object[][] values;

    public InlineKeyboardMarkup(object[][] values)
    {
        this.values = values;
    }

    public override string ToString()
    {
        return string.Join(Environment.NewLine, values.Select(row => string.Join(", ", row)));
    }
}
