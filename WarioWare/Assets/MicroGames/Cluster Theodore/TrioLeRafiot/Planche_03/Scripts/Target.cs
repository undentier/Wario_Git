using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Testing;

namespace LeRafiot
{
    namespace Planche
    {
        /// <summary>
        /// Guillaume Rogé
        /// This script is the behavior of target
        /// </summary>

        public class Target : TimedBehaviour
        {
            #region Variable
            [Header ("Values")]
            public int tickToIncrase;
            public Vector2 startScale;
            public Vector2 finalScale;

            [Header ("Start bool")]
            public bool activate;

            private bool coolDown;       
            #endregion

            public override void Start()
            {
                base.Start(); //Do not erase this line!

                transform.localScale = startScale;
            }

            public override void FixedUpdate()
            {
                base.FixedUpdate(); //Do not erase this line!    

                if (activate == true)
                {
                    if (coolDown == false)
                    {
                        coolDown = true;
                        StartCoroutine(IncreaseScale(startScale, finalScale, (tickToIncrase * (60 / bpm))));
                    }
                }
            }

            public override void TimedUpdate()
            {
  
            }

            public IEnumerator IncreaseScale(Vector2 scale, Vector2 endScale, float timeToFade)
            {
                Vector2 currentScale = scale;
                float t = 0;
                while (t < 1)
                {
                    t += Time.deltaTime / timeToFade;
                    transform.localScale = Vector3.Lerp(currentScale, endScale, t);
                    yield return null;
                }
                activate = false;
                coolDown = false;
                transform.localScale = startScale;

                RandomEnemySpawn.Instance.target.Add(gameObject);
            }
        }

    }
}
