using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Testing;

namespace LeRafiot
{
    namespace UnDeuxTroisRequin
    {
        /// <summary>
        /// Antoine LEROUX
        /// This script is use to tell the end game conditions
        /// </summary>
        
        public class LoseConditions : TimedBehaviour
        {
            #region Variables
            private float spawnCooldown;

            [Header("UI")]
            //win panel
            public GameObject panel;
            public TextMeshProUGUI resultText;
            public TextMeshProUGUI bpmText;
            public Slider timerUI;
            public TextMeshProUGUI tickNumber;
            public Image input;

            #endregion

            public override void Start()
            {
                base.Start(); 
                bpmText.text = "bpm: " + bpm.ToString();
                spawnCooldown = 60 / bpm;
            }

            //FixedUpdate is called on a fixed time.
            public override void FixedUpdate()
            {
                base.FixedUpdate(); 
                timerUI.value = (float)timer / spawnCooldown;
            }

            //TimedUpdate is called once every tick.
            public override void TimedUpdate()
            {
                if (Tick == 1)
                {
                    input.gameObject.SetActive(false);
                }

                if (Tick == 8)
                {
                    Manager.Instance.Result(false);
                }

                tickNumber.text = Tick.ToString();
            }
        }
    }
}