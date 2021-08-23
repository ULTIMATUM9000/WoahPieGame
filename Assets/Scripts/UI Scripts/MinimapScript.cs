using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapScript : MonoBehaviour
{
    GameObject playerMinimapIcon;

	private void Update()
	{
		if(playerMinimapIcon == null && !GAME_MANAGER.instance.playerDead && !GAME_MANAGER.instance.afterScreen)
		{
			playerMinimapIcon = GameObject.Find("PlayerMinimapIcon");
		}
		if(playerMinimapIcon != null)
		{
			UpdateScale();
		}

		
	}

	void UpdateScale()
	{
		if (SimpleSceneChanger.instance.LevelIndex == 1)
		{
			playerMinimapIcon.transform.localScale = new Vector3(18.4451637f, 18.4451637f, 0);
		}
		if (SimpleSceneChanger.instance.LevelIndex == 2)
		{
			playerMinimapIcon.transform.localScale = new Vector3(18.4451637f, 18.4451637f, 0);
		}
		if(SimpleSceneChanger.instance.LevelIndex == 3)
		{
			playerMinimapIcon.transform.localScale = new Vector3(9.07802296f, 9.07802296f, 0); 
		}

	}
}
