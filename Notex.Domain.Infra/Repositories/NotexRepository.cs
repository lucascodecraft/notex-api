using Microsoft.EntityFrameworkCore;
using Notex.Domain.Infra.Contexts;
using Notex.Domain.Model;
using Notex.Domain.Queries;
using Notex.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Notex.Domain.Infra.Repositories
{
    public class NotexRepository : INotexRepository
    {
        private readonly DataContext _context;
        public NotexRepository(DataContext context)
        {
            _context = context;
        }

        public void Create(NotexItem notex)
        {
            _context.Notex.Add(notex);
            _context.SaveChanges();
        }

        public IEnumerable<NotexItem> GetAll(string user)
        {
            return _context.Notex
                .AsNoTracking()
                .Where(NotexQueries.GetAll(user))
                .OrderBy(x => x.Date);
        }

        public IEnumerable<NotexItem> GetDone(string user)
        {
            return _context.Notex
                .AsTracking()
                .Where(NotexQueries.GetAllDone(user))
                .OrderBy(x => x.Date);
        }

        public IEnumerable<NotexItem> GetAllUndone(string user)
        {
            return _context.Notex
                .AsTracking()
                .Where(NotexQueries.GetAllUndone(user))
                .OrderBy(x => x.Date);
        }

        public NotexItem GetById(Guid id, string user)
        {
            return _context.Notex.FirstOrDefault(x => x.Id == id && x.User == user);
        }

        public IEnumerable<NotexItem> GetByPeriod(string user, DateTime date, bool done)
        {
            return _context.Notex
                .AsTracking()
                .Where(NotexQueries.GetByPeriod(user, date, done))
                .OrderBy(x => x.Date);
        }

        public void Update(NotexItem notex)
        {
            _context.Entry(notex).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
