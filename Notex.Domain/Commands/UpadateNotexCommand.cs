using Flunt.Validations;
using System;

namespace Notex.Domain.Commands
{
    public class UpadateNotexCommand : CommandBase
    {
        public UpadateNotexCommand() { }

        public UpadateNotexCommand(Guid id, string title, string user)
        {
            Id = id;
            Title = title;
            User = user;
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string User { get; set; }

        public override void Validate() => AddNotifications(new Contract()
                .Requires()
                .HasMinLen(Title, 3, nameof(Title), "Por favor, descreva melhor esta tarefa!")
                .HasMinLen(User, 6, nameof(User), "Usuário invalido"));
    }
}
