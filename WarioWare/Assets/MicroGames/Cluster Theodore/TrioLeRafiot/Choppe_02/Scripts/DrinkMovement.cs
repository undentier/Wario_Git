using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LeRafiot
{
    namespace Choppe
    {
        /// <summary>
        /// Antoine LEROUX
        /// This script is the drink behavior
        /// </summary>
        
        public class DrinkMovement : TimedBehaviour
        {
            #region Variables
            [Header("Spawn Position")]
            public Transform spawnPoint;
            public Transform endPoint;

            public bool pickOneTimeDrink;
            public List<GameObject> drinksList = new List<GameObject>();
            public bool drinkCanRepeat;
            public GameObject[] drinkList;
            private GameObject actualDrink;

            [Header("Values")]
            public int tickDrinkStay;

            #endregion

            public override void Start()
            {
                base.Start(); //Do not erase this line!

            }

            //FixedUpdate is called on a fixed time.
            public override void FixedUpdate()
            {
                base.FixedUpdate(); //Do not erase this line!

            }

            //TimedUpdate is called once every tick.
            public override void TimedUpdate()
            {
                if (Tick < 8)
                {
                    if (drinkCanRepeat)
                    {
                        int randomNumber = Random.Range(0, drinkList.Length - 1);

                        actualDrink = Instantiate(drinkList[randomNumber], spawnPoint.transform.position, spawnPoint.transform.rotation);
                        StartCoroutine(MoveToPosition(actualDrink.transform, endPoint.transform.position, (tickDrinkStay * (60 / bpm))));
                    }
                    else if (pickOneTimeDrink)
                    {
                        int randomNumber = Random.Range(0, drinksList.Count - 1);

                        actualDrink = Instantiate(drinksList[randomNumber], spawnPoint.transform.position, spawnPoint.transform.rotation);
                        StartCoroutine(MoveToPosition(actualDrink.transform, endPoint.transform.position, (tickDrinkStay * (60 / bpm))));

                        drinksList.RemoveAt(randomNumber);
                    }
                }
            }

            public IEnumerator MoveToPosition(Transform transform, Vector3 position, float timeToMove)
            {
                Vector3 currentPos = transform.position;
                float t = 0;
                while (t < 1)
                {
                    t += Time.deltaTime / timeToMove;
                    transform.position = Vector3.Lerp(currentPos, position, t);
                    yield return null;
                }
            }
        }
    }
}