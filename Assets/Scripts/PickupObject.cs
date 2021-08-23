using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour
{
	enum MaterialType
	{
		Aluminum,
		Glass,
		Paper,
		Plastic
	};
	[SerializeField] MaterialType materialType;

	[SerializeField] int dropAmount;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.CompareTag("PLAYER"))
		{
			switch(materialType)
			{
				case MaterialType.Aluminum:
					ItemManager.Instance.aluminum += dropAmount;
					AudioManager.instance.Play("GetItem");
					break;
				case MaterialType.Glass:
					ItemManager.Instance.glass += dropAmount;
					AudioManager.instance.Play("GetItem");
					break;
				case MaterialType.Paper:
					ItemManager.Instance.paper += dropAmount;
					AudioManager.instance.Play("GetItem");
					break;
				case MaterialType.Plastic:
					ItemManager.Instance.plastic += dropAmount;
					AudioManager.instance.Play("GetItem");
					break;
			}
			Destroy(gameObject);
		}
	}
}
