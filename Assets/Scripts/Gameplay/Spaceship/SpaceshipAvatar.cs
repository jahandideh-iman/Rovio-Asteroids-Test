
using Asteroids.Game;
using System;
using UnityEngine;

namespace Asteroids.Presentation
{
    public class SpaceshipAvatar : MonoBehaviour
    {
        [SerializeField] BulletSpawner bulletSpawner;
        [SerializeField] Transform bulletSpawnPositionTransform;

        [SerializeField] new Rigidbody2D rigidbody;
        [SerializeField] float thrust;
        [SerializeField] float torque;

        public int Health { get; private set; } = 3; // TODO: Make it configurable

        public event Action<SpaceshipAvatar> OnDamageTaken = delegate { };

        // NOTE: Ideally the input should be handled in a separate place.
        private void Update()
        {
            if (Input.GetKey(KeyCode.W))
            {
                rigidbody.AddForce(transform.up * thrust);
            }

            if (Input.GetKey(KeyCode.A))
            {
                rigidbody.AddTorque(torque);
            }

            if (Input.GetKey(KeyCode.D))
            {
                rigidbody.AddTorque(-torque);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                bulletSpawner.SpawnBullet(bulletSpawnPositionTransform.position, transform.up);
            }
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Asteroid"))
            {
                ApplyDamage();
            }
        }

        private void ApplyDamage()
        {
            Health -= 1;

            OnDamageTaken(this);

            if (Health <= 0)
                Destroy(this.gameObject);
        }
    }
}