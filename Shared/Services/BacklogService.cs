using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.Models;

namespace Shared.Services
{
    public class BacklogService
    {
        private List<Backlog> _backlogs;

        public List<Backlog> Backlogs
        {
            get => new(_backlogs);
            init => _backlogs = new List<Backlog>();
        }

        public void AddBacklog(Backlog backlog) => _backlogs.Add(backlog);

        public void RemoveBacklog(int backlogId)
        {
            try
            {
                var backlog = _backlogs.FirstOrDefault(b => b.BacklogId == backlogId, null);
                if (backlog == null) throw new IndexOutOfRangeException($"Backlog ID not found: {backlogId}");
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
            }
        }

        public void UpdateBacklog(int backlogId)
        {
            try
            {
                var backlog = _backlogs.FirstOrDefault(b => b.BacklogId == backlogId, null);
                if (backlog == null) throw new IndexOutOfRangeException($"Backlog ID not found: {backlogId}");
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
            }
        }

    }
}