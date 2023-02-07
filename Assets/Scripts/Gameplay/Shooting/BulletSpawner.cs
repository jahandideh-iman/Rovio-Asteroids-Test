using Asteroids.Presentation;
using UnityEngine;

namespace Asteroids.Game
{
    public class BulletSpawner : MonoBehaviour
    {
        [SerializeField] BulletAvatar bulletAvatarPrefab;

        public void SpawnBullet(Vector2 position, Vector2 direction)
        {
            // NOTE: Can use an object pool here.
            var bullet = Instantiate(bulletAvatarPrefab, this.transform, true);
            bullet.Setup(position, direction);
        }
    }
}
