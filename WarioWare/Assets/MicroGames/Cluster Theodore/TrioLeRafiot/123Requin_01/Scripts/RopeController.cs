using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Testing;

namespace LeRafiot
{
    namespace UnDeuxTroisRequin
    {
        /// <summary>
        /// Antoine LEROUX
        /// This script is use to pull up by x height the rope of y height
        /// </summary>

        public class RopeController : TimedBehaviour
        {
            #region Variables
            private LineRenderer rope;
            private bool win;

            [Header("Object attached")]
            public GameObject attachedTo;

            //Rope settings
            [HideInInspector] public int ropeSize;
            [HideInInspector] public int pullingUpRopeSize;

            //Level 3 parameters
            [HideInInspector] public bool level3;
            [HideInInspector] public int pullingDownRopeSize = 1;

            #endregion

            public override void Start()
            {
                base.Start(); //Do not erase this line!
                rope = GetComponent<LineRenderer>();

            }

            //FixedUpdate is called on a fixed time.
            public override void FixedUpdate()
            {
                base.FixedUpdate(); //Do not erase this line!

            }

            private void Update()
            {
                rope.SetPosition(1, attachedTo.transform.localPosition);                                //The rope is always attach to the chest

                if (rope.GetPosition(1).y > 0)
                {
                    if ((Input.GetButtonDown("A_Button") || Input.GetKeyDown(KeyCode.Space)) && !Manager.Instance.panel.activeSelf)
                    {
                        attachedTo.transform.position -= new Vector3(0, -pullingUpRopeSize);            //Pulling up the chest
                    }
                }
                else
                {
                    if (!win)
                    {
                        win = true;
                        rope.SetPosition(1, new Vector3(0, 0));
                        Manager.Instance.Result(true);
                    }
                }
            }

            //TimedUpdate is called once every tick.
            public override void TimedUpdate()
            {
                if (rope.GetPosition(1).y > 0)
                {
                    if (level3 && !Manager.Instance.panel.activeSelf)
                    {
                        attachedTo.transform.position -= new Vector3(0, pullingDownRopeSize);   //Automatically pulling down the chest in rythm with tick
                    }
                }
            }
        }
    }
}