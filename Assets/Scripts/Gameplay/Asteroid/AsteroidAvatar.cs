
using UnityEngine;

namespace Asteroids.Presentation
{
    public class AsteroidAvatar : MonoBehaviour
    {
        [SerializeField] new Rigidbody2D rigidbody;
        [SerializeField] Vector2 velocity;

        private void Awake()
        {
            rigidbody.velocity = velocity;
        }
     
    }
}