using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shared.Models
{
    /*
    backlog items have names, medium(s) they're in, series they're in, whether or not the item is complete (for each medium?), and whether or not the item is currently owned. along with maybe an optional description/notes section. should probably also contain an id.
    */
    public class BacklogItem
    {
        private required readonly int _itemId;
        private string _name;
        private string _medium; // items belonging to different mediums can both be added
        private string _series;
        private bool _isComplete;
        private bool _isOwned;
        private bool _inProgress;
        private string? _notes;

        /// <summary>
        /// ID identifying item.
        /// </summary>
        public int ItemId
        {
            get => _itemId;
        }
        /// <summary>
        /// Name of the item.
        /// </summary>
        public string Name
        {
            get => _name;
            set => _name = value;
        }
        /// <summary>
        /// Medium the item belongs to.
        /// </summary>
        public string Medium
        {
            get => _medium;
            set => _medium = value;
        }
        /// <summary>
        /// Series the item belongs to.
        /// </summary>
        public string Series
        {
            get => _series;
            set => _series = value;
        }
        /// <summary>
        /// Name of the item.
        /// </summary>
        public string IsComplete
        {
            get => _isComplete;
            set => _isComplete = value;
        }
        /// <summary>
        /// Name of the item.
        /// </summary>
        public string IsOwned
        {
            get => _isOwned;
            set => _isOwned = value;
        }
        /// <summary>
        /// Name of the item.
        /// </summary>
        public string InProgress
        {
            get => _inProgress;
            set => _inProgress = value;
        }
        /// <summary>
        /// Name of the item.
        /// </summary>
        public string? Notes
        {
            get => _notes;
            set => _notes = value;
        }

        /// <summary>
        /// Initialize an item with all its properties.
        /// isComplete is assumed to be false.
        /// </summary>
        public BacklogItem(int itemId, string name, string medium, string series, bool owned, bool inProgress, string notes)
        {
            _itemId = itemId;
            _name = name;
            _medium = medium;
            _series = series;
            _isComplete = false;
            _isOwned = owned;
            _inProgress = inProgress;
            _notes = notes;
        }

        /// <summary>
        /// Initialize an item with all the boolean properties set to default values
        /// </summary>
        public BacklogItem(int itemId, string name, string medium, string series, string notes)
        {
            this(itemId, name, medium, series, false, false, notes);
        }

        public override string ToString()
        {
            return "Item:\n" +
                $"\tID: {ItemId}\n" +
                $"\tName: {Name}\n" +
                $"\tMedium: {Medium}\n" +
                $"\tSeries: {Series}\n" +
                $"\tIsComplete: {IsComplete}\n" +
                $"\tIsOwned: {IsOwned}\n" +
                $"\tInProgress: {InProgress}\n" +
                $"\tNotes: {Notes}";
        }
        
        public override bool Equals(object? obj)
        {
            if (typeof(obj).Equals(BacklogItem))
            {
                return obj.ItemId == ItemId;
            }
            return false;
        }
    }

    

    
}