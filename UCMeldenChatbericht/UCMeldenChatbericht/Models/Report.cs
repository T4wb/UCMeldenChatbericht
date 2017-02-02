using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI.WebControls;

namespace UCMeldenChatbericht.Models
{
    public partial class Report
    {
        //
        InputUser inputUser = new InputUser();

        public void setInputUser(List<string[]> chatMessages, DropDownList ddMessage, TextBox tbReason)
        {
            inputUser.setInputUser(chatMessages, ddMessage, tbReason);
        }

        // In Production code: IUser Iuser = new ImplementedInterfaceName();

        // accessors & mutators
        public bool createReport()
        {
            //
            bool createReportStatus = true;

            // setReport
            setReport(inputUser);

            // checkReport
            createReportStatus = checkReport(createReportStatus);

            if (createReportStatus)
            {
                createReportStatus = writeToDBReport(createReportStatus);
            }
            return createReportStatus;
        }

        private void setReport(InputUser inputUser)
        {
            // In Production Code: using Iuser to get Account object:
            // int tempReportingUserID
            // bool parsed = Int32.TryParse(inputUser["ReportingUserID"], out tempReportingUserID);
            //if (parsed)
            //{
            //   Account = implementedInterface.getAccount(tempReportingUserID) // Let op: controleer propertynaam
            //}

            // 
            ReportingUserID = inputUser.getInputUser()["ReportingUserID"]; // In production code: see above
            MessageID = inputUser.getInputUser()["MessageID"];
            Reason = inputUser.getInputUser()["Reason"];
            ReportedUserID = inputUser.getInputUser()["ReportedUserID"];
            Type = inputUser.getInputUser()["Type"];
        }


        // DB controle: Check every property except id and ReportedUserID
        private bool checkReport(bool createReportStatus)
        {
            
            List<PropertyInfo> properties = (typeof(Report).GetProperties()).ToList();
            properties.Remove(properties[0]); // To Do: Hierbij ook verwijderen: ReportedUserID; maar dan uit de inputUser List<string> deze wordt bovenaan los gekoppeld met de property Account. Controle op NULL blijft!

            // In Production code: + add this
            //if (Account == null)
            //{
            //    createReportStatus = false;
            //}

            for (int i = 0; i < properties.Count && createReportStatus; i++)
            {
                if (string.IsNullOrWhiteSpace(properties[i].GetValue(this).ToString()))
                {
                    createReportStatus = false;
                }
            }
            return createReportStatus;
        }

        private bool writeToDBReport(bool createReportStatus)
        {
            using (ChatModelContainer context = new ChatModelContainer())
            {
                context.Reports.Add(this);
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
            return createReportStatus;
        }
    }
}