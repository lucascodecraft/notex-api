using Notex.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notex.Domain.Repositories
{
    public interface INotexRepository
    {
        void Create(NotexItem notex);
        void Update(NotexItem notex);
        NotexItem GetById(Guid id, string user);
        IEnumerable<NotexItem> GetAll(string user);
        IEnumerable<NotexItem> GetDone(string user);
        IEnumerable<NotexItem> GetAllUndone(string user);
        IEnumerable<NotexItem> GetByPeriod(string user, DateTime date, bool done);
     }
}
