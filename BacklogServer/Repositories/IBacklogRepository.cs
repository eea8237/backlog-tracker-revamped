using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.Models;

namespace BacklogServer.Repositories
{
    public interface IBacklogRepository
    {
        void AddBacklog(Backlog backlog);
        void RemoveBacklog(int backlogId);
        void UpdateBacklog(int backlogId, Backlog updatedBacklog);
        Backlog? GetBacklog(int backlogId);
        List<Backlog>? GetBacklogs();

        Task AddBacklogAsync(Backlog backlog);
        Task RemoveBacklogAsync(int backlogId);
        Task UpdateBacklogAsync(int backlogId, Backlog updatedBacklog);
        Task<Backlog?> GetBacklogAsync(int backlogId);
        Task<List<Backlog>?> GetBacklogsAsync();

    }
}