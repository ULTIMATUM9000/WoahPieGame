using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    [SerializeField] RecycleItemsBase recycleItems;

    public void SetRecycleObject()
	{
		RecycleManager.instance.recycleItem = recycleItems;
		recycleItems.SetActiveButtons();
	}        
}
