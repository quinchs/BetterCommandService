using System;
using System.Collections.Generic;
using System.Text;

namespace BetterCommandService
{
    internal struct Commands : ICommands
    {
        public string CommandName { get; set; }
        public string CommandDescription { get; set; }
        public string CommandHelpMessage { get; set; }
        public bool RequiresPermission { get; set; }
        public char[] Prefixes { get; set; }
    }
}
