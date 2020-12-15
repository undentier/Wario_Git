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
        /// This script control the player
        /// </summary>

        public class PlayerController : MonoBehaviour
        {
            public static PlayerController Instance;

            #region Variable

            [Header ("Rotation point")]
            public Transform[] rotaPoint;

            [Header ("Player value")]
            public int playerState;
            public bool canMove;

            #endregion 

            void Start()
            {
                ManagerInit();

                canMove = true;
                playerState = 2;
            }

    
            void Update()
            {
                PlayerMouvement();
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

            void PlayerMouvement()
            {
                if (canMove)
                {
                    if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetButtonDown("Right_Bumper"))
                    {

                        if (playerState < 4)
                        {
                            gameObject.transform.rotation = rotaPoint[playerState + 1].transform.rotation;
                            playerState++;
                        }
                        else
                        {
                            canMove = false;
                            Manager.Instance.Result(false);
                            SoundManagerPlanche.Instance.sfxSound[1].Play();
                        }
                    }

                    if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetButtonDown("Left_Bumper"))
                    {

                        if (playerState > 0)
                        {
                            gameObject.transform.rotation = rotaPoint[playerState - 1].transform.rotation;
                            playerState--;
                        }
                        else
                        {
                            canMove = false;
                            Manager.Instance.Result(false);
                            SoundManagerPlanche.Instance.sfxSound[1].Play();
                        }
                    }
                }
            }

        }
    }
}
