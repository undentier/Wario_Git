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
  
        public class RopeController : MonoBehaviour
        {
            #region Variables
            private LineRenderer rope;
            private float timer = 0;
            private bool win;

            [Header("Object attached")]
            public GameObject attachedTo;

            //Rope settings
            [HideInInspector] public int ropeSize;
            [HideInInspector] public int pullingUpRopeSize;

            //Level 3 parameters
            [HideInInspector] public bool level3;
            [HideInInspector] public int pullingDownRopeSize = 1;
            [HideInInspector] public float delayToPullDown = 1;

            #endregion

            private void Start()
            {
                rope = GetComponent<LineRenderer>();
            }

            private void Update()
            {
                rope.SetPosition(1, attachedTo.transform.localPosition);                                //The rope is always attach to the chest

                if (rope.GetPosition(1).y > 0)
                {
                    if (Input.GetButtonDown("A_Button") && !Manager.Instance.panel.activeSelf)
                    {
                        attachedTo.transform.position -= new Vector3(0, -pullingUpRopeSize);            //Pulling up the chest
                    }
                    else
                    {
                        if (level3 && !Manager.Instance.panel.activeSelf)
                        {
                            timer += Time.deltaTime;

                            if (timer > delayToPullDown)
                            {
                                timer = 0;
                                attachedTo.transform.position -= new Vector3(0, pullingDownRopeSize);   //Automatically pulling down the chest
                            }
                        }
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
        }
    }
}
