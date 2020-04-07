using Flunt.Notifications;
using Flunt.Validations;
using MediatR;
using Notex.Domain.Core;

namespace Notex.Domain.Core.Commands
{
    public class CommandBase : Notifiable, IValidatable, IRequest<CommandResult>
    {
        public virtual void Validate() { }
    }
}
