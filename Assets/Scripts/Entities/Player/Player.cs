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

        [SerializeField] private StatusBarComponent StatusBar;
        [SerializeField] private JoystickControl Joystick;
        
        public InventoryBase Inventory = new ();


        private void Awake()
        {
            if (Instance == null) Instance = this;
            else Destroy(gameObject);
            
            StatusBar.Setup(Health, Inventory.GetItemCount(ResourceType.Delusion),
                Inventory.GetItemCount(ResourceType.Money));
        }

        protected override void OnUpdate()
        {
            if (Joystick.IsTouching)
            {
                Vector3 translateDirection = new (Joystick.Horizontal(), Joystick.Vertical());
                transform.Translate(translateDirection * (Speed * Time.deltaTime), Space.World);
            }
        }

        public override void OnDropCollected(Droppable droppable)
        {
            base.OnDropCollected(droppable);
            Inventory.AddItem(droppable.Type);
            StatusBar.SetResource(droppable.Type, Inventory.GetItemCount(droppable.Type));
        }

        public override void SetHealth(float health)
        {
            base.SetHealth(health);
            StatusBar.SetHealth(Health);
        }

        protected override void HandleDeath()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
