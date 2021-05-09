using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Fractal;

namespace EGO.EXICAS
{
    public class Core
    {
        Collection _collection = new Collection();
        public bool SaveState { get; private set; }
        public event Node_INode_EventHandler ImageAdded;
        public event Node_INode_EventHandler ImageRemoved;
        public Collection CurrentCollection
        {
            get => _collection;
            set
            {
                _collection = value;
                _collection.AddedChild += ImageAdded;
                _collection.RemovedChild += ImageRemoved;
                _collection.AddedChild += _collectionSaveStateIndicator;
                _collection.RemovedChild += _collectionSaveStateIndicator;
                SaveState = true;
            }
        }
        private void _collectionSaveStateIndicator(INode sender, INode parameter1)
        {
            SaveState = false;
        }
    }
}
