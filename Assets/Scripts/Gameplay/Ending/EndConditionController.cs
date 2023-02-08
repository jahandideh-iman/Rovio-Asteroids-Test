
using Asteroids.Presentation;
using System;

namespace Asteroids.Game
{
    public interface LevelEndingPort
    {
        void OpenEndScreen(Action onContinue);
    }

    public class EndConditionController
    {
        Action exitLevelAction;
        LevelEndingPort levelEndingPort;
        AsteroidsController asteroidsController;
        LevelMainController levelMainController;

        public EndConditionController(LevelMainController levelMainController,
            AsteroidsController asteroidsController,
            LevelEndingPort levelEndingPort,
            Action exitLevelAction)
        {
            this.levelMainController = levelMainController;
            this.asteroidsController = asteroidsController;

            this.levelEndingPort = levelEndingPort;
            this.exitLevelAction = exitLevelAction;

            levelMainController.OnPlayerLivesChanged += CheckPlayerLives;
            asteroidsController.OnAsteroidRemoved += CheckAsteroids;
        }

        private void CheckPlayerLives(int lives)
        {
            if (lives <= 0)
            {
                UnregisterFromEvents();
                levelEndingPort.OpenEndScreen(onContinue: exitLevelAction);
            }
        }

        private void CheckAsteroids()
        {
            if (!asteroidsController.HasAnyAsteroid())
            {
                UnregisterFromEvents();
                levelEndingPort.OpenEndScreen(onContinue: exitLevelAction);
            }
        }

        private void UnregisterFromEvents()
        {
            asteroidsController.OnAsteroidRemoved -= CheckAsteroids;
            levelMainController.OnPlayerLivesChanged -= CheckPlayerLives;
        }
    }
}