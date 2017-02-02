﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UCMeldenChatbericht.Models
{
    public class InputUser
    {
        Dictionary<String, String> inputUser;
        public InputUser()
        {
            inputUser = new Dictionary<string, string>()
                {
                    { "ReportingUserID", ""}, // Deze is niet weg te schrijven naar de db. Haal hierbij User uit db; zie Report.cs + verwijder dit element
                    { "MessageID", ""},
                    { "Reason", ""},
                    { "ReportedUserID", ""},
                    { "Type", ""},
                };
        }
    }
}