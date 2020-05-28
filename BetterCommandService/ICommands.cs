using System;
using System.Collections.Generic;
using System.Text;

namespace BetterCommandService
{
    public interface ICommands
    {
        string CommandName { get; }
        string CommandDescription { get; }
        string CommandHelpMessage { get; }
        char[] Prefixes { get; }
        bool RequiresPermission { get; }
    }
}
