using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using UCMeldenChatbericht.Models;
using UCMeldenChatbericht.Interfaces;
using System.Web.UI.WebControls;

namespace UCMeldenChatbericht.Controllers
{
    public class MeldenChatberichtCC
    {
        //
        Report report = new Report();
        IChat Ichat = new demoCodeInterface(); // This for testing only. In productie instantie maken van werkelijke IChat

        // 
        public List<String[]> showMessages() 
        {
            List<string[]> messages = Ichat.getMessages();
            return messages;
        }

        // 
        public bool sendReport() // uit Interface van User: User ophalen. Uit showMessages haal je het ID op, vervolgens roep je wanneer je createReport uitvoert de Interface aan aan met de user_Id als argument.
        {
            bool createReportStatus = report.createReport();
            return createReportStatus;
        }

        public void requestSetInputUser(List<string[]> chatMessages, DropDownList ddMessage, TextBox tbReason)
        {
            report.setInputUser(chatMessages, ddMessage, tbReason);
        }
    }
}