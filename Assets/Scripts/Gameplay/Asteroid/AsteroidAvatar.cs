
using System;
using UnityEngine;

namespace Asteroids.Presentation
{
    public class AsteroidAvatar : MonoBehaviour
    {
        static readonly int StandardHealth = 3;

        public event Action<AsteroidAvatar> OnDamageTaken = delegate { };
        public event Action<AsteroidAvatar> OnDestroyed = delegate { };

        [SerializeField] new Rigidbody2D rigidbody;
        [SerializeField] float speed;
        [SerializeField] Vector2 initialDirection;

        public int Health { get; private set; } // TODO: Make this configurable

        private void Awake()
        {
            Setup(3, initialDirection.normalized);
        }

        public void Setup(int health, Vector2 direction)
        {
            initialDirection = direction;

            rigidbody.velocity = direction * speed;

            Health = health;
            transform.localScale = Vector3.one * ((float)Health / StandardHealth);
        }

        public void Destroy()
        {
            Destroy(this.gameObject);
            OnDestroyed(this);
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
            Health -= 1;

            OnDamageTaken(this);

            if (Health <= 0)
                Destroy();
        }
    }
}