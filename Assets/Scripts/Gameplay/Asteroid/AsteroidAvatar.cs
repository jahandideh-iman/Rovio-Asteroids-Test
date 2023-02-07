
using System;
using UnityEngine;

namespace Asteroids.Presentation
{
    public class AsteroidAvatar : MonoBehaviour
    {
        static readonly int Standard_Size = 3;

        public event Action<AsteroidAvatar> OnDamageTaken = delegate { };

        [SerializeField] new Rigidbody2D rigidbody;
        [SerializeField] float speed;
        [SerializeField] Vector2 initialDirection;

        public int Size { get; private set; } // TODO: Make this configurable

        private void Awake()
        {
            Setup(Standard_Size, initialDirection.normalized);
        }

        public void Setup(int size, Vector2 direction)
        {
            initialDirection = direction;

            rigidbody.velocity = direction * speed;

            Size = size;
            transform.localScale = Vector3.one * ((float)Size / Standard_Size);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Bullet"))
            {
                Destroy(collision.gameObject);
                ApplyDamage();
            }
        }

        private void ApplyDamage()
        {
            OnDamageTaken(this);
        }
    }
}