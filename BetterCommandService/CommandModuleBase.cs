using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BetterCommandService
{
    public abstract class CommandModuleBase : CommandModuleBase<ICommandContext> { }

    /// <summary>
    /// The Class to interface from.
    /// </summary>
    public abstract class CommandModuleBase<T> where T : class, ICommandContext
    {
        /// <summary>
        /// If the user has execute permission based on the <see cref="CustomCommandService.Settings.HasPermissionMethod"/>
        /// </summary>
        public static bool HasExecutePermission { get; set; }
        /// <summary>
        /// The Context of the current command
        /// </summary>
        public T Context { get; internal set; }

        /// <summary>
        /// Contains all the help messages. Key is the command name, Value is the help message
        /// </summary>
        public static Dictionary<string, string> CommandHelps { get; internal set; }

        /// <summary>
        /// Contains all the help messages. Key is the command name, Value is the Command Description
        /// </summary>
        public static Dictionary<string, string> CommandDescriptions { get; internal set; }
        /// <summary>
        /// The superlist with all the commands
        /// </summary>
        public static List<ICommands> Commands { get; internal set; }
        /// <summary>
        ///     Sends a message to the source channel.
        /// </summary>
        /// <param name="message">
        /// Contents of the message; optional only if <paramref name="embed" /> is specified.
        /// </param>
        /// <param name="isTTS">Specifies if Discord should read this <paramref name="message"/> aloud using text-to-speech.</param>
        /// <param name="embed">An embed to be displayed alongside the <paramref name="message"/>.</param>
        protected virtual async Task<IUserMessage> ReplyAsync(string message = null, bool isTTS = false, Embed embed = null, RequestOptions options = null)
        {
            return await Context.Channel.SendMessageAsync(message, isTTS, embed, options).ConfigureAwait(false);
        }

    }
}
