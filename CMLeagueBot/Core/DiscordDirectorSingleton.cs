using System;
using System.Collections.Generic;
using System.Text;

namespace CMLeagueBot.Core
{
    public partial class DiscordDirector
    {
        private static DiscordDirector _director { get; set; }
        public static DiscordDirector GetDirector()
        {
            if (_director == null)
            {
                _director = new DiscordDirector();
            }
            return _director;
        }

        private DiscordDirector()
        {

        }
    }
}
