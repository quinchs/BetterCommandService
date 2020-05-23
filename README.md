# BetterCommandService
## A Custom command service for discord bots

---
### Why?

The default command service with the [Discord.net Package](https://github.com/discord-net/Discord.Net) is limited on what you can do.

for example you have to permission check each method. this can be a bit tedious, with the custom command service you can specify methods that get executed to check the permissions for the commands.
you can also use multi-prefix commands.


### Usage

To create a `CommandService` instance

```csharp
CustomCommandService _service = new CustomCommandService(new Settings()
{
  //settings object 
});
```

#### The Settings contains a bunch of useful options.

```csharp
char DefaultPrefix;
```
> The Default prefix for the Command Service


```csharp
Func<SocketCommandContext, bool> HasPermissionMethod;
```
> This method will be called and when a command is called and checkes if the user has permission to execute the command, this result will be in the `CommandModuleBase.HasExecutePermission` if you dont set this, the `CommandModuleBase.HasExecutePermission` will always be true

```csharp
Dictionary<ulong, Func<SocketCommandContext, bool>> CustomGuildPermissionMethod;
```
> A Dictionary containing specific permission methods for guilds, The Key would be the Guilds ID, and the value would be a Method that takes `SocketCommandContext` and returns a boolean. this will overwrite the `HasPermissionMethod` if the guilds permission method is added


```csharp
bool DMCommands;
```
> Boolean indicating if commands can be accessable in Direct messages, default value is false

```csharp
bool AllowCommandExecutionOnInvalidPermissions;
```
> If the user has invalid permissions to execute the command and this bool is true then the command will still execute with the `CommandModuleBase.HasExecutePermission` set to false. Default is false.

***

### Creating a Command
To make a command use the `DiscordCommand` attribute inside a `DiscordCommandClass` like this

```csharp
[DiscordCommandClass()]
public class MyCommandClass : CommandModuleBase
{
    [DiscordCommand("test")]
    public async Task MyCommand
}
```

You want to inherit the `CommandModuleBase` because it has alot of useful properties for your command
```csharp
bool HasExecutePermission;
```
> true If the user has execute permission based on the `Settings.HasPermissionMethod` or `Settings.CustomGuildPermissionMethod`
```csharp
SocketCommandContext Context;
```
> The Context of the current command
```csharp 
Dictionary<string, string> CommandHelps;
```
> Contains all the help messages. Key is the command name, Value is the help message
```csharp
Dictionary<string, string> CommandDescriptions;
```
> Contains all the description messages. Key is the command name, Value is the Command Description
```cs
List<ICommands> Commands;
```
> Mega-List of all commads

***

### Specifying Custom command properties
with this custom command service you can tell the command service more info about your command, for example
```csharp
[DiscordCommand("unblock",                             //The command name 
description = "unblocks a user from creating threads", //The command Description
BotCanExecute = false,                                 //Bots cannot use this command
commandHelp = "Parameters:\n`(PREFIX)unblock <user>`", //The command help
prefixes = new char[] { '!', '*' },                    //The allowed prefix for this command
RequiredPermission = true                              //Required permmision based on the permission method in the settings object
)]
public async Task Unblock(params string[] args)
{
    //code
}
```
### Executing Commands
When i comes to executing your commands its really simple
```csharp
// create command service and subscribe to the message recieved event
CustomCommandService _service = new CustomCommandService(new Settings()
{
  //settings object 
});
_client.MessageReceived += HandleCommandAsync;

public async Task HandleCommandAsync(SocketMessage s)
{
    //option one: same thread execution
    if(_service.ContainsUsedPrefix(msg.Content))
    {
        var result = await _service.ExecuteAsync(context);
        //do somthing with the result object
    }
    //Option two: new thread execution (prefered)
    if(_service.ContainsUsedPrefix(msg.Content))
    {
        new Thread(async ()  => 
        {
            var result = await _service.ExecuteAsync(context);
            //do somthing with the result object
        }).Start();
    }
}

```
### ICommandResult
the `ICommandResult` object contains alot of useful information about the execution
```csharp
bool IsSuccess;
```
> true the execution of the command is successful
```csharp
CommandStatus Result;
```
> The status of the commands execution
```csharp
bool MultipleResults;
```
> a bool indicating if there was multiple results, if true look in the `Results` object
```csharp
ICommandResult[] Results;
```
> The Multi-Result Array
```csharp
Exception Exception;
```
> Exception if there was an error


## Summary
The was alot i didnt go over and its a good idea to experiment with the code to find the best use for your bot. if you have any questions or concers open an issue or contact me directly on discord: quin#3017
