using System;
using System.Collections.Generic;
using System.Text;

namespace BetterCommandService
{
    /// <summary>
    /// The Command Result, this contains the <see cref="CommandStatus"/> enum and a <see cref="Exception"/> object if there was an error.
    /// </summary>
    public interface ICommandResult
    {
        /// <summary>
        /// <see langword="true"/> the execution of the command is successful
        /// </summary>
        bool IsSuccess { get; }
        /// <summary>
        /// The status of the command
        /// </summary>
        CommandStatus Result { get; }
        /// <summary>
        /// a <see cref="bool"/> determining if there was multiple results, if true look in <see cref="Results"/>
        /// </summary>
        bool MultipleResults { get; }
        /// <summary>
        /// The multi-Result Array
        /// </summary>
        ICommandResult[] Results { get; }

        /// <summary>
        /// Exception if there was an error
        /// </summary>
        Exception Exception { get; }
    }
    /// <summary>
    /// Status of the command
    /// </summary>
    public enum CommandStatus
    {
        /// <summary>
        /// The command executed successfully
        /// </summary>
        Success,
        /// <summary>
        /// There was an error with the execution, look at the exception in <see cref="CommandResult.Exception"/>
        /// </summary>
        Error,
        /// <summary>
        /// Could not find a command, if this is a mistake check if you have the <see cref="DiscordCommand"/> attribute attached to the command
        /// </summary>
        NotFound,
        /// <summary>
        /// The command was found but there was not enough parameters passed for the command to execute correctly
        /// </summary>
        NotEnoughParams,
        /// <summary>
        /// The parameters were there but they were unable to be parsed to the correct type
        /// </summary>
        InvalidParams,
        /// <summary>
        /// If the user has incorrect permissions to execute the command
        /// </summary>
        InvalidPermissions,
        /// <summary>
        /// Somthing happend that shouldn't have, i dont know what to say here other than :/
        /// </summary>
        Unknown
    }
}
