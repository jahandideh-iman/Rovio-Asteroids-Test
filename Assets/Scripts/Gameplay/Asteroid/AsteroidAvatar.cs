
using System;
using UnityEngine;

namespace Asteroids.Presentation
{
    public class AsteroidAvatar : MonoBehaviour
    {
        static readonly int StandardHealth = 3;

        [SerializeField] new Rigidbody2D rigidbody;
        [SerializeField] float speed;
        [SerializeField] Vector2 initialDirection;

        public int Health { get; private set; } // TODO: Make this configurable

        private void Awake()
        {
            Setup(3, initialDirection.normalized);
        }

        private void Setup(int health, Vector2 direction)
        {
            initialDirection = direction;

            rigidbody.velocity = direction * speed;

            Health = health;
            transform.localScale = Vector3.one * ((float)Health / StandardHealth);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Bullet"))
            {
                Destroy(collision.gameObject);
                TakeDamage();
            }
        }

        private void TakeDamage()
        {
            Health -= 1;

            if (Health <= 0)
                return;

            var asteroid1 = Instantiate(this, this.transform.parent, true);
            var asteroid2 = Instantiate(this, this.transform.parent, true);

            asteroid1.Setup(Health, RandomDirection());
            asteroid2.Setup(Health, RandomDirection());

            Destroy(this.gameObject);
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