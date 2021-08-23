using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] Image[] hearts;
    [SerializeField] Sprite fullHearth;
    [SerializeField] Sprite emptyHearth;

    PlayerHealth playerHealth;

    void Update()
    {
        if(!GAME_MANAGER.instance.playerDead && playerHealth == null && !GAME_MANAGER.instance.afterScreen)
		{
            playerHealth = GameObject.FindGameObjectWithTag("PLAYER").GetComponent<PlayerHealth>();
        }           
        if (!GAME_MANAGER.instance.playerDead && playerHealth != null)
		{
            CheckHealthUI();
        }
    }

    void CheckHealthUI()
    {
        if (hearts == null)
            return;
        else
        {
            for (int i = 0; i <= hearts.Length - 1; i++)
            {
                if (i < playerHealth.CurrentHealth)
                {
                    hearts[i].sprite = fullHearth;
                }
                else
                {
                    hearts[i].sprite = emptyHearth;
                }

                if (i < playerHealth.MaxHealth)
                {
                    hearts[i].enabled = true;
                }
                else
                {
                    hearts[i].enabled = false;
                }

            }
        }
    }
}
