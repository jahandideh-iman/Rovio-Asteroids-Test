using Asteroids.Presentation;
using System;
using System.Collections.Generic;

namespace Asteroids.Game
{
    public class LevelMainController : MainGameController
    {
        static readonly int ScorePerAsteroid = 100;

        public event Action<int> OnPlayerScoreChanged = delegate { };
        public event Action<int> OnPlayerLivesChanged = delegate { };

        public int PlayerScore { get; private set; }
        public int PlayerLives
        {
            get => playerLives;
            private set { playerLives = value; OnPlayerLivesChanged.Invoke(playerLives); }
        }

        AsteroidsController asteroidsController;
        EndConditionController endConditionController;

        readonly Action exitLevelAction;

        int playerLives = 3; // TODO: Make it configurable
        Func<SpaceshipAvatar> spaceshipFactory;

        public LevelMainController(Action exitLevelAction)
        {
            this.exitLevelAction = exitLevelAction;
        }

        public void Setup(Func<SpaceshipAvatar> spaceshipFactory, List<AsteroidAvatar> asteroids, LevelEndingPort levelEndingPort)
        {
            this.spaceshipFactory = spaceshipFactory;

            asteroidsController = new AsteroidsController(asteroids);
            asteroidsController.OnAsteroidRemoved += HandleAsteroidScore;
            endConditionController = new EndConditionController(this, asteroidsController, levelEndingPort, ExitLevel);

            SpawnSpaceShip();
        }

        private void SpawnSpaceShip()
        {
            var spaceShip = spaceshipFactory.Invoke();
            spaceShip.OnCollision += HandleSpaceshipCollision;
        }

        private void HandleSpaceshipCollision(SpaceshipAvatar spaceShip)
        {
            spaceShip.OnCollision -= HandleSpaceshipCollision;
            PlayerLives -= 1;

            if (PlayerLives > 0)
                spaceShip.ExecuteDestruction(onCompleted: SpawnSpaceShip);
            else
                spaceShip.ExecuteDestruction(onCompleted: delegate { });
        }

        private void HandleAsteroidScore()
        {
            // NOTE: Scoring system can be improved.
            PlayerScore += ScorePerAsteroid;
            OnPlayerScoreChanged.Invoke(PlayerScore);
        }

        public void ExitLevel()
        {
            exitLevelAction.Invoke();
        }
    }
}