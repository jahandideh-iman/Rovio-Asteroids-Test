using Asteroids.Presentation;
using System;

namespace Asteroids.Game
{
    public interface LevelEndingPort
    {
        void OpenEndScreen(Action onContinue);
    }

    public class LevelMainController : MainGameController
    {
        public event Action LevelEndedEvent = delegate { };

        readonly Action exitLevelAction;

        public SpaceshipAvatar Spaceship { get; private set; }

        LevelEndingPort levelEndingPort;

        public LevelMainController(Action exitLevelAction)
        {
            this.exitLevelAction = exitLevelAction;
        }

        public void Setup(SpaceshipAvatar spaceship, LevelEndingPort levelEndingPort)
        {
            Spaceship = spaceship;
            spaceship.OnLivesChanged += CheckSpaceshipHealth;

            this.levelEndingPort = levelEndingPort;
        }

        private void CheckSpaceshipHealth(int health)
        {
            if (health <= 0)
            {
                Spaceship.OnLivesChanged -= CheckSpaceshipHealth;
                UnityEngine.Object.Destroy(Spaceship.gameObject);
                Spaceship = null;

                levelEndingPort.OpenEndScreen(onContinue: ExitLevel);
            }
        }

        public void ExitLevel()
        {
            exitLevelAction.Invoke();
        }
    }
}