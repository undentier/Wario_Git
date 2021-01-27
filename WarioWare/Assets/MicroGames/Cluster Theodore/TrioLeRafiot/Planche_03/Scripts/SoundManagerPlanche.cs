﻿using UnityEngine;

namespace LeRafiot
{
    namespace Planche
    {
        /// <summary>
        /// Antoine LEROUX
        /// This script is the mini game sound manager
        /// </summary>

        public class SoundManagerPlanche : TimedBehaviour
        {
            public static SoundManagerPlanche Instance;

            public AudioSource[] globalMusic;

            [Space] public AudioSource[] sfxSound;

            public override void Start()
            {
                base.Start();
                ManagerInit();

                sfxSound[5].Play();

                switch (bpm)
                {
                    case (float)BPM.Slow:
                        globalMusic[0].Play();
                        break;
                    case (float)BPM.Medium:
                        globalMusic[1].Play();
                        break;
                    case (float)BPM.Fast:
                        globalMusic[2].Play();
                        break;
                    case (float)BPM.SuperFast:
                        globalMusic[3].Play();
                        break;
                    default:
                        break;
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