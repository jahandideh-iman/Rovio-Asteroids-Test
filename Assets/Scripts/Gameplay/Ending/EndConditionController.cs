
using Asteroids.Presentation;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids.Game
{
    public interface LevelEndingPort
    {
        void OpenEndScreen(Action onContinue);
    }

    public class EndConditionController
    {
        SpaceshipAvatar spaceship;
        Action exitLevelAction;
        LevelEndingPort levelEndingPort;

        public EndConditionController(SpaceshipAvatar spaceship, LevelEndingPort levelEndingPort, Action exitLevelAction)
        {
            this.spaceship = spaceship;
            this.exitLevelAction = exitLevelAction;
            this.levelEndingPort = levelEndingPort;

            spaceship.OnDamageTaken += CheckSpaceshipHealth;

        }

        private void CheckSpaceshipHealth(SpaceshipAvatar spaceship)
        {
            System.Diagnostics.Debug.Assert(spaceship == this.spaceship);

            if (spaceship.Health <= 0)
            {
                spaceship.OnDamageTaken -= CheckSpaceshipHealth;
                spaceship = null;

                levelEndingPort.OpenEndScreen(onContinue: exitLevelAction);
            }
        }

    }
}