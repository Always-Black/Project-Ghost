using Entities;
using UnityEngine;

namespace Resources
{
    public class Droppable : MonoBehaviour
    {
        [SerializeField] private AudioClip CollectSound;
        
        public ResourceType Type;
        
        [Space(10)]
        public Vector2 DistributeRange = Vector2.one;
        public int DroppingAmount = 1;
        
        [Space(10)] 
        [Range(0, 100)] public float GlobalDroppingChance = 100.0f;
        [Range(0, 100)] public float IndividualDroppingChance = 100.0f;
        

        public void Drop(Vector2 position)
        {
            if (Random.Range(0.0f, 100.0f) > GlobalDroppingChance) return;
            
            for (int i = 0; i < DroppingAmount; i++)
            {
                if (Random.Range(0.0f, 100.0f) > IndividualDroppingChance) continue;
                Vector2 randomPosition = Random.insideUnitCircle * DistributeRange;
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
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent(out Entity collector))
            {
                Collect(collector);
            }
        }
    }
}