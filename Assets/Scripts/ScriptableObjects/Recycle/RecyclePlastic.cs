using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Plastic", menuName = "RecycleItem/Plastic")]
public class RecyclePlastic : RecycleItemsBase
{
	public override void Seperate()
	{
		if (isProcessing)
		{
			ItemManager.instance.recycledPlastic += currentCraftValue;
			ResetRecycleProcess();
			Debug.Log("Plastic is seperated");
		}
	}
	public override void Crush(){}
	public override void Wash()
	{
		if (ItemManager.instance.plastic > 0)
		{
			if (ItemManager.instance.plastic <= 5)
			{
				currentCraftValue = ItemManager.instance.plastic;
				ItemManager.instance.plastic -= currentCraftValue;
			}
			else
			{
				ItemManager.instance.plastic -= 5;
				currentCraftValue = 5;
			}

			
			isProcessing = true;
			DisableButtons();
			RecycleManager.instance.ProcessButtons[0].interactable = false;
			RecycleManager.instance.ProcessButtons[3].interactable = true;
			Debug.Log("Plastic is washed");
		}
		else
		{
			Debug.Log("Not Enough Items");
		}
	}
	public override void Shred(){}

	public override void SetActiveButtons()
	{
		//RecycleManager.instance.ReuseUIButton.gameObject.SetActive(true);
		//RecycleManager.instance.TrashUIButton.gameObject.SetActive(true);

		for (int i = 0; i <= RecycleManager.instance.ProcessButtons.Length - 1; i++)
		{
			RecycleManager.instance.ProcessButtons[i].gameObject.SetActive(false);
		}

		RecycleManager.instance.ProcessButtons[0].gameObject.SetActive(true);
		RecycleManager.instance.ProcessButtons[3].gameObject.SetActive(true);

		RecycleManager.instance.ProcessButtons[0].interactable = true;
		RecycleManager.instance.ProcessButtons[3].interactable = false;
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

		RecycleManager.instance.ProcessButtons[0].interactable = true;
		RecycleManager.instance.ProcessButtons[3].interactable = false;
	}
}
