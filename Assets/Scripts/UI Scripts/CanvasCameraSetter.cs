using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasCameraSetter : MonoBehaviour
{
    Canvas thisCanvas;

	private void Start()
	{
		thisCanvas = GetComponent<Canvas>();
	}

	void Update()
    {
        if(thisCanvas.worldCamera == null)
		{
			thisCanvas.worldCamera = Camera.main;
		}
    }
}
