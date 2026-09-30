using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.Models;

namespace BacklogServer.Repositories
{
    /// <summary>
    /// Service for managing backlog storage.
    /// </summary>
    public class BacklogFileRepository : IBacklogRepository
    {
        private List<Backlog> _backlogs;
        private int _nextID = 1;

        public int NextID {get;}

        public List<Backlog> Backlogs
        {
            get => new(_backlogs);
            init => _backlogs = new List<Backlog>();
        }

        private void Save()
        {
            // save changes
        }
        private void Load()
        {
            // load from file
        }

        public void AddBacklog(Backlog backlog) 
        {
            _backlogs.Add(backlog);
            _nextID++;
        }
        public async Task AddBacklogAsync(Backlog backlog) 
        {
            _backlogs.Add(backlog);
            _nextID++;
        }

        public Backlog? GetBacklog(int backlogId)
        {
            Backlog? backlog = null;
            try
            {
                backlog = _backlogs.FirstOrDefault(b => b.BacklogId == backlogId, null);
                if (backlog == null) throw new IndexOutOfRangeException($"Backlog ID not found: {backlogId}");
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
            }
            return backlog;
        }

        public async Task<Backlog?> GetBacklogAsync(int backlogId)
        {
            Backlog? backlog = null;
            try
            {
                backlog = _backlogs.FirstOrDefault(b => b.BacklogId == backlogId, null);
                if (backlog == null) throw new IndexOutOfRangeException($"Backlog ID not found: {backlogId}");
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
            }
            return backlog;
        }

        public List<Backlog>? GetBacklogs() => Backlogs;
        public async Task<List<Backlog>?> GetBacklogsAsync() => Backlogs;


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
        public async Task RemoveBacklogAsync(int backlogId)
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

        // todo
        public void UpdateBacklog(int backlogId, Backlog updatedBacklog)
        {
            try
            {
                var backlog = _backlogs.FirstOrDefault(b => b.BacklogId == backlogId, null);
                if (backlog == null) throw new IndexOutOfRangeException($"Backlog ID not found: {backlogId}");
                backlog = updatedBacklog;
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
            }
        }
        public async Task UpdateBacklogAsync(int backlogId, Backlog updatedBacklog)
        {
            try
            {
                var backlog = _backlogs.FirstOrDefault(b => b.BacklogId == backlogId, null);
                if (backlog == null) throw new IndexOutOfRangeException($"Backlog ID not found: {backlogId}");
                backlog = updatedBacklog;
            }
            catch (Exception e)
            {
                await Console.Error.WriteLineAsync(e.Message);
            }
        }

        
    }
}