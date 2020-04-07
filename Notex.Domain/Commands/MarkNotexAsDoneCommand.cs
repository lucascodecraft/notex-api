using Flunt.Validations;
using Notex.Domain.Core.Commands;
using System;

namespace Notex.Domain.Commands
{
    public class MarkNotexAsDoneCommand : CommandBase
    {
        public MarkNotexAsDoneCommand() { }

        public MarkNotexAsDoneCommand(Guid id, string user)
        {
            Id = id;
            User = user;
        }

        public Guid Id { get; set; }
        public string User { get; set; }

        public override void Validate() => AddNotifications(new Contract()
                .HasMinLen(User, 6, nameof(User), "Usuário invalido"));
    }
}
