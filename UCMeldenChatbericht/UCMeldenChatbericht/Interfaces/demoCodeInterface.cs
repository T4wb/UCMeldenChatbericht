using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UCMeldenChatbericht.Interfaces
{
    public class demoCodeInterface : IChat
    {
        public List<String[]> getMessages()
        {
            // message - user_Id - message_Id
            string[] testMessages = { "Je bent dom", "5", "1"}; // moet opgehaald worden uit db = delegate naar mensen die chat-component moeten maken.
            string[] testMessages1 = { "Ga naar je mama", "3", "2"};
            List<string[]> messages = new List<string[]>();
            messages.Add(testMessages);
            messages.Add(testMessages1);

            return messages;
        }
    }
}