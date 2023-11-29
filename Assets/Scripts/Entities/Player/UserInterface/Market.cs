using UnityEngine;

namespace Entities.Player.UserInterface
{
    [RequireComponent(typeof(Collider2D))]
    public class Market : Dialog
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.TryGetComponent(out Player player))
            {
                player.DialogHandler.DisplayNewDialog(this);
            }
        }
    }
}