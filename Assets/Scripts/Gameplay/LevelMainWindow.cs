using Arman.UIManagement;
using Asteroids.Game;
using UnityEngine;

namespace Asteroids.Presentation
{

    public class LevelMainWindow : MainWindow
    {
        [SerializeField] MessagePopup messagePromptPopupPrefab;

        LevelMainController mainController;

        public void Setup(LevelMainController mainController)
        {
            this.mainController = mainController;
        }

        public override void OnBackButtonPressed()
        {
            base.OnBackButtonPressed();
            OpenExitPopup();
        }

        public void OpenExitPopup()
        {
            var popup = Instantiate(messagePromptPopupPrefab);
            popup.Setup("Do you want to exit?", onConfirm: mainController.ExitLevel, onCancel: delegate { });
            uiManager.OpenPopUp(popup);
        }

        public UIManager UIManager()
        {
            return uiManager;
        }
    }
}