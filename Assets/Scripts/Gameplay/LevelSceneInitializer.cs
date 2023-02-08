using Arman.Foundation.Core.ServiceLocating;
using Arman.UIManagement;
using Asteroids.Game;
using Asteroids.Presentation;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids.Main
{
    public class LevelSceneInitializer : SceneInitializer
    {
        [SerializeField] LevelMainWindow levelMainWindow = default;
        [SerializeField] Camera mainCamera = default;

        [SerializeField] SpaceshipAvatar spaceshipAvatarPrefab;
        [SerializeField] Transform spaceShipSpawnPoint;
        [SerializeField] BulletSpawner bulletSpawner;

        private void Awake()
        {
            var gameManager = ServiceLocator.Find<GameManager>();

            var uiManager = ServiceLocator.Find<UIManager>();
            uiManager.SetMainWindow(levelMainWindow);
            uiManager.SetMainCamera(mainCamera);

            var mainController = gameManager.MainController as LevelMainController;

            mainController.Setup(
                spaceshipFactory: InstantiateSpaceship,
                new List<AsteroidAvatar>(FindObjectsByType<AsteroidAvatar>(FindObjectsSortMode.None)), 
                levelEndingPort: levelMainWindow);

            levelMainWindow.Setup(mainController);
        }

        SpaceshipAvatar InstantiateSpaceship()
        {
            var spaceShip = Instantiate(spaceshipAvatarPrefab, spaceShipSpawnPoint.position, spaceShipSpawnPoint.rotation, spaceShipSpawnPoint.parent);
            spaceShip.Setup(bulletSpawner);
            return spaceShip;
        }
    }
}