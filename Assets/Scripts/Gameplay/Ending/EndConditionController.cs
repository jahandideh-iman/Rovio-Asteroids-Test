
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

        public EndConditionController(
            SpaceshipAvatar spaceship,
            AsteroidsController asteroidsController,
            LevelEndingPort levelEndingPort,
            Action exitLevelAction)
        {
            this.exitLevelAction = exitLevelAction;
            this.levelEndingPort = levelEndingPort;
            this.asteroidsController = asteroidsController;

            spaceship.OnDamageTaken += CheckSpaceshipHealth;
            asteroidsController.OnAsteroidRemoved += CheckAsteroids;
        }

        private void CheckSpaceshipHealth(SpaceshipAvatar spaceship)
        {
            if (spaceship.Health <= 0)
            {
                spaceship.OnDamageTaken -= CheckSpaceshipHealth;

                levelEndingPort.OpenEndScreen(onContinue: exitLevelAction);
            }
        }

        private void CheckAsteroids()
        {
            if (!asteroidsController.HasAnyAsteroid())
            {
                asteroidsController.OnAsteroidRemoved -= CheckAsteroids;
                levelEndingPort.OpenEndScreen(onContinue: exitLevelAction);
            }
        }
    }
}