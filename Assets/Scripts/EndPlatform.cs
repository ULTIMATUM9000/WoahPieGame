using UnityEngine;

public class EndPlatform : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("PLAYER") && ObjectivesManager.instance.CheckObjectives() == true)
		{
			EndLevel();
		}
	}
	void EndLevel()
	{
		SimpleSceneChanger.SummaryScreen();
	}
}
