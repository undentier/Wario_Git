﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LeRafiot
{
    namespace Choppe
    {
        public class DrinkManager : TimedBehaviour
        {
            public static DrinkManager Instance;

            #region Variable
            [Header ("Spawn Point")]
            public Transform spawnPoint;
            public Transform endPoint;

            [Header ("Values")]
            public int tickDrinkStay;
            [Range(0,100)] public int goodSpawnRate;
            public int chanceAdd;
            public int maxDrinkSpawn;

            [Header ("List")]
            public List<GameObject> drinkList = new List<GameObject>();
            public List<GameObject> actualDrink = new List<GameObject>();

            [Header ("Drink to catch")]
            public GameObject chosenOne;

            [Header ("Bool who lock the spawn system")]
            public bool canSpawn;

            [Header("UI")]
            public Image drinkUi;
            public Image bulle;

            [Header("Difficulty")]
            public bool vanishUi;
            public float timeToFade;

            private GameObject spawnDrink;
            private int rateStock;
            private int numberOfSpawn;
            private Color alphaColor;
            #endregion

            public override void Start()
            {
                base.Start(); //Do not erase this line!

                ManagerInit();

                alphaColor.a = 0;
                rateStock = goodSpawnRate;
                canSpawn = true;

                DrinkChoice();
                UiSystem();

            }

            //FixedUpdate is called on a fixed time.
            public override void FixedUpdate()
            {
                base.FixedUpdate(); //Do not erase this line!

                actualDrink.RemoveAll(list_item => list_item == null);
            }

            //TimedUpdate is called once every tick.
            public override void TimedUpdate()
            {
                SpawnSystem();
            }

            void ManagerInit()
            {
                if (Instance == null)
                {
                    Instance = this;
                }
                else
                {
                    Destroy(gameObject);
                }
            }

            void DrinkChoice()
            {
                int random = Random.Range(0, drinkList.Count);
                chosenOne = drinkList[random];
                drinkList.RemoveAt(random);
               
            }

            void SpawnSystem()
            {
                if (numberOfSpawn <= maxDrinkSpawn)
                {
                    if (canSpawn == true)
                    {
                        int random = Random.Range(0, 100);

                        if (random > rateStock)
                        {
                            int randomNumber = Random.Range(1, drinkList.Count);

                            spawnDrink = Instantiate(drinkList[randomNumber], spawnPoint.transform.position, spawnPoint.transform.rotation);
                            StartCoroutine(MoveToPosition(spawnDrink.transform, endPoint.transform.position, (tickDrinkStay * (60 / bpm))));
                            actualDrink.Add(spawnDrink);

                            rateStock += chanceAdd;
                            numberOfSpawn++;
                        }

                        else
                        {
                            spawnDrink = Instantiate(chosenOne, spawnPoint.transform.position, spawnPoint.transform.rotation);
                            StartCoroutine(MoveToPosition(spawnDrink.transform, endPoint.transform.position, (tickDrinkStay * (60 / bpm))));
                            actualDrink.Add(spawnDrink);

                            rateStock = 0;
                            numberOfSpawn++;
                        }
                    }
                }
            }

            void UiSystem()
            {
                drinkUi.sprite = chosenOne.GetComponent<SpriteRenderer>().sprite;
                drinkUi.color = chosenOne.GetComponent<SpriteRenderer>().color;

                if (vanishUi)
                {
                    StartCoroutine(CleanUI());
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

            IEnumerator CleanUI()
            {
                yield return new WaitForSeconds((2 * (60 / bpm)));
                bulle.gameObject.SetActive(false);
                drinkUi.gameObject.SetActive(false);
                
            }
        }
    }
}