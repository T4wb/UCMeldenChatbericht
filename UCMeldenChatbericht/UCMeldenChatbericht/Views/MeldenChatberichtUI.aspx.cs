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
        List<string[]> chatMessages;
        Dictionary<String, String> inputUser;
        MeldenChatberichtCC meldenChatBerichtCC;
        
        // 
        protected void Page_Load(object sender, EventArgs e)
        {
            // 
            meldenChatBerichtCC = new MeldenChatberichtCC();

            if (!Page.IsPostBack)
            {
                // store chatMessages van CC
                chatMessages = meldenChatBerichtCC.showMessages();

                // show chatMessages in UI
                ddMessage.DataSource = chatMessages.Select(x => new { Message = x[0], Message_Id = x[1], User_Id = x[2] });
                ddMessage.DataTextField = "Message";
                ddMessage.DataBind();
                ddMessage.Items.Insert(0, new ListItem("Select an Item", ""));

                // inputUser
                inputUser = new Dictionary<string, string>()
                {
                    { "ReportingUserID", ""}, // Deze is niet weg te schrijven naar de db. Haal hierbij User uit db; zie Report.cs + verwijder dit element
                    { "MessageID", ""},
                    { "Reason", ""},
                    { "ReportedUserID", ""},
                    { "Type", ""},
                };

                // Viewstates
                ViewState.Add("inputUser", inputUser);
                ViewState.Add("chatMessages", chatMessages);
            }
            else
            {
                // get stored data and overwrite all variables
                inputUser = (Dictionary<String, String>)ViewState["inputUser"];
                chatMessages = (List<string[]>)ViewState["chatMessages"];
            }
        }

        // Event handler
        protected void ddMessage_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblUserName.Text = (ddMessage.SelectedIndex != 0) ? (chatMessages[ddMessage.SelectedIndex-1][1]) : "No user is selected";
        }

        // 
        protected void selectSubmitReport(object sender, EventArgs e)
        {
            bool ddMessagetbReasonValue = false;

            // Checks
            if (ddMessage.SelectedIndex == 0)
            {
                // Melding: No ddMessage is selected!
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No user has been selected. Please select one.')", true);
            }
            else if (string.IsNullOrWhiteSpace(tbReason.Text))
            {
                // Melding: Reason is Empty!
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No reason has been given. Please write one down.')", true);
            }
            else
            {
                // setInputUser()
                setInputUser();

                // send Report van CC
                bool createReportStatus = meldenChatBerichtCC.sendReport(inputUser);

                // alertboxes komen hier
                if (createReportStatus)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('This user has been reported. Press Ok, then close the window.')", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Writing to DB failed. Please try again or contact an employee.')", true);
                }
            }
        }

        private void setInputUser()
        {
            inputUser["ReportingUserID"] = "999"; // To Do: Ophalen uit sessie?
            inputUser["MessageID"] = chatMessages[ddMessage.SelectedIndex - 1][2];
            inputUser["Reason"] = tbReason.Text;
            inputUser["Type"] = "Chatbericht";
            inputUser["ReportedUserID"] = chatMessages[ddMessage.SelectedIndex - 1][1];
        }
    }
}