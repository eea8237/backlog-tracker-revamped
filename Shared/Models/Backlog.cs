using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shared.Models
{
    /*
    backlogs contain items, can be sorted/filtered by all of the above categories. if a category doesn't contain any items it isn't displayed.
    */
    public class Backlog
    {
        private string _name;
        /// <summary>
        /// items the backlog contains
        /// </summary>
        private List<BacklogItem> _items; // considering how these things are sorted shouldn't this be a dictionary
        /// <summary>
        /// id for identifying user the backlog belongs to
        /// </summary>
        private readonly int _userId;
        /// <summary>
        /// Backlog ID. Just in case.
        /// used to differentiate between the backlogs owned by a user
        /// </summary>
        private readonly int _backlogId;

        /// <summary>
        /// name for the backlog?
        /// </summary>
        public string Name
        {
            get {return _name;}
            set {_name = value;}
        }

        public List<BacklogItem> Items
        {
            get => _items;
            init => new List<BacklogItem>();
        }

        public int UserId
        {
            get => _userId;
            init => _userId = value;
        }

        public int BacklogId
        {
            get => _backlogId;
            init => _backlogId = value;
        }

        /// <summary>
        /// Initialize a backlog with a list of items.
        /// Used if there's already backlog data, presumably.
        /// </summary>
        /// <param name="name">Name of the backlog</param>
        /// <param name="items">List of items the backlog contains.</param>
        /// <param name="userId">ID of user who owns backlog.</param>
        /// <param name="backlogId">ID for backlog</param>
        // public Backlog(string name, List<BacklogItem> items, int userId, int backlogId)
        // {
        //     _name = name;  // this is the only thing explicitly provided by the user
        //     _userId = userId;
        //     _backlogId = backlogId;
        //     _items = items;
        // }

        /// <summary>
        /// Initialize an empty backlog.
        /// </summary>
        /// <param name="name">Name of the backlog</param>
        /// <param name="userId">ID of user who owns backlog.</param>
        /// <param name="backlogId">ID for backlog</param>
        // public Backlog(string name, int userId, int backlogId)
        // {
        //     this(name, new List<BacklogItem>(), userId, backlogId);
        // }

        public override string ToString()
        {
            var itemNames = new List<string>();
            foreach (var item in Items) itemNames.Add(item.Name);
            return "Backlog:\n" +
                $"\tUserID: {UserId}\n" +
                $"\tBacklogID: {BacklogId}\n" +
                $"\tName: {Name}\n" +
                $"\tItems: {itemNames}";
        }

        public BacklogItem GetByName(string name)
        {
            return Items.FirstOrDefault(i => i.Name == name);
        }
        public BacklogItem GetById(int id)
        {
            return Items.FirstOrDefault(i => i.ItemId == id);
        }
        public List<BacklogItem> GetByMedium(string medium)
        {
            return Items.FindAll(i => i.Medium == medium);
        }

        public List<BacklogItem> GetBySeries(string series)
        {
            return Items.FindAll(i => i.Series == series);
        }

        public List<BacklogItem> GetByCompletion(bool isComplete)
        {
            return Items.FindAll(i => i.IsComplete == isComplete);
        }

        public List<BacklogItem> GetByOwnership(bool isOwned)
        {
            return Items.FindAll(i => i.IsOwned == isOwned);
        }

        public List<BacklogItem> GetByProgression(bool inProgress)
        {
            return Items.FindAll(i => i.InProgress == inProgress);
        }
    }
}