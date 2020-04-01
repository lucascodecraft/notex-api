using System;
using System.Collections.Generic;
using System.Text;
using Flunt.Validations;

namespace Notex.Domain.Commands
{
    public sealed class CreateNotexCommand : CommandBase
    {
        public CreateNotexCommand()
        { }

        public CreateNotexCommand(string title, string user, DateTime date)
        {
            Title = title;
            User = user;
            Date = date;
        }

        public string Title { get; set; }
        public string User { get; set; }
        public DateTime Date { get; set; }

        public override void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(Title, 3, nameof(Title), "O Titulo deve ser maior que 3")
                .HasMinLen(User, 6, nameof(Title), "Usuário invalido"));
                }
    }
}
