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
        MeldenChatberichtCC meldenChatBerichtCC;
        
        // 
        protected void Page_Load(object sender, EventArgs e)
        {
            //
            if (!Page.IsPostBack)
            {
                meldenChatBerichtCC = new MeldenChatberichtCC();
                // store chatMessages van CC
                chatMessages = meldenChatBerichtCC.showMessages();

                // show chatMessages in UI
                ddMessage.DataSource = chatMessages.Select(x => new { Message = x[0], Message_Id = x[1], User_Id = x[2] });
                ddMessage.DataTextField = "Message";
                ddMessage.DataBind();
                ddMessage.Items.Insert(0, new ListItem("Select an Item", ""));

                //
                meldenChatBerichtCC.requestCreateInputUser();

                // Viewstates
                //ViewState.Add("inputUser", inputUser);
                ViewState.Add("meldenChatBerichtCC", meldenChatBerichtCC);
                ViewState.Add("chatMessages", chatMessages);
            }
            else
            {
                // get stored data and overwrite all variables
                meldenChatBerichtCC = (MeldenChatberichtCC)ViewState["meldenChatBerichtCC"];
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
            if (checkddMessageReason())
            {
                // setInputUser()
                meldenChatBerichtCC.requestSetInputUser(chatMessages, ddMessage, tbReason);
                

                // send Report van CC
                bool createReportStatus = meldenChatBerichtCC.sendReport();

                // alertboxes komen hier
                if (createReportStatus)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('This user has been reported. Press Ok, then close the window.')", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Writing to the DB server failed. Please try again or contact an employee.')", true);
                }
            }
        }

        // Checks
        private bool checkddMessageReason()
        {
            //
            bool nonEmptySelection = true;

            if (ddMessage.SelectedIndex == 0)
            {
                // Melding: No ddMessage is selected!
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No user has been selected. Please select one.')", true);
                nonEmptySelection = false;
            }
            else if (string.IsNullOrWhiteSpace(tbReason.Text))
            {
                // Melding: Reason is Empty!
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No reason has been given. Please write one down.')", true);
                nonEmptySelection = false;
            }
            return nonEmptySelection;
        }
    }
}