using UnityEngine;

namespace Asteroids.Presentation
{
    public class BulletSpawner : MonoBehaviour
    {
        [SerializeField] BulletAvatar bulletAvatarPrefab;

        public void SpawnBullet(Vector2 position, Vector2 direction)
        {
            var bullet = Instantiate(bulletAvatarPrefab, this.transform, true);
            bullet.Setup(position, direction);
        }
    }
}
