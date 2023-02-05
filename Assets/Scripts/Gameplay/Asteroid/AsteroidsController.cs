
using Asteroids.Presentation;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids.Game
{
    public class AsteroidsController
    {
        private List<AsteroidAvatar> asteroids;

        public AsteroidsController(List<AsteroidAvatar> asteroids)
        {
            this.asteroids = asteroids;

            foreach (var asteroid in asteroids)
                RegisterOnEvents(asteroid);
        }

        private void RegisterOnEvents(AsteroidAvatar asteroid)
        {
            asteroid.OnDamageTaken += SplitAsteroid;
            asteroid.OnDestroyed += RemoveFromAsteroids;
        }

        private void RemoveFromAsteroids(AsteroidAvatar asteroid)
        {
            asteroids.Remove(asteroid);
            asteroid.OnDamageTaken -= SplitAsteroid;
            asteroid.OnDestroyed -= RemoveFromAsteroids;
        }

        private void SplitAsteroid(AsteroidAvatar asteroid)
        {

            if (asteroid.Health <= 0)
                return;

            var asteroid1 = UnityEngine.Object.Instantiate(asteroid, asteroid.transform.parent, true);
            var asteroid2 = UnityEngine.Object.Instantiate(asteroid, asteroid.transform.parent, true);

            asteroid1.Setup(asteroid.Health, RandomDirection());
            asteroid2.Setup(asteroid.Health, RandomDirection());

            asteroids.Add(asteroid1);
            asteroids.Add(asteroid2);

            RegisterOnEvents(asteroid1);
            RegisterOnEvents(asteroid2);

            asteroid.Destroy();
        }

        private Vector2 RandomDirection()
        {
            var direction = new Vector2(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f));

            if (direction.x == 0 && direction.y == 0)
                return new Vector2(1, 0);
            else
                return direction.normalized;
        }

    }
}