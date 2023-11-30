using Entities;
using Entities.Player;
using UnityEngine;

namespace Extensions
{
    public static class GameObjectExtensions
    {
        public static bool IsEntity(this GameObject gameObject, out Entity entity)
        {
            entity = gameObject.GetComponent<Entity>();
            return entity != null;
        }
        
        public static bool IsEntity(this GameObject gameObject)
        {
            return gameObject.GetComponent<Entity>() != null;
        }
        
        public static bool IsPlayer(this GameObject gameObject, out Player player)
        {
            player = gameObject.GetComponent<Player>();
            return player != null;
        }
        
        public static bool IsPlayer(this GameObject gameObject)
        {
            return gameObject.GetComponent<Player>() != null;
        }
    }
}