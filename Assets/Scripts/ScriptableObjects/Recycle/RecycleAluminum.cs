using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Aluminum", menuName = "RecycleItem/Aluminum")]
public class RecycleAluminum : RecycleItemsBase
{
	public override void Seperate(){}
	public override void Crush()
	{
		if (ItemManager.instance.aluminum > 0)
		{
			if (ItemManager.instance.aluminum <= 5)
			{
				currentCraftValue = ItemManager.instance.aluminum;
				ItemManager.instance.aluminum -= currentCraftValue;
			}
			else
			{
				ItemManager.instance.aluminum -= 5;
				currentCraftValue = 5;
			}

			isProcessing = true;
			DisableButtons();
			RecycleManager.instance.ProcessButtons[1].interactable = true;
			RecycleManager.instance.ProcessButtons[2].interactable = false;
			Debug.Log("Plastic is washed");
		}
		else
		{
			Debug.Log("Not Enough Items");
		}
	}
	public override void Wash(){}
	public override void Shred() 
	{
		if (isProcessing)
		{
			ItemManager.instance.recycledAluminum += currentCraftValue;
			ResetRecycleProcess();
			Debug.Log("Plastic is seperated");
		}
	}
	public override void SetActiveButtons()
	{
		//RecycleManager.instance.ReuseUIButton.gameObject.SetActive(true);
		//RecycleManager.instance.TrashUIButton.gameObject.SetActive(true);

		for (int i = 0; i <= RecycleManager.instance.ProcessButtons.Length - 1; i++)
		{
			RecycleManager.instance.ProcessButtons[i].gameObject.SetActive(false);
		}

		RecycleManager.instance.ProcessButtons[1].gameObject.SetActive(true);
		RecycleManager.instance.ProcessButtons[2].gameObject.SetActive(true);

		RecycleManager.instance.ProcessButtons[1].interactable = false;
		RecycleManager.instance.ProcessButtons[2].interactable = true;
	}
	protected override void DisableButtons()
	{

		for (int i = 0; i <= RecycleManager.instance.MaterialButtons.Length - 1; i++)
		{
			RecycleManager.instance.MaterialButtons[i].interactable = false;
		}
	}
	protected override void ResetRecycleProcess()
	{
		isProcessing = false;

		for (int i = 0; i <= RecycleManager.instance.MaterialButtons.Length - 1; i++)
		{
			RecycleManager.instance.MaterialButtons[i].interactable = true;
		}

		RecycleManager.instance.ExitRecyclingUIButton.interactable = true;

		RecycleManager.instance.ProcessButtons[1].interactable = false;
		RecycleManager.instance.ProcessButtons[2].interactable = true;
	}
}
