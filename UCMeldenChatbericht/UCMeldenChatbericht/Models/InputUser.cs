using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace UCMeldenChatbericht.Models
{
    public class InputUser
    {
        private Dictionary<String, String> inputUser;
        public InputUser()
        {
            inputUser = new Dictionary<string, string>()
                {
                    { "ReportingUserID", ""}, // Deze is niet weg te schrijven naar de db. Haal hierbij User uit db; zie Report.cs + verwijder dit element
                    { "MessageID", ""},
                    { "Reason", ""},
                    { "ReportedUserID", ""},
                    { "Type", ""},
                };
        }
        public Dictionary<String, String> getInputUser()
        {
            return inputUser;
        }

        public void setInputUser(List<string[]> chatMessages, DropDownList ddMessage, TextBox tbReason)
        {
            inputUser["ReportingUserID"] = "999"; // To Do: Ophalen uit sessie?
            inputUser["MessageID"] = chatMessages[ddMessage.SelectedIndex - 1][2];
            inputUser["Reason"] = tbReason.Text;
            inputUser["Type"] = "Chatbericht";
            inputUser["ReportedUserID"] = chatMessages[ddMessage.SelectedIndex - 1][1];
        }
    }
}