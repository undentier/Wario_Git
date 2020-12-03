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

            [Header("Values Script")]
            public int tickBeforeSpawn;
            public int tickSharkStay;
            public int startTick;

            [Header ("True si requin présent")]
            public bool sharkIsHere;

            [Header ("Oject à renseigner")]
            public GameObject sharkPrefab;
            public Transform spawnPoint;

            [Header ("UI")]
            public Image sign;

            private GameObject actualShark;

            private int counterTick;
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
                            actualShark = Instantiate(sharkPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
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
            
        }
    }
}