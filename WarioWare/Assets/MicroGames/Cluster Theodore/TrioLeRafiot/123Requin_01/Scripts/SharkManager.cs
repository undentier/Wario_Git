using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LeRafiot
{
    namespace UnDeuxTroisRequin
    {
        public class SharkManager : TimedBehaviour
        {
            public static SharkManager Instance;

            [Header ("Active le systeme de spawn du requin")]
            public bool sharkSysteme;

            [Header("Values Script")]
            public int tickBeforeSpawn;
            public int tickSharkStay;
            public int startTick;

            [Header ("True si requin présent")]
            public bool sharkIsHere;

            [Header ("Object à renseigner")]
            public GameObject sharkPrefab;
            public Transform spawnStart;
            public Transform spawnEnd;

            [Header ("UI")]
            public Image sign;

            private GameObject actualShark;

            private float counterTick;
            private int counterTickShark;
            private bool canFlash;

            private bool lockSpawn;

            public override void Start()
            {
                base.Start(); //Do not erase this line!
                ManagerInit();

                canFlash = false;
                sign.gameObject.SetActive(false);
                
                counterTick = 0;
                counterTickShark = 0;
            }

            //FixedUpdate is called on a fixed time.
            public override void FixedUpdate()
            {
                base.FixedUpdate(); //Do not erase this line!

                
            }



            //TimedUpdate is called once every tick.
            public override void TimedUpdate()
            {
                SharkSpawn();
            }

            void SharkSpawn()
            {
                if (sharkSysteme == true)
                {
                    if (Tick == startTick)
                    {
                        canFlash = true;
                    }

                    if (Tick >= startTick && counterTick != tickBeforeSpawn)
                    {
                        counterTick++;

                        if (canFlash)
                        {
                            sign.gameObject.SetActive(true);
                            canFlash = false;
                        }
                        else
                        {
                            sign.gameObject.SetActive(false);
                            canFlash = true;
                        }
                    }

                    if (counterTick == tickBeforeSpawn)
                    {                  
                        if (counterTickShark < tickSharkStay)
                        {
                            counterTickShark++;

                            if (lockSpawn == false)
                            {
                                sign.gameObject.SetActive(true);
                                lockSpawn = true;
                                sharkIsHere = true;
                                actualShark = Instantiate(sharkPrefab, spawnStart.transform.position, spawnStart.transform.rotation);
                                StartCoroutine(MoveToPosition(actualShark.transform, spawnEnd.transform.position, (tickSharkStay * (60 / bpm))));
                            }
                        }
                        else
                        {
                            sign.gameObject.SetActive(false);
                            sharkIsHere = false;
                            Destroy(actualShark);
                        }
                    }
                }

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