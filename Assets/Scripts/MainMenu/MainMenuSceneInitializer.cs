using Arman.Foundation.Core.ServiceLocating;
using Arman.UIManagement;
using Asteroids.Game;
using Asteroids.Presentation;
using UnityEngine;

namespace Asteroids.Main
{
    public class MainMenuSceneInitializer : SceneInitializer
    {
        [SerializeField] MainMenuMainWindow mainWindow = default;
        [SerializeField] Camera mainCamera = default;

        private void Awake()
        {
            ServiceLocator.Find<UIManager>().SetMainWindow(mainWindow);
            ServiceLocator.Find<UIManager>().SetMainCamera(mainCamera);

            var gameManager = ServiceLocator.Find<GameManager>();
            mainWindow.Setup(gameManager.MainController as MainMenuMainController);
        }
    }
}