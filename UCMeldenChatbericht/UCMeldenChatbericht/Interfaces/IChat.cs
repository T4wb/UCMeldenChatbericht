using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCMeldenChatbericht.Interfaces
{
    interface IChat
    {
        List<String[]> getMessages(); // chat_Id
    }
}
