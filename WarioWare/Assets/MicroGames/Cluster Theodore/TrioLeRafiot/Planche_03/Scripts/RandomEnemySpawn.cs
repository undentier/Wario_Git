using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Testing;

namespace LeRafiot
{
    namespace Planche
    {
        /// <summary>
        /// Guillaume Rogé
        /// Script who choice x random target and activate it
        /// </summary>
        
        public class RandomEnemySpawn : TimedBehaviour
        {
            public static RandomEnemySpawn Instance;

            #region Variable
            [Header ("Number of target per Tic")]
            public int numberRandomSpawn;

            [Header ("Target list")]
            public List<GameObject> target = new List<GameObject>();
            #endregion


            public override void Start()
            {
                base.Start(); //Do not erase this line!

                ManagerInit();
            }

            //FixedUpdate is called on a fixed time.
            public override void FixedUpdate()
            {
                base.FixedUpdate(); //Do not erase this line!
            }

            //TimedUpdate is called once every tick.
            public override void TimedUpdate()
            {
                if(!Manager.Instance.panel.activeSelf)
                {
                    for (int i = 0; i < numberRandomSpawn; i++)
                    {
                        int random = Random.Range(0, target.Count);
                        target[random].GetComponent<Target>().activate = true;
                        target.Remove(target[random]);
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