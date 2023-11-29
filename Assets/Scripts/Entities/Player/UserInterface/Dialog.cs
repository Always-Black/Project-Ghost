using UnityEngine;

namespace Entities.Player.UserInterface
{
    public abstract class Dialog : MonoBehaviour
    {
        public RectTransform DialogPanel;
        public bool IsDisplayed() => DialogPanel is not null && DialogPanel.gameObject.activeSelf;

        public void DisplayDialog()
        {
            ToggleDialog(true);
        }
        
        public void HideDialog()
        {
            ToggleDialog(false);
        }
        
        public void ToggleDialog(bool toggle)
        {
            if(DialogPanel is null) return;
            DialogPanel.gameObject.SetActive(toggle);
        }
    }
}