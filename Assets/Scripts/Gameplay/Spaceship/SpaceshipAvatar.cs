
using Asteroids.Game;
using System;
using UnityEngine;
using DG.Tweening;

namespace Asteroids.Presentation
{
    public class SpaceshipAvatar : MonoBehaviour
    {
        public event Action<SpaceshipAvatar> OnCollision = delegate { };

        [SerializeField] Transform bulletSpawnPoint;

        [SerializeField] new Rigidbody2D rigidbody;
        [SerializeField] float thrust;
        [SerializeField] float torque;


        BulletSpawner bulletSpawner;

        bool isBeingDestructed = false;

        public void Setup(BulletSpawner bulletSpawner)
        {
            this.bulletSpawner = bulletSpawner;
        }

        // NOTE: Ideally the input should be handled in a separate place.
        private void Update()
        {
            if (isBeingDestructed)
                return;

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
                bulletSpawner.SpawnBullet(bulletSpawnPoint.position, transform.up);
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Asteroid"))
            {
                OnCollision(this);
            }
        }

        public void ExecuteDestruction(Action onCompleted)
        {
            isBeingDestructed = true;

            rigidbody.velocity = Vector2.zero;

            transform.
                DOScale(0, 0.5f).
                SetEase(Ease.InCubic).
                OnComplete(() => { onCompleted.Invoke(); Destroy(this.gameObject); });
        }
    }
}