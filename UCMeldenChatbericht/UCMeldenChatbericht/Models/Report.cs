using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace UCMeldenChatbericht.Models
{
    public partial class Report
    {
        // In Production code: IUser Iuser = new ImplementedInterfaceName();

        // accessors & mutators
        private void setReport(Dictionary<String, String> inputUser)
        {
            // In Production Code: using Iuser to get Account object:
            // int tempReportingUserID
            // bool parsed = Int32.TryParse(inputUser["ReportingUserID"], out tempReportingUserID);
            //if (parsed)
            //{
            //   Account = implementedInterface.getAccount(tempReportingUserID) // Let op: controleer propertynaam
            //}

            // 
            ReportingUserID = inputUser["ReportingUserID"]; // In production code: see above
            MessageID = inputUser["MessageID"];
            Reason = inputUser["Reason"];
            ReportedUserID = inputUser["ReportedUserID"];
            Type = inputUser["Type"];
        }
        public bool createReport(Dictionary<String, String> inputUser)
        {
            //
            bool createReportStatus = true;

            // setReport
            setReport(inputUser);

            //
            createReportStatus = checkReport(createReportStatus);

            if (createReportStatus)
            {
                createReportStatus = writeToDBReport(createReportStatus);
            }
            return createReportStatus;
        }

        // DB controle
        private bool checkReport(bool createReportStatus)
        {
            // Check every property except id and ReportedUserID
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