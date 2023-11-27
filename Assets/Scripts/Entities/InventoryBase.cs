using System;
using System.Collections.Generic;
using Resources;
using UnityEngine;

namespace Entities
{
    [Serializable]
    public class InventoryBase
    {
        public Dictionary<ResourceType, int> Items { get; } = new ();

        public InventoryBase()
        {
            foreach (ResourceType droppableType in (ResourceType[]) Enum.GetValues(typeof(ResourceType)))
            {
                Items.Add(droppableType, 0);
            }
        }
        
        public void AddItem(ResourceType resourceType)
        {
            Items[resourceType]++;
        }
        
        public void AddItems(ResourceType resourceType, int amount)
        {
            Items[resourceType] += amount;
        }
        
        public void AddItems(List<ResourceType> droppableTypes)
        {
            foreach (ResourceType droppableType in droppableTypes)
            {
                Items[droppableType]++;
            }
        }
        
        public void RemoveItem(ResourceType resourceType)
        {
            Items[resourceType] = Mathf.Max(0, Items[resourceType] - 1);
        }
        
        public void RemoveItems(ResourceType resourceType, int amount)
        {
            Items[resourceType] = Mathf.Max(0, Items[resourceType] - amount);
        }
        
        public void RemoveItems(List<ResourceType> droppableTypes)
        {
            foreach (ResourceType droppableType in droppableTypes)
            {
                Items[droppableType] = Mathf.Max(0, Items[droppableType] - 1);
            }
        }
        
        public int GetItemCount(ResourceType resourceType)
        {
            return Items[resourceType];
        }
        
        public void Clear()
        {
            foreach (ResourceType droppableType in (ResourceType[]) Enum.GetValues(typeof(ResourceType)))
            {
                Items[droppableType] = 0;
            }
        }
    }
}