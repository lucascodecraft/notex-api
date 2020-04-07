using MediatR;
using Notex.Domain.Commands;
using Notex.Domain.Core;
using Notex.Domain.Model;
using Notex.Domain.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Notex.Domain.Handlres
{
    public class NotexCommandHandler : 
        IRequestHandler<CreateNotexCommand, CommandResult>,
        IRequestHandler<UpadateNotexCommand, CommandResult>,
        IRequestHandler<MarkNotexAsDoneCommand, CommandResult>,
        IRequestHandler<MarkNotexAsUndoneCommand, CommandResult>
    {
        private readonly INotexRepository _notexRepository;

        public NotexCommandHandler(INotexRepository notexRepository)
        {
            _notexRepository = notexRepository;
        }

        public Task<CommandResult> Handle(CreateNotexCommand command, CancellationToken cancellationToken)
            => Create(command).AsTask;

        public Task<CommandResult> Handle(UpadateNotexCommand command, CancellationToken cancellationToken)
            => UpdateTitle(command).AsTask;

        public Task<CommandResult> Handle(MarkNotexAsDoneCommand command, CancellationToken cancellationToken)
            => MarkAsDone(command).AsTask;

        public Task<CommandResult> Handle(MarkNotexAsUndoneCommand command, CancellationToken cancellationToken)
            => MarkAsUndone(command).AsTask;

        private CommandResult Create(CreateNotexCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new Exception("Sua tarefa está errada");

            var notex = new NotexItem(command.Title, command.User, command.Date);

            _notexRepository.Create(notex);

            return CommandResult.Success();
        }

        private CommandResult UpdateTitle(UpadateNotexCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new Exception("Sua tarefa está errada");

            var notex =_notexRepository.GetById(command.Id, command.User);

            notex.UpdateTitle(command.Title);

            _notexRepository.Update(notex);

            return CommandResult.Success();
        }

        private CommandResult MarkAsDone(MarkNotexAsDoneCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new Exception("Sua tarefa está errada");

            var notex = _notexRepository.GetById(command.Id, command.User);

            notex.MarkAsDone();

            _notexRepository.Update(notex);

            return CommandResult.Success();
        }

        private CommandResult MarkAsUndone(MarkNotexAsUndoneCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new Exception("Sua tarefa está errada");

            var notex = _notexRepository.GetById(command.Id, command.User);

            notex.MarkAsUndone();

            _notexRepository.Update(notex);

            return CommandResult.Success();
        }
    }
}
