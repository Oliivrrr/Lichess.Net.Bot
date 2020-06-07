using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace LichessNetBot.Types
{
    class ChessGame
    {
        public string url { get; private set; }
        public bool inprogress { get; set; }

        ChessGame(string lichesslink)
        {
            url = lichesslink;
            inprogress = false;
        }
    }
}
