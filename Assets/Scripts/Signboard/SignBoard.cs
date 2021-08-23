using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignBoard : MonoBehaviour
{
	[SerializeField] Sprite imageToDisplay;

	[SerializeField] GameObject PopUpObject;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("PLAYER"))
		{
			PopUpObject.SetActive(true);
			PopUpObject.GetComponent<SpriteRenderer>().sprite = imageToDisplay;
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.CompareTag("PLAYER"))
		{
			PopUpObject.SetActive(false);
		}
	}
}
