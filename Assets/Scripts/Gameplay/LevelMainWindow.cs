using Arman.UIManagement;
using Asteroids.Game;
using System;
using TMPro;
using UnityEngine;

namespace Asteroids.Presentation
{

    public class LevelMainWindow : MainWindow, LevelEndingPort
    {
        [SerializeField] MessagePopup messagePromptPopupPrefab;
        [SerializeField] LevelResultPopup levelResultPopupPrefab;

        [SerializeField] TextMeshProUGUI livesText;
        [SerializeField] TextMeshProUGUI scoreText;

        LevelMainController mainController;

        public void Setup(LevelMainController mainController)
        {
            this.mainController = mainController;

            mainController.Spaceship.OnDamageTaken += UpdateLives;

            UpdateLives(mainController.Spaceship);
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

        public void OpenEndScreen(Action onContinue)
        {
            var levelResultPopup = Instantiate(levelResultPopupPrefab);
            levelResultPopup.Setup(0, onContinue);
            uiManager.OpenPopUp(levelResultPopup);
        }

        private void UpdateScore(int score)
        {
            scoreText.SetText(score.ToString());
        }

        private void UpdateLives(SpaceshipAvatar spaceship)
        {
            livesText.SetText(spaceship.Health.ToString());

        }
    }
}