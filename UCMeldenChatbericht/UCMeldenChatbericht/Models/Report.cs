using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace UCMeldenChatbericht.Models
{
    public partial class Report
    {
        // accessors & mutators
        public bool createReport()
        {
            //
            bool createReportStatus = true;
             
            //
            using (ChatModelContainer context = new ChatModelContainer())
            {
                // check every property
                foreach (PropertyInfo info in typeof(Report).GetProperties())
                {
                    Console.Write(info.GetValue(this));
                } 

                   
                string.IsNullOrWhiteSpace("");
                if ((this.message_Id != null || this.message_Id != "") || (this.Reported_User_Id != null || this.Reported_User_Id != "")) // nog meer eigenschappen die niet null mogen zijn?
                {
                    context.Reports.Add(this); // To Do: hoe sla je dit op in db? Is this wel goed? // zie voorbeeld op github van mvdlaar

                    try
                    {
                        context.SaveChanges();
                    }
                    catch (System.Data.Entity.Core.EntityException)
                    {
                        new Exception("Database is offline.");
                        createReportStatus = false;
                    }
                }
            }
            // return value
            return createReportStatus;
        }
    }
}