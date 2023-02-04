using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Astroids.Presentation
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class ScreenWrapper : MonoBehaviour
    {
        BoxCollider2D boundaryCollider;

        [SerializeField]
        private float teleportOffset;


        void Awake()
        {
            boundaryCollider = GetComponent<BoxCollider2D>();
            boundaryCollider.isTrigger = true;
        }

        void OnTriggerExit2D(Collider2D collision)
        {
            // TODO: Try using Rigid Body MovePosition
            collision.transform.position = CalculateWrappingPossition(collision.transform.position);
        }

        Vector2 CalculateWrappingPossition(Vector2 position)
        {
            if(IsRightSide(position))
            {
                position.x -= boundaryCollider.bounds.size.x + teleportOffset;
            }
            else if(IsLeftSide(position))
            {
                position.x += boundaryCollider.bounds.size.x + teleportOffset;
            }

            if (IsTopSide(position))
            {
                position.y -= boundaryCollider.bounds.size.y + teleportOffset;
            }
            else if (IsBottomSide(position))
            {
                position.y += boundaryCollider.bounds.size.y + teleportOffset;
            }

            return position;
        }

        private bool IsRightSide(Vector2 position)
        {
            return position.x > boundaryCollider.bounds.max.x;
        }

        private bool IsLeftSide(Vector2 position)
        {
            return position.x < boundaryCollider.bounds.min.x;
        }

        private bool IsTopSide(Vector2 position)
        {
            return position.y > boundaryCollider.bounds.max.y;
        }

        private bool IsBottomSide(Vector2 position)
        {
            return position.y < boundaryCollider.bounds.min.y;
        }

    }
}
