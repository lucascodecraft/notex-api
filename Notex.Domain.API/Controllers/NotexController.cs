using Microsoft.AspNetCore.Mvc;
using Notex.Domain.Commands;
using Notex.Domain.Core;
using Notex.Domain.Handlres;
using Notex.Domain.Model;
using Notex.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notex.Domain.API.Controllers
{
    [Route("api/Notex")]
    [ApiController]
    public class NotexController : ControllerBase
    {
        private readonly INotexRepository _notexRepository;

        public NotexController(INotexRepository notexRepository)
        {
            _notexRepository = notexRepository;
        }

        [Route("")]
        [HttpGet]
        public IEnumerable<NotexItem> GetAll()
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id") ?.Value;
            return _notexRepository.GetAll(user);
        }

        [Route("done")]
        [HttpGet]
        public IEnumerable<NotexItem> GetAllDone()
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return _notexRepository.GetDone(user);
        }

        [Route("undone")]
        [HttpGet]
        public IEnumerable<NotexItem> GetUndone()
        {
            var user = User.Claims.FirstOrDefault((x => x.Type == "user_id"))?.Value;
            return _notexRepository.GetAllUndone(user);
        }

        [Route("done/today")]
        [HttpGet]
        public IEnumerable<NotexItem> GetDoneForToday()
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return _notexRepository.GetByPeriod(user, DateTime.Now.Date, true);
        }

        [Route("undone/today")]
        [HttpGet]
        public IEnumerable<NotexItem> GetInactiveForToday()
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return _notexRepository.GetByPeriod(user, DateTime.Now.Date, false);
        }

        [Route("done/tomorrow")]
        [HttpGet]
        public IEnumerable<NotexItem> GetDoneForTomorrow()
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return _notexRepository.GetByPeriod(user, DateTime.Now.Date.AddDays(1), true);
        }

        [Route("undone/tomorrow")]
        [HttpGet]
        public IEnumerable<NotexItem> GetUndoneForTomorrow()
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return _notexRepository.GetByPeriod(user, DateTime.Now.Date.AddDays(1), false);
        }

        [Route("")]
        [HttpPost]
        public Task<CommandResult> Create(CreateNotexCommand command, [FromServices]NotexCommandHandler handler)
        {
            command.User =  User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return handler.Handle(command, new System.Threading.CancellationToken());
        }

        [Route("")]
        [HttpPut]
        public Task<CommandResult> Update(UpadateNotexCommand command, [FromServices]NotexCommandHandler handler)
        {
            command.User = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return handler.Handle(command, new System.Threading.CancellationToken());
        }

        [Route("mark-as-done")]
        [HttpPost]
        public Task<CommandResult> MaskAsDone(MarkNotexAsDoneCommand command, [FromServices]NotexCommandHandler handler)
        {
            command.User = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return handler.Handle(command, new System.Threading.CancellationToken());
        }

        [Route("mark-as-undone")]
        [HttpPost]
        public Task<CommandResult> MaskAsUndone(MarkNotexAsUndoneCommand command, [FromServices]NotexCommandHandler handler)
        {
            command.User = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return handler.Handle(command, new System.Threading.CancellationToken());
        }
    }
}