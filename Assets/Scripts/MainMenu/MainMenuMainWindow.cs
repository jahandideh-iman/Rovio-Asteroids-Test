using Arman.UIManagement;
using UnityEngine;
using Asteroids.Game;

namespace Asteroids.Presentation
{
    public class MainMenuMainWindow : MainWindow
    {
        [SerializeField] MessagePopup messagePopupPrefab = default;

        MainMenuMainController mainController = default;

        public void Setup(MainMenuMainController mainController)
        {
            this.mainController = mainController;
        }

        // Called as Unity Event
        public void GoToLevel()
        {
            mainController.GoToLevel();
        }

        public override void OnBackButtonPressed()
        {
            OpenExitMessage();
        }

        // Called as Unity Event
        public void OpenExitMessage()
        {
            uiManager.
                OpenPopUp(Instantiate(messagePopupPrefab)).
                Setup("Do you want to exit the game?", onConfirm: mainController.ExitApp, onCancel: delegate { });
        }
    }
}