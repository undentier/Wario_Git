using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Testing;

namespace LeRafiot
{
    namespace Choppe
    {
        /// <summary>
        /// Antoine LEROUX
        /// This script is use to manage the difficulty depending to the level (1,2,3) 
        /// All gameplay values changing need to be refer in this scrip
        /// </summary>

        public class LevelDifficultyChoppe : TimedBehaviour
        {
            #region Variables
            public DrinkManager managerScript;

            [Header("Level EASY")]
            public List<GameObject> drinkListEasy = new List<GameObject>();


            [Header("Level MEDIUM")]
            public List<GameObject> drinkListMedium = new List<GameObject>();


            [Header("Level HARD")]
            public int tickBubbleDisappear;
            public List<GameObject> drinkListHard = new List<GameObject>();

            #endregion

            public override void Start()
            {
                base.Start();

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
                if (Manager.Instance.currentDifficulty == Difficulty.EASY)
                {
                    managerScript.drinkList = new List<GameObject>(drinkListEasy);
                    managerScript.vanishUi = false;
                }
                else if (Manager.Instance.currentDifficulty == Difficulty.MEDIUM)
                {
                    managerScript.drinkList = new List<GameObject>(drinkListMedium);
                    managerScript.vanishUi = false;
                }
                else if (Manager.Instance.currentDifficulty == Difficulty.HARD)
                {
                    managerScript.drinkList = new List<GameObject>(drinkListHard);
                    managerScript.tickToFade = tickBubbleDisappear;
                    managerScript.vanishUi = true;
                }
            }
        }
    }
}