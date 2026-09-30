using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using Microsoft.EntityFrameworkCore;
using Shared.Models;
using BacklogServer.Models;

namespace BacklogServer.Repositories
{
    public class BacklogDbRepository : IBacklogRepository
    {
        private List<Backlog> _backlogs;

        private BacklogAppDbContext _dbContext = new BacklogAppDbContext();
        private int _nextID = 1;

        public int NextID {get;}

        public List<Backlog> Backlogs
        {
            get => new(_backlogs);
            init => _backlogs = new List<Backlog>();
        }

        public void AddBacklog(Backlog backlog) 
        {
            _dbContext.Backlogs.Add(backlog);
            _dbContext.SaveChanges();
        }
        public async Task AddBacklogAsync(Backlog backlog) 
        {
            await _dbContext.Backlogs.AddAsync(backlog);
            await _dbContext.SaveChangesAsync();
        }

        public void RemoveBacklog(int backlogId) 
        {
            var backlog = _dbContext.Backlogs.Find(backlogId);
            if (backlog is not null)
            {
                _dbContext.Backlogs.Remove(backlog);
                _dbContext.SaveChanges();    
            }
            else Console.Error.WriteLine($"Unable to remove backlog {backlogId}.");
            
        }
        public async Task RemoveBacklogAsync(int backlogId) 
        {
            var backlog = await _dbContext.Backlogs.FindAsync(backlogId);
            if (backlog is not null)
            {
                _dbContext.Backlogs.Remove(backlog);
                _dbContext.SaveChanges();    
            }
            else await Console.Error.WriteLineAsync($"Unable to remove backlog {backlogId}.");
        }

        public Backlog? GetBacklog(int backlogId)
        {
            var backlog = _dbContext.Backlogs.Find(backlogId);
            if (backlog is not null) return backlog;
            else 
            {
                Console.Error.WriteLine($"Unable to retrieve backlog {backlogId}.");
                return null;
            }
        }
        public async Task<Backlog?> GetBacklogAsync(int backlogId)
        {
            var backlog = await _dbContext.Backlogs.FindAsync(backlogId);
            if (backlog is not null) return backlog;
            else 
            {
                await Console.Error.WriteLineAsync($"Unable to retrieve backlog {backlogId}.");
                return null;
            }
        }

        public List<Backlog>? GetBacklogs() => _dbContext.Backlogs.ToList<Backlog>();
        public async Task<List<Backlog>?> GetBacklogsAsync() => await _dbContext.Backlogs.ToListAsync<Backlog>();

        public void UpdateBacklog(int backlogId, Backlog updatedBacklog)
        {
            var backlog = _dbContext.Backlogs.Find(backlogId);
            if (backlog is not null)
            {
                backlog.Name = updatedBacklog.Name;
                backlog.Items = updatedBacklog.Items;
               _dbContext.SaveChanges();    
            }
            else Console.Error.WriteLine($"Unable to update backlog {backlogId}.");
        }

        public async Task UpdateBacklogAsync(int backlogId, Backlog updatedBacklog)
        {
            var backlog = await _dbContext.Backlogs.FindAsync(backlogId);
            if (backlog is not null)
            {
                backlog.Name = updatedBacklog.Name;
                backlog.Items = updatedBacklog.Items;
               _dbContext.SaveChanges();    
            }
            else await Console.Error.WriteLineAsync($"Unable to update backlog {backlogId}.");
        }

    }
}