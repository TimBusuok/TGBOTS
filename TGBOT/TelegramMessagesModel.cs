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

    public long update_id;
    public long chatId;
    public string text;
    public string first_name;
    private long id;
    string content;
    string party;

    public TelegramMessagesModel(long chatId, long update_id, string text, string first_name)
    {
        
        this.chatId = chatId;
        this.update_id = update_id;
        this.first_name = first_name;
        this.text = text;
        this.content = "";
        this.party = "";


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
            case "/planet":
            content = Planet();
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
        string res = $"Сегодня ({dataRes}) такие праздники🎉🎉:\n{ShowHolidays(date)}";
        return res;
    }
    public string ShowHolidays(DateTime date){
        string incrementedDateTime = date.AddDays(1).ToString();
        string res = incrementedDateTime.Remove(incrementedDateTime.Length - 13);
        switch(res){
            case "01.01" or "02.01" or "03.01" or "04.01" or "05.01" or "06.01" or "08.01": 
            party = $"Новогодние праздники⛄🎅"; 
            return party;
            
            case "07.01":
            party = "Новогодние праздники⛄🎅\nРождество🎄"; 
            return party;
            
            case "23.02":
            party = "День Защитника Отечества🏋️💪";
            return party;
            
            case "08.03":
            party = "Международный женский день🌹🌹";
            return party;
            
            case "01.05":
            party = "Праздник Весны и Труда🌿👔";
            return party;
            
            case "09.05":
            party = "День Победы🎆🎆";
            return party;
            
            case "04.11":
            party = "День народного единства👨👩👳🧕";
            return party;

            case "12.06":
            party = "День России \U0001F1F7\U0001F1FA ";
            return party;
            
        }
        return $"Cегодня праздников нет😔";
    } 
   public string Planet(){
        string qwestion = "Выбирите планету🔭:\nМеркурий(/mercure)\nВенера(/venera)\nЗемля(/earth)\nМарс(/mars)\nЮпитер(/jupiter)\nСатурн(/saturn)\nУран(/uran)\nНептун(/neptun)";
        int R = 0;
        int D = 0;
        int S = 0;
        int S1 = 0;
        long population = 0;
        // content = "Отправляются данные";
        // this.text = content;
        // content = "Ещё чуть-чуть";
        // this.text = content;
        // content = "Связываемся со спутником🛰️";
        // this.text = content;
        string res = InfoPlanet(qwestion,R,D,S,S1,population);
        return res;
   }
   public string InfoPlanet(string qwestion,int R,int D,int S,int S1,long population){
        switch(qwestion){
            case "/mercure":
            R = R + 2440;
            D = D + 4878;
            S = S + 46000000;
            S1 = S1 + 90000000;
            content = $"Данные планеты получены👾📡:\nРадиус = {R}км\nДиаметр = {D}км\nРасстояние до Солнца = {S}км\nРасстояние до Земли = {S1}км\n Популяция = никого нету(может пару вездеходов🛰️)";
            return content;

            case "/venera":
            R = R + 6052;
            D = D + 12104;
            S = S + 110000000;
            S1 = S + 38000000;
            content = $"Данные планеты получены👾📡:\nРадиус = {R}км\nДиаметр = {D}км\nРасстояние до Солнца = {S}км\nРасстояние до Земли = {S1}км\n Популяция = никого нету(может пару вездеходов🛰️)";
            return content;

            case "/earth":
            R = R + 6378;
            D = D + 12712;
            S = S + 149600000;
            population = population + 8000000000;
            content = $"Данные планеты получены👾📡:\nРадиус = {R}км\nДиаметр = {D}км\nРасстояние до Солнца = {S}км\nРасстояние до Земли = {S1}км\n Популяция = {population}";
            return content;
        }
        return "Данные не получены, проверьте запрос";
   }
}



