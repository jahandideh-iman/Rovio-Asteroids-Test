using Arman.Foundation.Core.ServiceLocating;
using Arman.UIManagement;
using Asteroids.Game;
using Asteroids.Presentation;
using UnityEngine;

namespace Asteroids.Main
{
    public class LevelSceneInitializer : SceneInitializer
    {
        [SerializeField] LevelMainWindow levelMainWindow = default;
        [SerializeField] Camera mainCamera = default;

        private void Awake()
        {
            var gameManager = ServiceLocator.Find<GameManager>();

            var uiManager = ServiceLocator.Find<UIManager>();
            uiManager.SetMainWindow(levelMainWindow);
            uiManager.SetMainCamera(mainCamera);

            var mainController = gameManager.MainController as LevelMainController;

            mainController.Setup();

            levelMainWindow.Setup(mainController);
        }

    }
}