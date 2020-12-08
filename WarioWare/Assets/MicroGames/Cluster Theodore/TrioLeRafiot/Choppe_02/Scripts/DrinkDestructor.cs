using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Testing;

namespace LeRafiot
{
    namespace Choppe
    {
        public class DrinkDestructor : MonoBehaviour
        {

            private void OnTriggerEnter2D(Collider2D collision)
            {
                if (collision.CompareTag("Ennemy2"))
                {
                    Destroy(collision.gameObject);
                    Manager.Instance.Result(false);
                }
                else
                {
                    Destroy(collision.gameObject);
                }
            }

        }
    }   
}
