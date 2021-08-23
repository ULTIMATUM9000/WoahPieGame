using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemCounterUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI[] itemCounter;

	private void Update()
	{
		ItemCounter();
	}
	
	void ItemCounter()
	{
		itemCounter[0].SetText("x " + ItemManager.instance.plastic.ToString());
		itemCounter[1].SetText("x " + ItemManager.instance.paper.ToString());
		itemCounter[2].SetText("x " + ItemManager.instance.aluminum.ToString());
		itemCounter[3].SetText("x " + ItemManager.instance.glass.ToString());
		itemCounter[4].SetText("x " + ItemManager.instance.recycledPlastic.ToString());
		itemCounter[5].SetText("x " + ItemManager.instance.recycledPaper.ToString());
		itemCounter[6].SetText("x " + ItemManager.instance.recycledAluminum.ToString());
		itemCounter[7].SetText("x " + ItemManager.instance.recycledGlass.ToString());
	}
}
