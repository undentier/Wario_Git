﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Testing;

namespace LeRafiot
{
	namespace Choppe
	{
		/// <summary>
		/// Antoine LEROUX
		/// This script is use to detect drink in catch zone and by pressing A, catch the drink
		/// </summary>

		public class CatchSystem : MonoBehaviour
		{
			#region Variables
			public Color colorTriggered;
			private Color colorBase;

			private bool drinkInZone;
			private GameObject drinkTriggered;
			#endregion

			// Start is called before the first frame update
			void Start()
			{
				colorBase = GetComponent<SpriteRenderer>().color;
				drinkInZone = false;
			}

			// Update is called once per frame
			void Update()
			{
                if (drinkInZone)
                {
					GetComponent<SpriteRenderer>().color = colorTriggered;
					
					if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("A_Button") && !Manager.Instance.panel.activeSelf)
                    {
						Destroy(drinkTriggered);
						GetComponent<SpriteRenderer>().color = Color.green;
					}
				}
                else
                {
					GetComponent<SpriteRenderer>().color = colorBase;
				}
			}

            private void OnTriggerEnter2D(Collider2D col)
            {
                if (col.CompareTag("Ennemy1"))
                {
					drinkInZone = true;
					drinkTriggered = col.gameObject;
				}
            }

            private void OnTriggerExit2D(Collider2D col)
            {
                if (col.CompareTag("Ennemy1"))
                {
					drinkInZone = false;					
				}
            }
        }
	}
}