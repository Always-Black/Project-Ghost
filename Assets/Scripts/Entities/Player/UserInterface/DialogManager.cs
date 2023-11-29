using UnityEngine;

namespace Entities.Player.UserInterface
{
    public class DialogManager : MonoBehaviour
    {
        public Dialog CurrentDialog { get; private set; }
        public Dialog PreviousDialog { get; private set; }
        
        public void SetDialog(Dialog dialog)
        {
            if (CurrentDialog is not null)
            {
                PreviousDialog = CurrentDialog;
            }
            
            CurrentDialog = dialog;
        }
        
        public void DisplayNewDialog(Dialog dialog)
        {
            SetDialog(dialog);

            HidePreviousDialog();
            DisplayCurrentDialog();
        }
        
        public bool DisplayCurrentDialog()
        {
            if (CurrentDialog is not null)
            {
                CurrentDialog.DisplayDialog();
                return true;
            }
            
            return false;
        }
        
        public bool HideCurrentDialog()
        {
            if (CurrentDialog is not null)
            {
                CurrentDialog.HideDialog();
                return true;
            }
            
            return false;
        }
        
        public bool DisplayPreviousDialog()
        {
            if (PreviousDialog is not null)
            {
                PreviousDialog.DisplayDialog();
                return true;
            }
            
            return false;
        }
        
        public bool HidePreviousDialog()
        {
            if (PreviousDialog is not null)
            {
                PreviousDialog.HideDialog();
                return true;
            }
            
            return false;
        }
        
        public void ClearScreen()
        {
            HideCurrentDialog();
            HidePreviousDialog();
        }

        public void SwapDialogs()
        {
            (CurrentDialog, PreviousDialog) = (PreviousDialog, CurrentDialog);

            if (CurrentDialog is null || PreviousDialog is null) return;
            
            if(CurrentDialog.IsDisplayed() ^ PreviousDialog.IsDisplayed())
            {
                CurrentDialog.ToggleDialog(!CurrentDialog.IsDisplayed());
                PreviousDialog.ToggleDialog(!PreviousDialog.IsDisplayed());
            }
        }
        
        public bool IsAnyDialogDisplayed()
        {
            return CurrentDialog is not null && CurrentDialog.IsDisplayed() ||
                   PreviousDialog is not null && PreviousDialog.IsDisplayed();
        }
    }
}