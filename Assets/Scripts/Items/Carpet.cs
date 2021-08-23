using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carpet : MonoBehaviour
{
	[SerializeField] Transform CarpetProjectile;

	private void Update()
	{
		CheckInput();
	}

	void CheckInput()
	{
		if (Input.GetMouseButtonDown(1) && ItemManager.instance.Carpet > 0)
		{
			LayCarpet();
			ItemManager.instance.Carpet -= 1;
		}
	}

	void LayCarpet()
	{
		Instantiate(CarpetProjectile, new Vector3(transform.position.x,transform.position.y,0),Quaternion.identity);
	}
}
