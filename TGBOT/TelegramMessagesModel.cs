using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Data;


class TelegramMessagesModel
{
    public long chatId;
    public long update_id;
    public string text;
    public string first_name;

    public TelegramMessagesModel(long chatId, long update_id, string text, string first_name)
    {
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
            content = "Этот бот был создан ради того чтобы вам помочь в узновании космоса 🌌\nНаши функции:\nПодробности о всех известных планетах🪐(/planet);\nКакой праздник сегодня🎉(/party);\nКакие Знаки Зодиака существуют(/zz)";
            this.text = content;
            break;
            case "/stop":
            content = "Досвидание! Приятно с вами работать))😊";
            this.text = content;
            break;
            case "/party":
            content = CheckDay();
            this.text = content;
            break;
            
        }
    }
    public override string ToString()
    {
        return $"{first_name}:{text} -> {chatId};{update_id}"; // получение сообщения бота
    }

    public string CheckDay(){
        DateTime date = new DateTime();
        string incrementedDateTime = date.AddDays(1).ToString();
        string dataRes = incrementedDateTime.Remove(incrementedDateTime.Length - 13);
        string hollidays = ShowHolidays(date);
        string res = $"Сегодня ({dataRes}) такие праздники🎉🎉:\n{hollidays}";
        return res;
    }
    public string ShowHolidays(DateTime date)
    {
    string incrementedDateTime = date.AddDays(1).ToString();
    string res = incrementedDateTime.Remove(incrementedDateTime.Length - 13);
    string party = "";

    switch (res)
    {
        case "01.01":
        case "02.01":
        case "03.01":
        case "04.01":
        case "05.01":
        case "06.01":
        case "08.01":
            party = "Новогодние праздники⛄🎅";
            break;

        case "07.01":
            party = "Новогодние праздники⛄🎅\nРождество🎄";
            break;

        case "23.02":
            party = "День Защитника Отечества🏋️💪";
            break;

        case "08.03":
            party = "Международный женский день🌹🌹";
            break;

        case "01.05":
            party = "Праздник Весны и Труда🌿👔";
            break;

        case "09.05":
            party = "День Победы🎆🎆";
            break;

        case "04.11":
            party = "День народного единства👨👩👳🧕";
            break;

        case "12.06":
            party = "День России 🇷🇺";
            break;

        default:
            party = "Cегодня праздников нет😔";
            break;
    }

    return party;
}
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



