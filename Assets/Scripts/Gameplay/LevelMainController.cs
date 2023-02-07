using Asteroids.Presentation;
using System;
using System.Collections.Generic;

namespace Asteroids.Game
{
    public class LevelMainController : MainGameController
    {
        static readonly int ScorePerAsteroid = 100;

        public event Action<int> OnScoreChanged = delegate { };

        readonly Action exitLevelAction;

        public SpaceshipAvatar Spaceship { get; private set; }
        public int Score { get; private set; }

        AsteroidsController asteroidsController;
        EndConditionController endConditionController;

        public LevelMainController(Action exitLevelAction)
        {
            this.exitLevelAction = exitLevelAction;
        }

        public void Setup(SpaceshipAvatar spaceship, List<AsteroidAvatar> asteroids, LevelEndingPort levelEndingPort)
        {
            Spaceship = spaceship;

            asteroidsController = new AsteroidsController(asteroids);
            asteroidsController.OnAsteroidRemoved += HandleAsteroidScore;
            endConditionController = new EndConditionController(spaceship, asteroidsController, levelEndingPort, ExitLevel);
        }

        private void HandleAsteroidScore()
        {
            // NOTE: Scoring system can be improved.
            Score += ScorePerAsteroid;
            OnScoreChanged.Invoke(Score);
        }

        public void ExitLevel()
        {
            exitLevelAction.Invoke();
        }
    }
}