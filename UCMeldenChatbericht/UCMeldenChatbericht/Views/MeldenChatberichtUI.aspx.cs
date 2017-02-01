using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using UCMeldenChatbericht.Controllers;
using UCMeldenChatbericht.Interfaces;

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
                ddMessage.Items.Insert(0, new ListItem("Select an Item", "")); // To Do: toevoegen standaard default zonder onderdeel te zijn van List

                inputUser = new Dictionary<string, string>()
                {
                    { "user_Id", ""}, // Deze is niet weg te schrijven naar de db. Haal hierbij User uit db
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
            lblUserName.Text = (ddMessage.SelectedIndex != 0) ? (messages[ddMessage.SelectedIndex-1][1]) : "No user is selected";
        }

        // 
        protected void selectSubmitReport(object sender, EventArgs e)
        {
            // To Do: checks
            // Checks komen hier
            if (ddMessage.SelectedIndex == 0)
            {
                // Melding: No ddMessage is selected!
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No user has been selected. Please select one.')", true);
            }
            else if (string.IsNullOrWhiteSpace(tbReason.Text))
            {
                // Melding: Reason is Empty!
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No reason has been selected. Please select one.')", true);
            }
            else
            {
                // prepare report // Refactor: dit in BU doen?
                inputUser["user_Id"] = messages[ddMessage.SelectedIndex - 1][1];
                inputUser["message_Id"] = messages[ddMessage.SelectedIndex - 1][2];
                inputUser["reason"] = tbReason.Text;
                inputUser["type"] = "Chatbericht";
                inputUser["reported_User_Id"] = "3"; // To Do: Ophalen uit sessie?

                // send Report van CC
                bool createReportStatus = meldenChatBerichtCC.sendReport(inputUser);

                // notifications komen hier
                if (createReportStatus)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('This user has been reported. Press Ok to close the window.')", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Writing to DB failed. Please try again or contact an employee.')", true);
                }
                
                // To Do: close window and return to the previous window.
            } 
        }
    }
}