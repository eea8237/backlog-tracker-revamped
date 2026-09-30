using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BacklogServer.Repositories;
using Shared.Models;

namespace BacklogServer.Services
{
    /// <summary>
    /// Service for managing backlog business logic.
    /// </summary>
    public class BacklogService
    {
        private IBacklogRepository _backlogRepository;

        private List<Backlog> _backlogs;
        private int _nextID = 1;

        public int NextID {get;}

        public List<Backlog> Backlogs
        {
            get => new(_backlogs);
            init => _backlogs = new List<Backlog>();
        }

        public BacklogService(IBacklogRepository backlogRepository)
        {
            _backlogRepository = backlogRepository;
        }

        public void AddBacklog(Backlog backlog) 
        {
            _backlogRepository.AddBacklog(backlog);
            _nextID++;
        }
        public async Task AddBacklogAsync(Backlog backlog) 
        {
            await _backlogRepository.AddBacklogAsync(backlog);
            _nextID++;
        }

        public Backlog? GetBacklog(int backlogId)
        {
            Backlog? backlog = null;
            try
            {
                backlog = _backlogRepository.GetBacklog(backlogId);
                // backlog = _backlogs.FirstOrDefault(b => b.BacklogId == backlogId, null);
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
                backlog = await _backlogRepository.GetBacklogAsync(backlogId);
                // backlog = _backlogs.FirstOrDefault(b => b.BacklogId == backlogId, null);
                if (backlog == null) throw new IndexOutOfRangeException($"Backlog ID not found: {backlogId}");
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
            }
            return backlog;
        }

        public List<Backlog>? GetBacklogs()
        {
            return _backlogRepository.GetBacklogs();
        }
        public async Task<List<Backlog>?> GetBacklogsAsync() 
        {
            return await _backlogRepository.GetBacklogsAsync();
        }


        public void RemoveBacklog(int backlogId)
        {
            try
            {
                _backlogRepository.RemoveBacklog(backlogId);
                // var backlog = _backlogs.FirstOrDefault(b => b.BacklogId == backlogId, null);
                // if (backlog == null) throw new IndexOutOfRangeException($"Backlog ID not found: {backlogId}");
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
                await _backlogRepository.RemoveBacklogAsync(backlogId);
                // var backlog = _backlogs.FirstOrDefault(b => b.BacklogId == backlogId, null);
                // if (backlog == null) throw new IndexOutOfRangeException($"Backlog ID not found: {backlogId}");
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
                _backlogRepository.UpdateBacklog(backlogId, updatedBacklog);
                // var backlog = _backlogs.FirstOrDefault(b => b.BacklogId == backlogId, null);
                // if (backlog == null) throw new IndexOutOfRangeException($"Backlog ID not found: {backlogId}");
                // backlog = updatedBacklog;
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
                await _backlogRepository.UpdateBacklogAsync(backlogId, updatedBacklog);
                // var backlog = _backlogs.FirstOrDefault(b => b.BacklogId == backlogId, null);
                // if (backlog == null) throw new IndexOutOfRangeException($"Backlog ID not found: {backlogId}");
                // backlog = updatedBacklog;
            }
            catch (Exception e)
            {
                await Console.Error.WriteLineAsync(e.Message);
            }
        }

        
    }
}