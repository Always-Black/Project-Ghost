using System.Globalization;
using Entities.Player.UserInterface;
using Resources;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Entities.Player
{
    public class Player : Entity
    {
        public static Player Instance { get; private set; }
        
        public DialogManager DialogHandler;
        public InventoryBase Inventory = new ();
        
        [SerializeField] private UIStatistics UIStatistics;
        [SerializeField] private JoystickControl Joystick;
        
        
        protected override void OnAwake()
        {
            if (Instance == null) Instance = this;
            else Destroy(gameObject);
            
            UIStatistics.Setup(Health, Inventory.GetItemCount(ResourceType.Delusion),
                Inventory.GetItemCount(ResourceType.Money));
        }
        
        private void FixedUpdate()
        {
            if (Joystick.IsTouching && !DialogHandler.IsAnyDialogDisplayed())
            {
                Vector3 translateDirection = new (Joystick.Horizontal(), Joystick.Vertical());
                Rigidbody.AddForce(translateDirection * (100f * Speed));
            }
        }

        public override void OnDropCollected(Droppable droppable)
        {
            base.OnDropCollected(droppable);
            Inventory.AddItem(droppable.Type);
            UIStatistics.SetResource(droppable.Type, Inventory.GetItemCount(droppable.Type));
        }

        public override void SetHealth(float health)
        {
            base.SetHealth(health);
            UIStatistics.SetHealth(Health);
        }

        protected override void HandleDeath()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
