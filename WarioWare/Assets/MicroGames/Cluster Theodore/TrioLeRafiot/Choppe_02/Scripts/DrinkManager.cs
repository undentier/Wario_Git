﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Testing;

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
            public GameObject drinkUi;
            public GameObject bulle;

            [Header("Difficulty")]
            public bool vanishUi;
            [HideInInspector] public int tickToFade;

            public int tickToIncrase;
            public Vector2 startScale;
            public Vector2 finalScale;

            private GameObject spawnDrink;
            private int rateStock;
            private int numberOfSpawn;
            //private bool canScale = true;
            //private Color alphaColor;
            #endregion

            public override void Start()
            {
                base.Start(); //Do not erase this line!

                ManagerInit();

                //alphaColor.a = 0;
                rateStock = goodSpawnRate;
                canSpawn = true;
                //canScale = true;

                DrinkChoice();
                UiSystem();

            }

            //FixedUpdate is called on a fixed time.
            public override void FixedUpdate()
            {
                base.FixedUpdate(); //Do not erase this line!

                actualDrink.RemoveAll(list_item => list_item == null);

                /*if (canScale == true)
                {
                    UiScale(startScale, finalScale, (tickToIncrase * (60 / bpm)));
                }*/
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

                            spawnDrink = Instantiate(drinkList[randomNumber], new Vector2(spawnPoint.transform.position.x, drinkList[randomNumber].transform.position.y), spawnPoint.transform.rotation);
                            SoundManagerChoppe.Instance.sfxSound[3].Play();
                            StartCoroutine(MoveToPosition(spawnDrink.transform, new Vector2(endPoint.transform.position.x, drinkList[randomNumber].transform.position.y), (tickDrinkStay * (60 / bpm))));
                            actualDrink.Add(spawnDrink);

                            rateStock += chanceAdd;
                            numberOfSpawn++;
                        }
                        else
                        {
                            spawnDrink = Instantiate(chosenOne, new Vector2(spawnPoint.transform.position.x, chosenOne.transform.position.y), spawnPoint.transform.rotation);
                            SoundManagerChoppe.Instance.sfxSound[3].Play();
                            StartCoroutine(MoveToPosition(spawnDrink.transform, new Vector2(endPoint.transform.position.x, chosenOne.transform.position.y), (tickDrinkStay * (60 / bpm))));
                            actualDrink.Add(spawnDrink);
                            spawnDrink.tag = "Enemy2";

                            rateStock = 0;
                            numberOfSpawn++;
                        }
                    }
                }
            }

            void UiSystem()
            {
                drinkUi.GetComponent<SpriteRenderer>().sprite = chosenOne.GetComponent<SpriteRenderer>().sprite;

                if (vanishUi)
                {
                    StartCoroutine(CleanUI());
                }

                
            }


            void UiScale(Vector2 scale, Vector2 endScale, float timeToFade)
            {
                //canScale = false;
                bool switchLock = false;

                Vector2 currentScale = scale;
                float t = 0;

                if (switchLock == false)
                {
                    while (t < 1)
                    {
                        Debug.LogWarning("je rentre");
                        t += Time.deltaTime / timeToFade;
                        drinkUi.gameObject.transform.localScale = Vector3.Lerp(currentScale, endScale, t);
                    }
                    //switchLock = true;
                }
                
                if (switchLock == true)
                {
                    t = 0;
                    while (t < 1)
                    {
                        t += Time.deltaTime / timeToFade;
                        drinkUi.gameObject.transform.localScale = Vector3.Lerp(endScale, scale, t);
                    }
                }

                
                //canScale = true;
            }


            public IEnumerator MoveToPosition(Transform transform, Vector3 position, float timeToMove)
            {
                Vector3 currentPos = transform.position;
                float t = 0;
                while (t < 1)
                {
                    if (transform != null)
                    {
                        t += Time.deltaTime / timeToMove;
                        transform.position = Vector3.Lerp(currentPos, position, t);
                        yield return null;
                    }
                    else
                    {
                        yield return null;
                    }
                }
            }

            IEnumerator CleanUI()
            {
                yield return new WaitForSeconds((tickToFade * (60 / bpm)));
                bulle.gameObject.SetActive(false);
                drinkUi.gameObject.SetActive(false);    
            }
        }
    }
}