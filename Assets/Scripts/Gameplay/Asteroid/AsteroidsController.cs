
using Asteroids.Presentation;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids.Game
{
    public class AsteroidsController
    {
        public event Action OnAsteroidRemoved = delegate { };

        private List<AsteroidAvatar> asteroids;

        public AsteroidsController(List<AsteroidAvatar> asteroids)
        {
            this.asteroids = asteroids;

            foreach (var asteroid in asteroids)
                asteroid.OnDamageTaken += SplitAsteroid;
        }

        public bool HasAnyAsteroid()
        {
            return asteroids.Count > 0;
        }

        private void SplitAsteroid(AsteroidAvatar asteroid)
        {
            if (asteroid.Size > 1)
            {
                SpawnSmallerAsteroidFrom(asteroid);
                SpawnSmallerAsteroidFrom(asteroid);
            }

            Destroy(asteroid);
        }

        private void SpawnSmallerAsteroidFrom(AsteroidAvatar origianlAsteroid)
        {
            var asteroid = UnityEngine.Object.Instantiate(origianlAsteroid, origianlAsteroid.transform.parent, true);
            asteroid.Setup(origianlAsteroid.Size - 1, RandomDirection());

            asteroids.Add(asteroid);
            asteroid.OnDamageTaken += SplitAsteroid;
        }

        private void Destroy(AsteroidAvatar asteroid)
        {
            asteroids.Remove(asteroid);
            asteroid.OnDamageTaken -= SplitAsteroid;

            UnityEngine.Object.Destroy(asteroid.gameObject);

            OnAsteroidRemoved.Invoke();
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