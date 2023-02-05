using Asteroids.Presentation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Assertions;

namespace Asteroids.Game
{

    public class LevelMainController : MainGameController
    {
        public event Action LevelEndedEvent = delegate { };
        readonly Action exitLevelAction;

        public SpaceshipAvatar Spaceship { get; private set; }

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
            endConditionController = new EndConditionController(spaceship, asteroidsController, levelEndingPort, ExitLevel);
        }

        public void ExitLevel()
        {
            exitLevelAction.Invoke();
        }
    }
}