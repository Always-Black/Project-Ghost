using System;
using System.Collections.Generic;
using Droppables;
using UnityEngine;

namespace Entities
{
    [Serializable]
    public class InventoryBase
    {
        public Dictionary<DroppableType, int> Items { get; } = new ();

        public InventoryBase()
        {
            foreach (DroppableType droppableType in (DroppableType[]) Enum.GetValues(typeof(DroppableType)))
            {
                Items.Add(droppableType, 0);
            }
        }
        
        public void AddItem(DroppableType droppableType)
        {
            Items[droppableType]++;
        }
        
        public void AddItems(DroppableType droppableType, int amount)
        {
            Items[droppableType] += amount;
        }
        
        public void AddItems(List<DroppableType> droppableTypes)
        {
            foreach (DroppableType droppableType in droppableTypes)
            {
                Items[droppableType]++;
            }
        }
        
        public void RemoveItem(DroppableType droppableType)
        {
            Items[droppableType] = Mathf.Max(0, Items[droppableType] - 1);
        }
        
        public void RemoveItems(DroppableType droppableType, int amount)
        {
            Items[droppableType] = Mathf.Max(0, Items[droppableType] - amount);
        }
        
        public void RemoveItems(List<DroppableType> droppableTypes)
        {
            foreach (DroppableType droppableType in droppableTypes)
            {
                Items[droppableType] = Mathf.Max(0, Items[droppableType] - 1);
            }
        }
    }
}