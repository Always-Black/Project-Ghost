using Entities.Player;
using Entities.Player.UserInterface;
using Extensions;
using UnityEngine;

namespace Environment
{
    [RequireComponent(typeof(Collider2D))]
    public class Market : Dialog
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.IsPlayer(out Player player))
            {
                player.DialogHandler.DisplayNewDialog(this);
            }
        }
    }
}