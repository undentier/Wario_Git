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
        /// This script is the mini game sound manager
        /// </summary>

        public class SoundManager123Requin : TimedBehaviour
        {
            public AudioSource[] globalMusic;
            public override void Start()
            {
                base.Start();
                switch (bpm)
                {
                    case (float)Manager.BPM.Slow:
                        globalMusic[0].Play();
                        break;
                    case (float)Manager.BPM.SuperFast:
                        globalMusic[1].Play();
                        break;
                    default:
                        break;
                }

            }

            //Update call on a fixed time
            public override void FixedUpdate()
            {
                base.FixedUpdate();
            }

            //Update call every tics
            public override void TimedUpdate()
            {
                base.TimedUpdate();
            }
        }
    }
}