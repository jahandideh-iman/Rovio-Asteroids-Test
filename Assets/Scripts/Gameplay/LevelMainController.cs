using System;

namespace Asteroids.Game
{
    public class LevelMainController : MainGameController
    {
        public event Action LevelEndedEvent = delegate { };

        readonly Action exitLevelAction;

        public LevelMainController(Action exitLevelAction)
        {
            this.exitLevelAction = exitLevelAction;
        }

        public void Setup()
        {
        }

        public void ExitLevel()
        {
            exitLevelAction.Invoke();
        }
    }
}