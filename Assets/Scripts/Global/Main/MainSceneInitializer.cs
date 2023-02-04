using Arman.Foundation.Core.ServiceLocating;
using Arman.UIManagement;
using Asteroids.Game;
using UnityEngine;

namespace Asteroids.Main
{
    public class MainSceneInitializer : SceneInitializer
    {
        [SerializeField] UIManager uiManager = default;
        [SerializeField] GameObject dontDestoryObjectsParent = default;

        void Awake()
        {
            ServiceLocator.Init();

            uiManager.Init();

            ServiceLocator.Register(uiManager);

            var gameManager = new GameManager();
            ServiceLocator.Register(gameManager);

            DontDestroyOnLoad(dontDestoryObjectsParent);

            gameManager.GoToMainMenu();
        }

    }
}