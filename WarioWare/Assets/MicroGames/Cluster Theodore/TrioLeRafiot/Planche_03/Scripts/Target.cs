using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Testing;

namespace LeRafiot
{
    namespace Planche
    {
        public class Target : TimedBehaviour
        {
            #region Variable
            [Header ("Values")]
            public int tickToFade;

            [Header ("Start bool")]
            public bool activate;

            private SpriteRenderer sprite;
            private bool coolDown;
            private Color startColor;
            #endregion

            public override void Start()
            {
                base.Start(); //Do not erase this line!

                sprite = GetComponent<SpriteRenderer>();
                startColor = sprite.color;
            }

            public override void FixedUpdate()
            {
                base.FixedUpdate(); //Do not erase this line!    

                if (activate == true)
                {
                    if (coolDown == false)
                    {
                        coolDown = true;
                        StartCoroutine(Waiting(sprite.color, Color.white, (tickToFade * (60 / bpm))));
                    }
                }
            }

            public override void TimedUpdate()
            {
  
            }


            public IEnumerator Waiting(Color color, Color finalColor, float timeToFade)
            {
                Color actualColor = color;
                float t = 0;
                while (t < 1)
                {
                    t += Time.fixedDeltaTime / timeToFade;
                    sprite.color = Color.Lerp(actualColor, finalColor, t);
                    yield return null;
                }
                activate = false;
                coolDown = false;
                sprite.color = startColor;

                RandomEnemySpawn.Instance.target.Add(gameObject);

            }
        }

    }
}
