using UnityEngine;

namespace Asteroids.Presentation
{
    public class BulletAvatar : MonoBehaviour
    {
        [SerializeField] new Rigidbody2D rigidbody;

        [SerializeField] float speed;

        public void Setup(Vector2 position, Vector2 direction)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
            transform.SetPositionAndRotation(position, Quaternion.AngleAxis(angle, Vector3.forward));
            rigidbody.velocity = speed * direction;
        }
    }
}