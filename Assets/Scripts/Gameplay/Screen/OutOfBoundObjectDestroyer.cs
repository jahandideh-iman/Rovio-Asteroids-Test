using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids.Presentation
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class OutOfBoundObjectDestroyer : MonoBehaviour
    {
        [SerializeField] List<string> supportedTags;

        BoxCollider2D boundaryCollider;

        void Awake()
        {
            boundaryCollider = GetComponent<BoxCollider2D>();
            boundaryCollider.isTrigger = true;
        }

        void OnTriggerExit2D(Collider2D collision)
        {
            foreach(var tag in supportedTags)
            {
                if(collision.CompareTag(tag))
                {
                    Destroy(collision.gameObject);
                    break;
                }
            }
        }
    }
}
