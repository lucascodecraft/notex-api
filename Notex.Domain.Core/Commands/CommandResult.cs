using System;
using System.Threading.Tasks;

namespace Notex.Domain.Core
{
    public class CommandResult
    {
        public CommandResult() { }

        public CommandResult(Exception exception) => Exception = exception;

        public Exception Exception { get; }

        public Task<CommandResult> AsTask => Task.FromResult(this);

        public bool IsSuccess => Exception == null;

        public static CommandResult Success() => new CommandResult();

        public static implicit operator bool(CommandResult result) => result.IsSuccess;

        public static implicit operator CommandResult(Exception exception) => new CommandResult(exception);
    }
}
