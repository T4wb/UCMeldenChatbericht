using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using UCMeldenChatbericht.Controllers;
using UCMeldenChatbericht.Interfaces;

// Opmerking: ddUser is misschien niet nodig want het bericht wordt opgehaald: gestript op User_Id + message_Id

namespace UCMeldenChatbericht.Views
{
    public partial class MeldenChatberichtUI : System.Web.UI.Page
    {
        //
        Dictionary<String, String> inputUser;
        MeldenChatberichtCC meldenChatBerichtCC;
        List<string[]> messages;

        // 
        protected void Page_Load(object sender, EventArgs e)
        {
            // 
            meldenChatBerichtCC = new MeldenChatberichtCC();

            if (!Page.IsPostBack)
            {
                // show messages van CC
                messages = meldenChatBerichtCC.showMessages();
                ddMessage.DataSource = messages.Select(x => new { Message = x[0], Message_Id = x[1], User_Id = x[2] });
                ddMessage.DataTextField = "Message";
                ddMessage.DataBind();
                // ddMessage.Items.Insert(0, new ListItem("SelectItem", "")); // To Do: toevoegen standaard default
                inputUser = new Dictionary<string, string>()
                {
                    { "user_Id", ""}, // Deze is niet weg te schrijven naar de db.
                    { "message_Id", ""},
                    { "reason", ""},
                    { "reported_User_Id", ""},
                    { "type", ""},
                };

                //
                ViewState.Add("inputUser", inputUser);
                ViewState.Add("messages", messages);
            }
            else
            {
                // get stored data and overwrite all variables
                inputUser = (Dictionary<String, String>)ViewState["inputUser"];
                messages = (List<string[]>)ViewState["messages"];
            }
        }

        // Event handler
        protected void ddMessage_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblUserName.Text = messages[ddMessage.SelectedIndex][1]; // shows userName in lblUserName => nu is er alleen een User_Id, via een interface moet een userName opgehaald kunnen worden.
        }

        // 
        protected void selectSubmitReport(object sender, EventArgs e)
        {
            // To Do: checks
            // Checks komen hier
            if (ddMessage.SelectedIndex == 0)
            {
                // Melding: No ddMessage is selected!
            }
            if (string.IsNullOrWhiteSpace(tbReason.Text))
            {
                // Melding: Reason is Empty!
            }

            // prepare report
            inputUser["user_Id"] = messages[ddMessage.SelectedIndex][1];
            inputUser["message_Id"] = messages[ddMessage.SelectedIndex][2];
            inputUser["reason"] = tbReason.Text;
            inputUser["type"] = "Chatbericht"; 
            inputUser["reported_User_Id"] = "3"; // To Do: Ophalen uit sessie?

            // send Report van CC
            meldenChatBerichtCC.sendReport(inputUser);
        }


    }
}