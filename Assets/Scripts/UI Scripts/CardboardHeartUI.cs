using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardboardHeartUI : MonoBehaviour
{
    [SerializeField] Image[] cardboardHearts;

    void Update()
    {
        if (!GAME_MANAGER.instance.playerDead)
        {
            CheckShieldUI();
        }
    }

    void CheckShieldUI()
    {
        if (cardboardHearts == null)
            return;
        else
        {
            for (int i = 0; i <= ItemManager.instance.MaxCardboardHeart - 1; i++)
            {
                if (i < ItemManager.instance.CardboardHeart)
                {
                    cardboardHearts[i].enabled = true;
                }
                else
                {
                    cardboardHearts[i].enabled = false;
                }

            }
        }
    }
}
