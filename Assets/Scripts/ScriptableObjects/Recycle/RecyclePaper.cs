using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Paper", menuName = "RecycleItem/Paper")]
public class RecyclePaper : RecycleItemsBase
{
	public override void Seperate() 
	{
		if (ItemManager.instance.paper > 0)
		{
			if (ItemManager.instance.paper <= 5)
			{
				currentCraftValue = ItemManager.instance.paper;
				ItemManager.instance.paper -= currentCraftValue;
			}
			else
			{
				ItemManager.instance.paper -= 5;
				currentCraftValue = 5;
			}
			isProcessing = true;
			DisableButtons();
			RecycleManager.instance.ProcessButtons[2].interactable = true;
			RecycleManager.instance.ProcessButtons[3].interactable = false;
			Debug.Log("Paper is Seperated");
		}
		else
		{
			Debug.Log("Not Enough Items");
		}
	}
	public override void Crush() 
	{
		if (isProcessing)
		{
			ItemManager.instance.recycledPaper += currentCraftValue;
			ResetRecycleProcess();
			Debug.Log("Paper is Crushed");
		}
	}
	public override void Wash(){}
	public override void Shred(){}
	public override void SetActiveButtons()
	{
		//RecycleManager.instance.ReuseUIButton.gameObject.SetActive(true);
		//RecycleManager.instance.TrashUIButton.gameObject.SetActive(true);

		for (int i = 0; i <= RecycleManager.instance.ProcessButtons.Length - 1; i++)
		{
			RecycleManager.instance.ProcessButtons[i].gameObject.SetActive(false);
		}

		RecycleManager.instance.ProcessButtons[2].gameObject.SetActive(true);
		RecycleManager.instance.ProcessButtons[3].gameObject.SetActive(true);

		RecycleManager.instance.ProcessButtons[2].interactable = false;
		RecycleManager.instance.ProcessButtons[3].interactable = true;
	}
	protected override void DisableButtons()
	{
		for (int i = 0; i <= RecycleManager.instance.MaterialButtons.Length - 1; i++)
		{
			RecycleManager.instance.MaterialButtons[i].interactable = false;
		}

		RecycleManager.instance.ExitRecyclingUIButton.interactable = false;
	}
	protected override void ResetRecycleProcess()
	{
		isProcessing = false;

		for (int i = 0; i <= RecycleManager.instance.MaterialButtons.Length - 1; i++)
		{
			RecycleManager.instance.MaterialButtons[i].interactable = true;
		}

		RecycleManager.instance.ExitRecyclingUIButton.interactable = true;

		RecycleManager.instance.ProcessButtons[2].interactable = false;
		RecycleManager.instance.ProcessButtons[3].interactable = true;
	}
}
