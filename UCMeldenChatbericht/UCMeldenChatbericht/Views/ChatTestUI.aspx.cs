using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UCMeldenChatbericht.Views
{
    public partial class ChatTestUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblTestSession.Text = "false";
        }

        protected void btnReportAbuse_Click(object sender, EventArgs e)
        {
            lblTestSession.Text = "true";
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('MeldenChatberichtUI.aspx','_blank');", true);
        }
    }
}