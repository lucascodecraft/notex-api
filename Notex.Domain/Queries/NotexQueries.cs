using Notex.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Notex.Domain.Queries
{
    public static class NotexQueries
    {
        public static Expression<Func<NotexItem, bool>> GetAll(string user)
        {
            return x => x.User == user;
        }

        public static Expression<Func<NotexItem, bool>> GetAllDone(string user)
        {
            return x => x.User == user && x.Done == true;
        }

        public static Expression<Func<NotexItem, bool>> GetAllUndone(string user)
        {
            return x => x.User == user && x.Done == false;
        }

        public static Expression<Func<NotexItem, bool>> GetByPeriod(string user, DateTime date, bool done)
        {
            return x =>
            x.User == user &&
            x.Done == done &&
            x.Date.Date == date.Date;
        }
    }
}
