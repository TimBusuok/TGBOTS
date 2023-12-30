using System.Numerics;

class TelegramMessagesModel{

    public long update_id;
    public long chatId;
    public string text;

    public string first_name;
    private long id;

    string content;

    public TelegramMessagesModel(long chatId,long update_id,string text,string first_name){
        this.chatId = chatId;
        this.update_id = update_id;
        this.first_name = first_name;
        this.text = text;

        if(text == "/start"){
            content = "Приветствуем Вас!!\nВыбирите вариации того, чего вы хотите:";
            this.text = content;
        }
    }
    public override string ToString()
    {
        return $"{first_name}:{text} -> {chatId};{update_id}"; // получение сообщения бота
    }
}
