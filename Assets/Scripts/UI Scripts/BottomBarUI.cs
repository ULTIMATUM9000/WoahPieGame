using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BottomBarUI : Singleton<BottomBarUI>
{
    [SerializeField] Button[] bottomPanels;

	private void Start()
	{
		HighlightItem(0);
	}

	public void HighlightItem(int ItemNumber)
    {
        for(int i = 0; i < bottomPanels.Length; i++)
		{
            if(i == ItemNumber)
			{
                bottomPanels[i].interactable = true;
			}
            else
			{
                bottomPanels[i].interactable = false;
			}
		}
    }
}
