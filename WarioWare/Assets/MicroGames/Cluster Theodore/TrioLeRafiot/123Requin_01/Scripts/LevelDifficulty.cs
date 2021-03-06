﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Testing;

namespace LeRafiot
{
    namespace UnDeuxTroisRequin
    {
        /// <summary>
        /// Antoine LEROUX
        /// This script is use to manage the difficulty depending to the level (1,2,3) 
        /// All gameplay values changing need to be refer in this scrip (rope controller and shark)
        /// </summary>
        
        public class LevelDifficulty : TimedBehaviour
        {
            #region Variables
            public GameObject rope;
            private RopeController ropeScript;

            [Header("Level EASY")]
            [Range(1, 50)] public int ropeSize1 = 8;
            [Range(1, 10)] public int pullingUpRopeSize1 = 1;

            [Header("Level MEDIUM")]
            [Range(1, 50)] public int ropeSize2 = 14;
            [Range(1, 10)] public int pullingUpRopeSize2 = 1;

            [Header("Level HARD")]
            [Range(1, 50)] public int ropeSize3 = 16;
            [Range(1, 10)] public int pullingUpRopeSize3 = 1;
            [Range(1, 10)] public int pullingDownRopeSize3 = 1;

            #endregion

            public override void Start()
            {
                base.Start();
                ropeScript = rope.GetComponent<RopeController>();

                SetValues();
            }

            //FixedUpdate is called on a fixed time.
            public override void FixedUpdate()
            {
                base.FixedUpdate(); 

            }

            //TimedUpdate is called once every tick.
            public override void TimedUpdate()
            {

            }

            void SetValues()
            {
                if (Manager.Instance.currentDifficulty == Manager.Difficulty.EASY)
                {
                    ropeScript.ropeSize = ropeSize1;
                    ropeScript.pullingUpRopeSize = pullingUpRopeSize1;
                    ropeScript.attachedTo.transform.localPosition = new Vector3(0, ropeScript.ropeSize);
                }
                else if (Manager.Instance.currentDifficulty == Manager.Difficulty.MEDIUM)
                {
                    ropeScript.ropeSize = ropeSize2;
                    ropeScript.pullingUpRopeSize = pullingUpRopeSize2;
                    ropeScript.attachedTo.transform.localPosition = new Vector3(0, ropeScript.ropeSize);
                }
                else if (Manager.Instance.currentDifficulty == Manager.Difficulty.HARD)
                {
                    ropeScript.level3 = true;

                    ropeScript.ropeSize = ropeSize3;
                    ropeScript.pullingUpRopeSize = pullingUpRopeSize3;
                    ropeScript.pullingDownRopeSize = pullingDownRopeSize3;
                    ropeScript.attachedTo.transform.localPosition = new Vector3(0, ropeScript.ropeSize);
                }
            }
        }
    }
}