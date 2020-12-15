using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Testing;


namespace LeRafiot
{
    namespace Planche
    {
        /// <summary>
        /// Guillaume Rogé
        /// This script trigger the detection of player
        /// </summary>

        public class CollisionDetection : MonoBehaviour
        {
            private void OnTriggerEnter2D(Collider2D collision)
            {
                if (collision.gameObject.tag == ("Ennemy1"))
                {
                    PlayerController.Instance.canMove = false;
                    Manager.Instance.Result(false);
                }
            }
        }

    }
}
