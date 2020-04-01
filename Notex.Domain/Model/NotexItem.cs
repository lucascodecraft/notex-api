using System;
using System.Collections.Generic;
using System.Text;

namespace Notex.Domain.Model
{
    public class NotexItem : Entity
    {
        public NotexItem(string title, string user, bool done, DateTime date)
        {
            Title = title;
            User = user;
            Done = done;
            Date = date;
        }

        public string Title { get; private set; }
        public bool Done { get; private set; }
        public DateTime Date { get; set; }
        public string User { get; set; }

        public void MarkAsDone() => Done = true;

        public void MarkAsUndone() => Done = false;

        public void UpdateTitle(string title) => Title = title;
    }
}
