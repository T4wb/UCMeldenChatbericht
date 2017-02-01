using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using UCMeldenChatbericht.Models;
using UCMeldenChatbericht.Interfaces;

namespace UCMeldenChatbericht.Controllers
{
    public class MeldenChatberichtCC
    {
        //
        Report report = new Report();
        IChat Ichat = new demoCodeInterface(); // test

        // 
        public List<String[]> showMessages() // return: Message[] 
        {
            List<string[]> messages = Ichat.getMessages();
            return messages;
        }

        // 
        public void sendReport(Dictionary<String, String> inputUser) // uit User Interface: User ophalen. Kan dit ook via showMessages()
        {
            //
            report.message_Id = inputUser["message_Id"];
            report.Reason = inputUser["reason"];
            report.Reported_User_Id = inputUser["reported_User_Id"];
            report.Type = inputUser["type"];
            report.user_Id = inputUser["user_Id"]; // hoe werkt dit? Dit is niet weg te schrijven naar de db! Deze verwacht een User. Hoe is deze op te halen?

            //
            report.createReport();
        }
    }
}