using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace LichessNetBot.Types
{
    class LichessGame
    {
        public string url { get; private set; }
        public bool inprogress { get; set; }

        LichessGame(string lichesslink)
        {
            url = lichesslink;
            inprogress = false;
        }
    }
}
