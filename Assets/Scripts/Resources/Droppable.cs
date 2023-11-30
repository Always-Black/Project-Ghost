using System;
using Entities;
using Entities.Player;
using Extensions;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Resources
{
    [Serializable]
    public class DroppingParameters
    {
        public Droppable DroppablePrefab;
        
        [Space(10)]
        public Vector2 DistributeRange = Vector2.one;
        public int DroppingAmount = 1;
        
        [Space(10)] 
        [Range(0, 100)] public float GlobalDroppingChance = 100.0f;
        [Range(0, 100)] public float IndividualDroppingChance = 100.0f;
        
        public void Drop(Vector2 position)
        {
            DroppablePrefab.Drop(position, GlobalDroppingChance, IndividualDroppingChance, DroppingAmount,
                DistributeRange);
        }
    }
    
    public class Droppable : MonoBehaviour
    {
        public ResourceType Type;
        [SerializeField] private AudioClip CollectSound;

        public void Drop(Vector2 position, float globalDroppingChance, float individualDroppingChance,
            int droppingAmount, Vector2 distributeRange)
        {
            if (Random.Range(0.0f, 100.0f) > globalDroppingChance) return;
            
            for (int i = 0; i < droppingAmount; i++)
            {
                if (Random.Range(0.0f, 100.0f) > individualDroppingChance) continue;
                Vector2 randomPosition = Random.insideUnitCircle * distributeRange;
                Instantiate(gameObject, position + randomPosition, Quaternion.identity);
            }
        }

        public void Collect(Entity collector)
        {
            collector.OnDropCollected(this);
            PlayCollectSound();
            Destroy(gameObject);
        }

        private void PlayCollectSound()
        {
            AudioSource.PlayClipAtPoint(CollectSound, transform.position);
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.gameObject.IsPlayer(out Player player))
            {
                Collect(player);
            }
        }
    }
}