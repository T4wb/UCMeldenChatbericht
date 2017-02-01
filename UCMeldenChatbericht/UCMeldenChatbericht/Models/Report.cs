using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UCMeldenChatbericht.Models
{
    public partial class Report
    {
        // accessors & mutators
        public void createReport()
        {
            using (ChatModelContainer context = new ChatModelContainer())
            {
                if ((this.message_Id != null || this.message_Id != "") || (this.Reported_User_Id != null || this.Reported_User_Id != "") || (this.Reported_User_Id != "")) // nog meer eigenschappen die niet null mogen zijn?
                {
                    // To Do: met Try?
                    context.Reports.Add(this); // To Do: hoe sla je dit op in db? Is this wel goed? // zie voorbeeld op github van mvdlaar
                    context.SaveChanges();
                }
                
            }
        }
    }
}