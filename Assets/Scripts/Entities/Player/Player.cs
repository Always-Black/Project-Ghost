using Resources;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Entities.Player
{
    public class Player : Entity
    {
        public static Player Instance { get; private set; }
        
        [SerializeField] private float Speed = 14.0f;

        [SerializeField] private Slider HealthSlider;
        [SerializeField] private JoystickControl Joystick;
        
        public InventoryBase Inventory = new ();


        private void Awake()
        {
            if (Instance == null) Instance = this;
            else Destroy(gameObject);
            
            HealthSlider.value = Health;
        }

        private void FixedUpdate()
        {
            if (Joystick.speed > 0.0f)
            {
                Vector2 translateDirection = Joystick.direction * (Speed * Joystick.speed * Time.fixedDeltaTime);
                transform.Translate(translateDirection, Space.World);
            }
        }

        public override void OnDropCollected(Droppable droppable)
        {
            base.OnDropCollected(droppable);
            Inventory.AddItem(droppable.Type);
        }

        public override void SetHealth(float health)
        {
            base.SetHealth(health);
            
            HealthSlider.value = Health;
        }

        protected override void HandleDeath()
        {
            base.HandleDeath();
            
            Health += 60;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
