using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notex.Domain.Commands
{
    public class CommandBase : Notifiable, IValidatable
    {
        public virtual void Validate() { }
    }
}
